using System.IO;
using System.Web.Hosting;

namespace TestDynamicViews.Util
{
    public class CustomVirtualFile : VirtualFile
    {
        private byte[] _viewContent;

        public CustomVirtualFile(string virtualPath, byte[] viewContent)
            : base(virtualPath)
        {
            _viewContent = viewContent;
        }

        public override Stream Open()
        {
            return new MemoryStream(_viewContent);
        }
    }
}