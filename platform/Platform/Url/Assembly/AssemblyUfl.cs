using System;
using System.Reflection;

using mpq;
using startup.i;

namespace platform
{
    public class AssemblyUfl : Ufl
    {
        public override void _runLoad(string nUrl)
        {
            AssemblyUrl assemblyUrl_ = __singleton<AssemblyUrl>._instance();
            if (assemblyUrl_._contain(nUrl))
            {
                mAssembly = assemblyUrl_._getAssembly(nUrl);
                return;
            }
            if (null == mAssembly)
            {
                Mpq mpq_ = __singleton<Mpq>._instance();
                mAssembly = mpq_._loadAssembly(nUrl);
            }
            base._runLoad(nUrl);
            assemblyUrl_._pushUrl(nUrl, mAssembly);
        }

        public __t _findFullClass<__t>(string nId)
        {
            object result_ = mAssembly.CreateInstance(nId);
            return ((__t)result_);
        }

        public __t _findClass<__t>(string nId) where __t : class
        {
            AssemblyName assemblyName_ = mAssembly.GetName();
            string namespace_ = assemblyName_.Name;
            string pluginClass_ = namespace_ + ".";
            pluginClass_ += nId;
            object result_ = mAssembly.CreateInstance(pluginClass_);
            return (result_ as __t);
        }

        public AssemblyUfl()
        {
            mAssembly = null;
        }

        Assembly mAssembly;
    }
}
