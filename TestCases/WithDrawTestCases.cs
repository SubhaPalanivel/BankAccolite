using BankTestProject_1.Helpers;
using BankTestProject_1.Models;
using BankTestProject_1.ServiceRequest;
using System.Net;

namespace BankTestProject_1.TestCases
{
    [TestClass]
    public class WithDrawTestCases
    {
        private readonly ServiceRequestBase _serviceRequestBase = new ServiceRequestBase();
        private readonly HelperClass _helperClass = new HelperClass();
        [TestMethod]
        public void Test_1_VerifyUSerCanWithdrawAmountFromExistingAccount()
        {
            string accountId = _helperClass.GetAllAccounts().First().AccountId.ToString();
            List<string> accountIds = _helperClass.GetAllAccounts().Where(account => account.TotalAmount > 5000).Select(account => account.AccountId).ToList();
            AccountTransactions transactions = new AccountTransactions()
            {
                AccountId = accountIds[0],
                TransactionAmount = 4000,
                TransactionType = TransType.Withdrawl
            };
            HttpWebResponse response = _serviceRequestBase.MakeTransaction(transactions);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        [TestMethod]
        public void Test_2_VerifyUserCanNotWithdrawMoneyFromNotExistingAccount()
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
        public void Test_3_VerifyUSerCanNotWithdrawWhenAfterTransactionBalanceIsLessthan100()
        {
            List<string> accountIds = _helperClass.GetAllAccounts().Where(account => account.TotalAmount <= 200).Select(account => account.AccountId).ToList();
            AccountTransactions transactions = new AccountTransactions()
            {
                AccountId = accountIds[0],
                TransactionAmount = 150,
                TransactionType = TransType.Withdrawl
            };
            HttpWebResponse response = _serviceRequestBase.MakeTransaction(transactions);
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestMethod]
        public void Test_4_VerifyUSerCanNOtWithdrawMoreThan90Percent()
        {
            string accountSId = _helperClass.GetAllAccounts().First().AccountId.ToString();
            List<decimal> amount = _helperClass.GetAllAccounts().Where(account => account.AccountId == accountSId).Select(account => account.TotalAmount).ToList();
            decimal amnt = amount[0] * 0.9M + 100;
            AccountTransactions transactions = new AccountTransactions()
            {
                AccountId = accountSId,
                TransactionAmount = amnt,
                TransactionType = TransType.Withdrawl
            };
            HttpWebResponse response = _serviceRequestBase.MakeTransaction(transactions);
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

    }
}