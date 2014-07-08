using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace BootStrap.WebApi
{
    public class ProductsController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public dynamic Get(string sidx, string sord, Int32 page, Int32 rows)
        {
            var obj = new Products("ADB");
            int? totalRecord = 0;
            int? totalPage = 0;
            var oData = obj.GetAllData(rows, page, "Name", ref totalRecord, ref totalPage);


            return new
            {
                total = totalPage,
                page = page > totalPage ? totalPage : page,
                records = totalRecord,
                rows = oData.ToArray()
            };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}