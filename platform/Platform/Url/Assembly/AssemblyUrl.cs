using System.Reflection;
using System.Collections.Generic;

namespace platform
{
    public class AssemblyUrl
    {
        public Assembly _getAssembly(string nUrl)
        {
            return mUrls[nUrl];
        }

        public bool _contain(string nUrl)
        {
            return mUrls.ContainsKey(nUrl);
        }

        public void _pushUrl(string nUrl, Assembly nAssembly)
        {
            mUrls[nUrl] = nAssembly;
        }

        public AssemblyUrl()
        {
            mUrls = new Dictionary<string, Assembly>();
        }

        Dictionary<string, Assembly> mUrls;
    }
}
