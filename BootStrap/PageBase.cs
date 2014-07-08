
namespace BootStrap
{
    public class PageBase:System.Web.UI.Page
    {
        /// <summary>
        /// 取得網站的url
        /// </summary>
        /// <returns></returns>
        protected string appURL()
        {
            var strURL = "http://" + Request.Url.Host + ":" + Request.Url.Port +
                (Request.ApplicationPath.EndsWith("/") ? string.Empty : Request.ApplicationPath);
            return strURL;
        }
    }
}