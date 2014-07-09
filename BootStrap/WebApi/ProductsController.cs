using System;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace BootStrap.WebApi
{
    public class ProductsController : ApiController
    {
        /// <summary>
        /// 載入全部資料
        /// </summary>
        /// <param name="sidx">排序欄位</param>
        /// <param name="sord">排序方向</param>
        /// <param name="page">頁碼</param>
        /// <param name="rows">分頁筆數</param>
        /// <returns></returns>
        [HttpGet]
        public dynamic Get(string sidx, string sord, Int32 page, Int32 rows)
        {
            var obj = new Products("ADB");
            int? totalRecord = 0;
            int? totalPage = 0;
            var oData = obj.GetAllData(rows, page, sidx, ref totalRecord, ref totalPage);


            return new
            {
                total = totalPage,
                page = page > totalPage ? totalPage : page,
                records = totalRecord,
                rows = oData.ToArray()
            };
        }
        /// <summary>
        /// 關鍵字搜尋
        /// </summary>
        /// <param name="sidx">排序欄位</param>
        /// <param name="sord">排序方向</param>
        /// <param name="page">頁碼</param>
        /// <param name="rows">分頁筆數</param>
        /// <param name="searchString">搜尋字串</param>
        /// <param name="searchField">搜尋欄位</param>
        /// <param name="searchOper">搜尋方式</param>
        /// <returns></returns>
        [HttpGet]
        public dynamic Get(string sidx, string sord, Int32 page, Int32 rows, string searchString, string searchField, string searchOper)
        {
            var obj = new Products("ADB");
            int? totalRecord = 0;
            int? totalPage = 0;
            var oData = obj.GetAllData(rows, page, "ProductID,Name", ref totalRecord, ref totalPage, searchField, searchOper, searchString);


            return new
            {
                total = totalPage,
                page = page > totalPage ? totalPage : page,
                records = totalRecord,
                rows = oData.ToArray()
            };
        }


        /// <summary>
        /// 新增產品資料
        /// </summary>
        /// <param name="item">表單資料</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post(Product item)
        {
            var uri = Url.Link("DefaultApi", new { id = item.ProductID });
            var response = Request.CreateErrorResponse(System.Net.HttpStatusCode.Created, uri);
            try
            {

                var obj = new Products("ADB");
                obj.Insert(item);

            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

            response.Headers.Location = new Uri(uri);
            return response;
        }

        /// <summary>
        /// 修改產品資料
        /// </summary>
        /// <param name="item">表單資料</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(Product item)
        {
            var uri = Url.Link("DefaultApi", new { id = item.ProductID });
            var response = Request.CreateErrorResponse(System.Net.HttpStatusCode.Created, uri);
            try
            {

                var obj = new Products("ADB");
                obj.Update(item);

            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

            response.Headers.Location = new Uri(uri);
            return response;
        }

        /// <summary>
        /// 刪除產品資料
        /// </summary>
        /// <param name="id">產品代碼</param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var uri = Url.Link("DefaultApi", new { id = id });
            var response = Request.CreateErrorResponse(System.Net.HttpStatusCode.Created, uri);
            try
            {

                var obj = new Products("ADB");
                obj.Delete(id);

            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}