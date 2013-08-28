using platform;

namespace weibo.core
{
    public class StatusId : PropertyId
    {
        public override Property _createProperty()
        {
            return new StatusMgr();
        }

        public StatusId()
        {
            this._setId(GenerateId._runCommon(@"weibo.core.StatusId"));
        }
    }
}
