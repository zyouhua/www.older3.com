﻿using System.Collections.Generic;

namespace platform
{
    public interface ISqlFormat
    {
        void _serialize<__t>(ref List<__t> nValue, string nName) where __t : ISqlStream;

        void _serialize<__t>(ref __t nValue, string nName);

        void _serialize(ref bool nValue, string nName);

        void _serialize(ref sbyte nValue, string nName);

        void _serialize(ref byte nValue, string nName);

        void _serialize(ref short nValue, string nName);

        void _serialize(ref ushort nValue, string nName);

        void _serialize(ref int nValue, string nName);

        void _serialize(ref uint nValue, string nName);

        void _serialize(ref long nValue, string nName);

        void _serialize(ref ulong nValue, string nName);

        void _serialize(ref string nValue, string nName);

        void _serialize(ref float nValue, string nName);

        void _serialize(ref double nValue, string nName);

        void _serialize(string nValue);
    }
}
