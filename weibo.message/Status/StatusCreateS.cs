namespace weibo.message
{
    public class StatusCreateS
    {
        public string m_tName { get; set; }
        public long m_tDeviceId { get; set; }
        public uint m_tDeviceType { get; set; }
        public string m_tText { get; set; }
        public StatusType_ m_tStatusType { get; set; }
        public string m_tAttachments { get; set; }
    }
}
