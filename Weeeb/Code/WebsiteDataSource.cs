using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;

namespace WebsitesCatalog
{
    public class WebsiteDataSource
    {
        private static readonly ConcurrentDictionary<string, WebSitesInfo>
            _dataforce = new ConcurrentDictionary<string, WebSitesInfo>();
        public IEnumerable<WebSitesInfo> Items
        {
            get { return WebsiteDataSource._dataforce.Values; }
        }

        public void AddOrUpdate(WebSitesInfo websiteinfo)
        {
            WebsiteDataSource._dataforce.AddOrUpdate(websiteinfo.ID, websiteinfo, (key, oldValue) => websiteinfo);
        }

        public WebSitesInfo Get(string id)
        {
            WebSitesInfo websiteinfo;
            if(WebsiteDataSource._dataforce.TryGetValue(id,out websiteinfo)) { return websiteinfo; }
            websiteinfo = new WebSitesInfo() { ID = string.Empty };
            return websiteinfo;
        }
        public void Delete(string id)
        {
            WebSitesInfo websiteinfo;
            WebsiteDataSource._dataforce.TryRemove(id, out websiteinfo);
        }
    }
}