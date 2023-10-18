namespace BankTestProject_1.ServiceRequest
{
    public static class EndPointUrl
    {
        public static readonly string baseUrl = "https://localhost:80/";

        public static readonly string createAccount = baseUrl + "account/new";

        public static readonly string deleteAccount = baseUrl + "account/";

        public static readonly string getAllAccounts = baseUrl + "accounts";

        public static readonly string makeTransaction = baseUrl + "transaction/new";
    }
}
