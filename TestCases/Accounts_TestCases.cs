using BankTestProject_1.Helpers;
using BankTestProject_1.Models;
using BankTestProject_1.ServiceRequest;
using System.Net;

namespace BankTestProject_1.TestCases
{
    [TestClass]
    public class Accounts_TestCases
    {
        private readonly ServiceRequestBase _serviceRequestBase = new ServiceRequestBase();
        private readonly HelperClass _helperClass = new HelperClass();

        [TestMethod]
        public void Test_1_VerifyUserCreatesAnAccount()
        {
            Account account = new Account()
            {
                AccountName = "Account_001",
                TotalAmount = 1000,
            };
            HttpWebResponse response = _serviceRequestBase.CreateAccount(account);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void Test2_VerifyUserCanCreateMultipleAccounts()
        {

            List<Account> accounts = new List<Account>()
            {
                new Account()
                {
                AccountName = "Account_001",
                TotalAmount = 1000,
                },
                new Account()
                {
                    AccountName = "Account_001",
                    TotalAmount = 3000,
                }
            };

            HttpWebResponse response = _serviceRequestBase.CreateAccount(accounts);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void Test3_DeleteValidAccount()
        {
            string accountName = _helperClass.GetAllAccounts().First().AccountName.ToString();
            HttpWebResponse response = _serviceRequestBase.DeleteAccount(accountName);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Test4_DeleteNotAvailableAccount()
        {
            string accountName = "Account_NA";
            HttpWebResponse response = _serviceRequestBase.DeleteAccount(accountName);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}