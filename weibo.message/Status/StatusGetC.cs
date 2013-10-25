using System.Collections.Generic;

namespace weibo.message
{
    public class StatusGetC
    {
        public ErrorCode_ m_tErrorCode { get; set; }
        public long m_tTicks { get; set; }
        public List<StatusC> m_tStatusCs
        {
            get
            {
                return mStatusCs;
            }
            set
            {
                mStatusCs = value;
            }
        }

        public StatusGetC()
        {
            mStatusCs = new List<StatusC>();
        }

        List<StatusC> mStatusCs;
    }
}
