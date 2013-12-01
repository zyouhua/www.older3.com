using System.IO;
using System.Web;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Compilation;

using mpq;
using startup.i;

[assembly: PreApplicationStartMethod(typeof(startup.Startup), "_runLoad")]
namespace startup
{
    public static class Startup
    {
        public static void _runLoad()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(MvcApplication));
            MvcEngineSingleton mvcEngineSingleton_ = __singleton<MvcEngineSingleton>._instance();
            mvcEngineSingleton_._addAssembly(assembly);

            Mpq mpq_ = __singleton<Mpq>._instance();

#if DEBUG
            string systemPath_ = HostingEnvironment.MapPath(@"~");
            systemPath_ = Path.Combine(systemPath_, @"../../bin/home/");
            mpq_._runInit(systemPath_);
#else
            string systemPath_ = HostingEnvironment.MapPath(@"~");
            mpq_._runInit(systemPath_);
#endif
            StartupSingleton startupSingleton_ = __singleton<StartupSingleton>._instance();
            startupSingleton_._runInit();

            mvcEngineSingleton_._runMvcEngine();
        }
    }
}
