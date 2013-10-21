namespace platform
{
    public class InitService
    {
        public _RunInit m_tRunInit;
        public _RunInit m_tRunStart;
        public _RunInit m_tRunExit;
        public _RunInit m_tRunSave;

        public InitService()
        {
            m_tRunInit = null;
            m_tRunStart = null;
            m_tRunExit = null;
            m_tRunSave = null;
        }
    }
}
