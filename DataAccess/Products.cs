using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    partial class ProductsDataContext
    {
    }

    public class Products:Basic_DAL
    {

        private string tbName = "AdventureWorks.Production.Product";

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="configStringKeyName">系統設定的連線字串名稱</param>
        public Products(string configStringKeyName)
        {
            Initial(configStringKeyName);
        }


        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="pageSize">分頁大小</param>
        /// <param name="pageIndex">頁碼</param>
        /// <param name="sortColumns">排序欄位</param>
        /// <param name="totalRecord">總筆數</param>
        /// <param name="totalPage">總頁數</param>
        /// <returns></returns>
        public List<Product> GetAllData(Int32 pageSize, Int32 pageIndex, string sortColumns, ref Int32? totalRecord, ref Int32? totalPage)
        {
            return GetAllData(pageSize, pageIndex, sortColumns, ref totalRecord, ref totalPage, "", string.Empty, string.Empty);
        }



        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="pageIndex">頁碼</param>
        /// <param name="pageSize">分頁大小</param>
        /// <param name="sortColumns">排序欄位</param>
        /// <param name="totalPage">總頁數</param>
        /// <param name="totalRecord">總筆數</param>
        /// <param name="searchField">搜尋欄位名</param>
        /// <param name="searchOper">搜尋運算子</param>
        /// <param name="searchString">搜尋值</param>
        /// <returns></returns>
        public List<Product> GetAllData(Int32 pageSize, Int32 pageIndex, string sortColumns, ref Int32? totalRecord, ref Int32? totalPage, string searchField, string searchOper, string searchString)
        {

            List<Product> lstobj = new List<Product>();
            var whereClause = string.Empty;
            if (searchField == "allFieldSearch")
            {
                //組全文檢索的條件
                whereClause =
                    whereCombination("cn", "Name", searchString, LogicOperator.OR) +
                    whereCombination("cn", "ProductNumber", searchString, LogicOperator.OR) +
                    whereCombination("cn", "Color", searchString, LogicOperator.NONE);
            }
            else
            {
                whereClause = whereCombination(searchOper, searchField, searchString, LogicOperator.NONE);
            }

            SqlParameter[] aryParm =
            {
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@PageIndex",pageIndex),
                new SqlParameter("@Totalrecord",totalRecord),
                new SqlParameter("@TotalPage",totalPage),
                new SqlParameter("@TableName","AdventureWorks.Production.Product"),
                new SqlParameter("@OrderColumn",sortColumns),
                new SqlParameter("@WhereColumn",whereClause)
            };
            aryParm[2].Direction = ParameterDirection.Output;
            aryParm[3].Direction = ParameterDirection.Output;


            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("SP_Get_PageingData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(aryParm);
                    conn.Open();
                    var sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Product obj = new Product();
                        obj.Class = sdr["Class"].ToString();
                        obj.Color = sdr["Color"].ToString();

  
                        obj.Name = sdr["Name"].ToString();
                        obj.ProductID = Convert.ToInt32(sdr["ProductID"]);
                        obj.ProductNumber = sdr["ProductNumber"].ToString();
                        obj.Color = sdr["Color"].ToString();


                        lstobj.Add(obj);

                    }
                    sdr.Close();
                    totalRecord = Convert.ToInt32(cmd.Parameters["@Totalrecord"].Value);
                    totalPage = Convert.ToInt32(cmd.Parameters["@TotalPage"].Value);
                }
            }
 
            
           


            return lstobj;
        }

    }
}
