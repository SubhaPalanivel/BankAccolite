using BankTestProject_1.Models;
using Newtonsoft.Json;
using System.Net;

namespace BankTestProject_1.ServiceRequest
{
    public class ServiceRequestBase
    {
        SetRequest setRequest = new();
        public HttpWebResponse CreateAccount(Account account)
        {
            string jsonAccount = JsonConvert.SerializeObject(account);
            HttpWebRequest request = setRequest.SetPUTRequest(EndPointUrl.createAccount, "application/json", jsonAccount);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public HttpWebResponse CreateAccount(List<Account> account)
        {
            string jsonAccount = JsonConvert.SerializeObject(account);
            HttpWebRequest request = setRequest.SetPUTRequest(EndPointUrl.createAccount, "application/json", jsonAccount);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public HttpWebResponse DeleteAccount(string accountName)
        {
            HttpWebRequest request = setRequest.SetDeleteRequest(EndPointUrl.deleteAccount + accountName, "application/json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public HttpWebResponse GetAccount()
        {
            HttpWebRequest request = setRequest.SetGetRequest(EndPointUrl.getAllAccounts, "application/json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public HttpWebResponse MakeTransaction(AccountTransactions transactions)
        {
            string jsonTransaction = JsonConvert.SerializeObject(transactions);
            HttpWebRequest request = setRequest.SetPUTRequest(EndPointUrl.makeTransaction, "application/json", jsonTransaction);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
    }
}