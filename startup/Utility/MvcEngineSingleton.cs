using System.Web.Mvc;
using System.Web.WebPages;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Compilation;
using PrecompiledMvcViewEngineContrib;

namespace startup
{
    public class MvcEngineSingleton
    {
        public void _runMvcEngine()
        {
            PrecompiledMvcEngine precompiledMvcEngine = new PrecompiledMvcEngine(mAssemblys);
            ViewEngines.Engines.Add(precompiledMvcEngine);
            VirtualPathFactoryManager.RegisterVirtualPathFactory(precompiledMvcEngine); 
        }

        public void _addAssembly(Assembly nAssembly)
        {
            mAssemblys.Add(nAssembly);
            BuildManager.AddReferencedAssembly(nAssembly);
        }

        public MvcEngineSingleton()
        {
            mAssemblys = new List<Assembly>();
        }

        List<Assembly> mAssemblys;
    }
}
