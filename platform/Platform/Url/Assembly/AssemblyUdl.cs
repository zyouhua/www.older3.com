using System;
using System.Reflection;
using System.Collections.Generic;

using mpq;
using startup.i;

namespace platform
{
    public class AssemblyUdl : Udl
    {
        public override void _runLoad(string nUrl)
        {
            UrlParser urlParser_ = new UrlParser(nUrl);
            string url_ = urlParser_._returnResult();
            AssemblyUrl assemblyUrl_ = __singleton<AssemblyUrl>._instance();
            if (assemblyUrl_._contain(url_))
            {
                mAssembly = assemblyUrl_._getAssembly(url_);
                return;
            }
            base._runLoad(url_);

            string assemblyInfoUrl_ = url_ + @"*$assembly.xml";
            mAssemblyInfo._runLoad(assemblyInfoUrl_);

            UidSingleton uidSingleton_ = __singleton<UidSingleton>._instance();
            IEnumerable<Rid> rids_ = mAssemblyDescriptor._getRids();
            foreach (Rid i in rids_)
            {
                uidSingleton_._addRid(i);
            }

            IEnumerable<string> dependences_ = mAssemblyDescriptor._getDependences();
            foreach (string i in dependences_)
            {
                this._loadAssemblyUfl(i);
            }

            IEnumerable<Uid> uids_ = mAssemblyDescriptor._getUids();
            foreach (Uid i in uids_)
            {
                uidSingleton_._addUid(i);
                Uid uid_ = i._getUid();
                string uidUrl_ = uid_._getOptimal();
                this._loadAssemblyUdl(uidUrl_);
            }

            IEnumerable<Uid> addins_ = mAssemblyDescriptor._getAddins();
            foreach (Uid i in addins_)
            {
                uidSingleton_._addUid(i);
                Uid uid_ = i._getUid();
                string uidUrl_ = uid_._getOptimal();
                this._loadAddins(uidUrl_);
            }

            IEnumerable<string> plugins_ = mAssemblyDescriptor._getPlugins();
            foreach (string i in plugins_)
            {
                this._loadPlugins(i);
            }

            if (null == mAssembly)
            {
                Mpq mpq_ = __singleton<Mpq>._instance();
                mAssembly = mpq_._loadAssembly(url_);
            }
            assemblyUrl_._pushUrl(url_, mAssembly);
        }

        public __t _findFullClass<__t>(string nId)
        {
            object result_ =  mAssembly.CreateInstance(nId);
            return (__t)result_;
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

        void _loadAssemblyUdl(string nUrl)
        {
            AssemblyUdl assemblyUdl_ = new AssemblyUdl();
            assemblyUdl_._runLoad(nUrl);
        }

        void _loadAssemblyUfl(string nUrl)
        {
            AssemblyUfl assemblyUfl_ = new AssemblyUfl();
            assemblyUfl_._runLoad(nUrl);
        }

        void _loadAddins(string nUrl)
        {
            AddinUdl addinUdl_ = new AddinUdl();
            addinUdl_._runLoad(nUrl);
        }

        void _loadPlugins(string nUrl)
        {
            PluginUfl pluginUfl_ = new PluginUfl();
            pluginUfl_._runLoad(nUrl);
        }

        public AssemblyUdl()
        {
            mAssemblyDescriptor = new AssemblyDescriptor();
            mAssemblyInfo = new StdUfl();
            mAssemblyInfo.m_tSerializeTypeSlot += mAssemblyDescriptor._serializeType;
            mAssemblyInfo.m_tStreamNameSlot += mAssemblyDescriptor._streamName;
            mAssemblyInfo.m_tHeadSerializeSlot += mAssemblyDescriptor._headSerialize;
            mAssembly = null;
        }

        AssemblyDescriptor mAssemblyDescriptor;
        StdUfl mAssemblyInfo;
        Assembly mAssembly;
    }
}
