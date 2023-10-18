using BankTestProject_1.Helpers;
using BankTestProject_1.Models;
using BankTestProject_1.ServiceRequest;
using System.Net;

namespace BankTestProject_1.TestCases
{
    [TestClass]
    public class Deposit_TestCases
    {
        private readonly ServiceRequestBase _serviceRequestBase = new ServiceRequestBase();
        private readonly HelperClass _helperClass = new HelperClass();
        [TestMethod]
        public void Test_1_VerifyUserCanDepositMoneyIntoExistingAccount()
        {
            string accountId = _helperClass.GetAllAccounts().First().AccountId.ToString();
            AccountTransactions transactions = new AccountTransactions()
            {
                AccountId = accountId,
                TransactionAmount = 6000,
                TransactionType = TransType.Deposit
            };
            HttpWebResponse response = _serviceRequestBase.MakeTransaction(transactions);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        [TestMethod]
        public void Test_2_VerifyUserCanNotDepositMoneyIntoNotExistingAccount()
        {
            string accountId = "account_na";
            AccountTransactions transactions = new AccountTransactions()
            {
                AccountId = accountId,
                TransactionAmount = 6000,
                TransactionType = TransType.Deposit
            };
            HttpWebResponse response = _serviceRequestBase.MakeTransaction(transactions);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        [DataRow(10, HttpStatusCode.OK)]
        [DataRow(10000, HttpStatusCode.OK)]
        [DataRow(10001, HttpStatusCode.UnprocessableEntity)]
        [DataRow(122221, HttpStatusCode.UnprocessableEntity)]
        public void Test_3_VerifyDepositLimit(decimal amount, HttpStatusCode expectedStatus)
        {
            string accountId = "account_na";
            AccountTransactions transactions = new AccountTransactions()
            {
                AccountId = accountId,
                TransactionAmount = amount,
                TransactionType = TransType.Deposit
            };
            HttpWebResponse response = _serviceRequestBase.MakeTransaction(transactions);
            Assert.AreEqual(expectedStatus, response.StatusCode);
        }
    }
}