// 这是主 DLL 文件。

#include "stdafx.h"

#include "mpq.h"

using namespace startup::i;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;
using namespace System::Web::Compilation;

namespace mpq {

	static void _assemblyLoad( Object^ sender, AssemblyLoadEventArgs^ args )
	{
		BuildManager::AddReferencedAssembly(args->LoadedAssembly);
	}

	static Assembly^ _assemblyResolve(Object^ sender, ResolveEventArgs^ args)
	{
		AppDomain^ appDomain_ = AppDomain::CurrentDomain;
		array<Assembly^>^ assemblies_ = appDomain_->GetAssemblies();
		for ( int i = 0; i < assemblies_->Length; i++ )
		{
			Assembly^ assembly_ = assemblies_[i];
			if (String::Compare(assembly_->FullName, args->Name) == 0)
			{
				return assembly_;
			}
		}
		return nullptr;
	}

	void Mpq::_runInit(String^ nPath)
	{
		String^ path_ = Path::Combine(nPath, L"1282682146.dat");
		char * cpath_ = (char*)(void*)Marshal::StringToHGlobalAnsi(path_);

		mMpqFile = check_file(cpath_);

		Marshal::FreeHGlobal(IntPtr(cpath_));

		AppDomain^ appDomain_ = AppDomain::CurrentDomain;
		appDomain_->AssemblyResolve += gcnew ResolveEventHandler(_assemblyResolve);
		appDomain_->AssemblyLoad += gcnew AssemblyLoadEventHandler(_assemblyLoad);

		Assembly^ assembly_ = this->_loadAssembly(L"mpq://platform.dll");
		IStartup^ startup_ = (IStartup^)assembly_->CreateInstance(L"platform.Startup");
		StartupSingleton^ startupSingleton_ = __singleton<StartupSingleton^>::_instance();
		startupSingleton_->_setStartup(startup_);
	}

	void Mpq::_runOpen(String^ nPath, unsigned nCount)
	{
		String^ path_ = Path::Combine(nPath, L"1282682146.dat");
		char * pathc_ = (char*)(void*)Marshal::StringToHGlobalAnsi(path_);
		mMpqFile = open_file(pathc_, nCount);
		Marshal::FreeHGlobal(IntPtr(pathc_));
	}

	bool Mpq::_haveFile(String^ nKey)
	{
		char * key_ = (char*)(void*)Marshal::StringToHGlobalAnsi(nKey);
		bool result_ = have_file(mMpqFile, key_);
		Marshal::FreeHGlobal(IntPtr(key_));
		return result_;
	}

	void Mpq::_writeFile(String^ nPath, String^ nKey)
	{
		char * path_ = (char*)(void*)Marshal::StringToHGlobalAnsi(nPath);
		char * key_ = (char*)(void*)Marshal::StringToHGlobalAnsi(nKey);

		write_file(mMpqFile, path_, key_);

		Marshal::FreeHGlobal(IntPtr(path_));
		Marshal::FreeHGlobal(IntPtr(key_));
	}

	Assembly^ Mpq::_loadAssembly(String^ nKey)
	{
		char * key = (char*)(void*)Marshal::StringToHGlobalAnsi(nKey);
		char * buf;
		unsigned int size;
		read_file(mMpqFile, key, &buf, &size);
		array<unsigned char>^ bytes = gcnew array<unsigned char>(size);
		Marshal::Copy(IntPtr(buf), bytes, 0, size);
		free_buf(buf, size);
		AppDomain^ appDomain_ = AppDomain::CurrentDomain;
		Assembly^ result_ = appDomain_->Load(bytes);
		Marshal::FreeHGlobal(IntPtr(key));
		return result_;
	}

	void Mpq::_readFile(String^ nKey, array<unsigned char>^% nBytes, unsigned% nSize)
	{
		char * temp = (char*)(void*)Marshal::StringToHGlobalAnsi(nKey);
		char * buf;
		unsigned int size;
		read_file(mMpqFile, temp, &buf, &size);
		nBytes = gcnew array<unsigned char>(size);
		nSize = size;
		Marshal::Copy(IntPtr(buf), nBytes, 0, size);
		free_buf(buf, size);
		Marshal::FreeHGlobal(IntPtr(temp));
	}

	void Mpq::_runSave()
	{
		save_close_file(mMpqFile);
	}

	void Mpq::_runClose()
	{
		close_file(mMpqFile);
	}
}

