// mpq.h

#pragma once

#include "../libmpq/mpq.h"

using namespace System;
using namespace System::Reflection;

namespace mpq {

	public ref class Mpq
	{
	public:
		void _runInit(String^ nPath);
		void _runOpen(String^ nPath, unsigned nCount);
		Assembly^ _loadAssembly(String^ nKey);
		bool _haveFile(String^ nKey);
		void _writeFile(String^ nPath, String^ nKey);
		void _readFile(String^ nKey, array<unsigned char>^% nBytes, unsigned% nSize);
		void _runSave();
		void _runClose();
		
	private:
		mpq_file * mMpqFile;
	};
}
