using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_XuZhou.Common.Helper;

namespace WPF_XuZhou
{
   public class WebHelper
    {
        public static string UserCookie = "";
        public static HttpResult Post(string _url, string _data)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _url,
                Method = "POST",
                Cookie = UserCookie,
                ContentType = "application/x-www-form-urlencoded",
                Postdata = _data,
                ResultType = ResultType.String,
            };
            return http.GetHtml(item);
        }
        public static HttpResult Get(string _url)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = _url,
                Method = "Get",
                Cookie = UserCookie,
                ContentType = "application/x-www-form-urlencoded",
                ResultType = ResultType.String,
            };
            return http.GetHtml(item);
        }
    }
}
