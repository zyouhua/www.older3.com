using startup.i;

namespace platform
{
    public class AddinUdl : AssemblyUdl
    {
        public override void _runLoad(string nUrl)
        {
            base._runLoad(nUrl);
            this._runPlugin();
        }

        private void _runPlugin()
        {
            IPlugin start_ = base._findClass<IPlugin>(@"Startup");
            if (null != start_)
            {
                start_._runLoad();
            }
        }
    }
}
