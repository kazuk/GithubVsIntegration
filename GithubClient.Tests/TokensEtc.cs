namespace GithubClient.Tests
{
    public partial class TokensEtc
    {
        static partial void Configure();

        public static string UserName;
        public static string Password;
        public static string AccessToken;

        static TokensEtc()
        {
            Configure();
        }
    }
}