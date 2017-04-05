using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;

namespace WebsitesCatalog

{
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 
    public class WebsiteDataService : IWebsiteDataService
    {
        private readonly WebsiteDataSource _dataSourse = new WebsiteDataSource();
        public void Insert(WebSitesInfo websiteinfo)
        {
            if (string.IsNullOrWhiteSpace(websiteinfo.ID))
                websiteinfo.ID = Guid.NewGuid().ToString();
            this._dataSourse.AddOrUpdate(websiteinfo);
        }
        public void Delete(string id)
        {
            this._dataSourse.Delete(id);
        }
        public WebSitesInfo Get(string id)
        {
            return this._dataSourse.Get(id);
        }
    }
}