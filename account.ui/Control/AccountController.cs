using System.Web.Http;

using platform;
using account.message;

namespace account.ui
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public ErrorCode_ _createAccount(string nName, string nNick, string nPassward)
        {
            AccountSink accountSink_ = __singleton<AccountSink>._instance();
            return accountSink_.m_tAccountCreate(nName, nNick, nPassward);
        }

        [HttpGet]
        public AccountLoginC _loginAccount(string nName, string nPassward, uint nDeviceType)
        {
            AccountSink accountSink_ = __singleton<AccountSink>._instance();
            return accountSink_.m_tAccountLogin(nName, nPassward, nDeviceType);
        }

        [HttpGet]
        public ErrorCode_ _logoutAccount(string nName, long nDeviceId, uint nDeviceType, uint nServerId)
        {
            AccountSink accountSink_ = __singleton<AccountSink>._instance();
            return accountSink_.m_tAccountLogout(nName, nDeviceId, nDeviceType, nServerId);
        }
    }
}
