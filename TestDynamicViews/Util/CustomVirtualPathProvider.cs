using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web.Hosting;
using TestDynamicViews.Data;

namespace TestDynamicViews.Util
{
    public class CustomVirtualPathProvider : VirtualPathProvider
    {
        public override bool FileExists(string virtualPath)
        {
            if (getViewFromTestData(virtualPath) != null)
                return true;

            return base.FileExists(virtualPath);
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var view = getViewFromTestData(virtualPath);

            if(view != null)
                return new CustomVirtualFile(virtualPath, Encoding.UTF8.GetBytes(view.Content));

            return base.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            var view = getViewFromTestData(virtualPath);

            if (view != null)
                return null;

            return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }

        private DynamicView getViewFromTestData(string virtualPath)
        {
            return TestData.DynamicViews.Where(x => x.Path == sanitizeVirtualPath(virtualPath)).SingleOrDefault();
        }

        private string sanitizeVirtualPath(string virtualPath)
        {
            return virtualPath.Replace("~", "");
        }
    }
}