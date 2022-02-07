namespace TransparentData
{
    public class Authorization
    {
        public const string SettingName = "Authorization";

        public string Url { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public Impersonation Impersonation { get; set; }
    }

    public partial class Impersonation
    {
        public string Login { get; set; }
    }
}
