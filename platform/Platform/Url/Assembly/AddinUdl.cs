using startup.i;

namespace platform
{
    public class AddinUdl : AssemblyUdl
    {
        public override void _runLoad(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string url_ = urlParser_._returnResult();
            base._runLoad(url_);
            this._runPlugin();
        }

        private void _runPlugin()
        {
            IPlugin start_ = base._findClass<IPlugin>(@"Plugin");
            if (null != start_)
            {
                start_._runLoad();
            }
        }
    }
}
