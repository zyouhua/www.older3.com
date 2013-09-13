using System.IO;
using System.Collections.Generic;

using mpq;
using platform;
using startup.i;

namespace package
{
    class Program
    {
        static void Main(string[] args)
        {
            uint count = _countDirectory(args[1]);
            Mpq mpq_ = __singleton<Mpq>._instance();
            mpq_._runOpen(args[0], count);
            _runDirectory(args[1]);
            mpq_._runSave();
        }

        static void _runDirectory(string nName)
        {
            string packages_ = Path.Combine(nName, @"packages.xml");
            if (File.Exists(packages_))
            {
                _loadPackages(nName, packages_);
            }
            string [] directorys_ = Directory.GetDirectories(nName);
            foreach (string i in directorys_)
            {
                _runDirectory(i);
            }
        }

        static void _loadPackages(string nPath, string nName)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            ISerialize serialize_ = platformSingleton_._getReader(SerializeType_.mXml_);
            serialize_._openPath(nName);
            Packages packages_ = new Packages();
            serialize_._selectStream(packages_._streamName());
            packages_._headSerialize(serialize_);
            serialize_._runClose();
            IList<Package> packageL_ = packages_._getPackages();
            foreach (Package i in packageL_)
            {
                _loadPackage(nPath, i);
            }
        }

        static void _loadPackage(string nPath, Package nPackage)
        {
            string name_ = nPackage._getName();
            string value_ = nPackage._getValue();
            Mpq mpq_ = __singleton<Mpq>._instance();
            string path_ = Path.Combine(nPath, value_);
            mpq_._writeFile(path_, name_);
        }

        static uint _countDirectory(string nName)
        {
            uint result_ = 0;
            string packages_ = Path.Combine(nName, @"packages.xml");
            if (File.Exists(packages_))
            {
                result_ = _countPackages(nName, packages_);
            }
            string[] directorys_ = Directory.GetDirectories(nName);
            foreach (string i in directorys_)
            {
                result_ += _countDirectory(i);
            }
            return result_;
        }

        static uint _countPackages(string nPath, string nName)
        {
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            ISerialize serialize_ = platformSingleton_._getReader(SerializeType_.mXml_);
            serialize_._openPath(nName);
            Packages packages_ = new Packages();
            serialize_._selectStream(packages_._streamName());
            packages_._headSerialize(serialize_);
            serialize_._runClose();
            IList<Package> packageL_ = packages_._getPackages();
            uint result_ = (uint)packageL_.Count;
            return result_;
        }
    }
}
