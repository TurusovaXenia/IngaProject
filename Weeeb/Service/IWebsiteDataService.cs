using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsitesCatalog
{
    public interface IWebsiteDataService
    {
        void Insert(WebSitesInfo websitesinfo);
        void Delete(string id);
        WebSitesInfo Get(string id);
    }
}