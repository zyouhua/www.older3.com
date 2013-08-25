using System.Web.Http;

using platform;
using weibo.message;

namespace weibo.ui
{
    public class StatusController : ApiController
    {
        [HttpPost]
        public StatusGetC _getStatus(StatusGetS nStatusGetS)
        {
            StatusSink statusSink_ = __singleton<StatusSink>._instance();
            return statusSink_.m_tStatusGet(nStatusGetS);
        }

        [HttpPost]
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            StatusSink statusSink_ = __singleton<StatusSink>._instance();
            return statusSink_.m_tStatusCreate(nStatusCreateS);
        }
    }
}
