
namespace DataAccess
{
    public class Basic_DAL
    {
        private string _connectionString;

        /// <summary>
        /// 連線字串
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        /// <summary>
        /// 初始化物件連線
        /// </summary>
        /// <param name="configStringKeyName"></param>
        protected void Initial(string configStringKeyName)
        {
            _connectionString = ConfigHelper.GetConnectionString(configStringKeyName);
        }
        
        /// <summary>
        /// 邏輯運算子
        /// </summary>
        protected enum LogicOperator
        {
            AND = 1,
            OR = 2,
            NONE = 0
        };

        /// <summary>
        /// 組合條件子句
        /// </summary>
        /// <param name="oper">運算子</param>
        /// <param name="col">欄位名</param>
        /// <param name="searchString">搜尋值</param>
        /// <param name="logicOper">邏輯運算子（加在搜尋值後面的邏輯運算子，空值代表沒有）</param>
        /// <returns></returns>
        protected static string whereCombination(string oper, string col, string searchString, LogicOperator logicOper)
        {
            var whereClause = string.Empty;

            switch (oper)
            {
                case "eq":
                    whereClause = col + " ='" + searchString + "' ";
                    break;
                case "ne":
                    whereClause = col + " <>'" + searchString + "' ";
                    break;
                case "bw":
                    whereClause = col + " LIKE '" + searchString + "%' ";
                    break;
                case "whereClause":
                    whereClause = col + " NOT LIKE='" + searchString + "%' ";
                    break;
                case "ew":
                    whereClause = col + " LIKE '%" + searchString + "' ";
                    break;
                case "en":
                    whereClause = col + "NOT LIKE '%" + searchString + "' ";
                    break;
                case "cn":
                    whereClause = col + " LIKE '%" + searchString + "%' ";
                    break;
                case "nc":
                    whereClause = col + " NOT LIKE '%" + searchString + "%' ";
                    break;
                case "nu":
                    whereClause = col + " IS NULL ";
                    break;
                case "nn":
                    whereClause = col + " IS NOT NULL ";
                    break;
                case "lt":
                    whereClause = col + " < '" + searchString + "' ";
                    break;
                case "gt":
                    whereClause = col + " > '" + searchString + "' ";
                    break;
                case "ge":
                    whereClause = col + " >= '" + searchString + "' ";
                    break;
            }

            switch (logicOper.ToString())
            {
                case "AND":
                    whereClause += " AND ";
                    break;
                case "OR":
                    whereClause += " OR ";
                    break;

            }

            return whereClause;
        }
    }
}
