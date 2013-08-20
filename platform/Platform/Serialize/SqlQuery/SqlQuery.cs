using System.Collections.Generic;

namespace platform
{
    public class SqlQuery : SqlFormat
    {
        public string _runFormat()
        {
            foreach (ISqlHeadstream i in mSqlHeadstreams)
            {
                this._runFormat(i);
            }
            return this._sqlCommand();
        }

        public void _addHeadstream(ISqlHeadstream nSqlHeadstreams)
        {
            mSqlHeadstreams.Add(nSqlHeadstreams);
        }

        public SqlQuery()
        {
            mSqlHeadstreams = new List<ISqlHeadstream>();
        }

        List<ISqlHeadstream> mSqlHeadstreams;
    }
}
