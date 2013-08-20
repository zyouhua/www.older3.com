using System.Web.Http;

using account.message;

namespace account.ui
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public ErrorCode_ _createAccount(string nName, string nNick, string nPassward)
        {
            return ErrorCode_.mSucess_;
        }
    }
}
