using BankTestProject_1.Models;
using BankTestProject_1.ServiceRequest;
using Newtonsoft.Json;
using System.Net;

namespace BankTestProject_1.Helpers
{
    public  class HelperClass
    {
        ServiceRequestBase _serviceRequestBase = new();
        public List<Account> GetAllAccounts()
        {
            HttpWebResponse response = _serviceRequestBase.GetAccount();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Stream stream = response.GetResponseStream();
            StreamReader str = new(stream);
            string jsonAccount = str.ReadToEnd();
            List <Account> responseProducts = JsonConvert.DeserializeObject<List<Account>>(jsonAccount);
            return responseProducts;
        }
    }
}
