using platform;

namespace weibo.core
{
    public class StatusId : PropertyId<StatusMgr>, ISqlHeadstream
    {
        public void _runSelect(ISqlFormat nSqlFormat)
        {
        }

        public void _runWhere(ISqlFormat nSqlFormat)
        {
        }

        public string _tableName()
        {
            return null;
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mUpdate_;
        }

        public void _runStart()
        {
            InitService initService_ = __singleton<InitService>._instance();
            initService_.m_tRunInit += _runInit;
        }

        public void _runInit()
        {

        }

        public StatusId()
        {

        }
    }
}
