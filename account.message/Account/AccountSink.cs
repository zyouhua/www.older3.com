namespace account.message
{
    public class AccountSink
    {

        public _AccountCreate m_tAccountCreate;

        public _AccountLogin m_tAccountLogin;

        public _AccountLogout m_tAccountLogout;

        public AccountSink()
        {
            m_tAccountCreate = null;
            m_tAccountLogin = null;
            m_tAccountLogout = null;
        }
    }
}
