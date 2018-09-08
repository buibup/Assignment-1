using System;
using System.Collections.Generic;
using System.Text;

namespace PSC.PT13.Helper
{
    public sealed class WebService
    {
        #region Private members section
        private static System.Net.NetworkCredential credential;
        #endregion

        #region Public methods section
        public static string GetUrlPath(string url)
        {
            string[] path = url.Split('/');
            string wsServer = System.Configuration.ConfigurationManager.AppSettings["WebServiceServer"].ToString();
            return wsServer + path[path.Length - 1];
        }

        public static System.Net.NetworkCredential GetCredential()
        {
            if (credential == null)
            {                                
                string wsUsername = System.Configuration.ConfigurationManager.AppSettings["WebServiceUsername"].ToString();
                string wsPassword = System.Configuration.ConfigurationManager.AppSettings["WebServicePassword"].ToString();
                string wsDomain = System.Configuration.ConfigurationManager.AppSettings["WebServiceDomain"].ToString();
                if(wsDomain == "")
                    credential = new System.Net.NetworkCredential(wsUsername, wsPassword);
                else
                    credential = new System.Net.NetworkCredential(wsUsername, wsPassword, wsDomain);
            }
            return credential;
        }

        public static System.Net.WebProxy GetWebProxy(string url)
        {
            if (url != null)
            {
                System.Net.WebProxy proxy = new System.Net.WebProxy(url);
                proxy.Credentials = GetCredential();
                return proxy;
            }
            else
            {
                return null;
            }
        }
        #endregion
        
    }
}
