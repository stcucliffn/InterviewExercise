namespace InterviewExercise.Tests
{
    using InterviewExercise.Core.Models;
    using InterviewExercise.Core.Repositories;
    using InterviewExercise.Core.Services;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class AccountsServicesTests
    {
        private StubbedAccountsRepository stubbedAccountsRepository;
        private AccountsService sut;
        private Account mockAccount;


        /// <summary>
        /// Initializes Account test objects
        /// </summary>
        ///
        [SetUp]
        public void Setup()
        {
            stubbedAccountsRepository = new StubbedAccountsRepository();
            sut = new AccountsService(stubbedAccountsRepository);
            mockAccount = getTestAccount();
        }

        private Account getTestAccount()
        {
            return new Account()
            {
                AccountId = 1,
                AccountNo = "20020001100",
                Balance = 100.00M,
                FirstName = "Luigi",
                LastName = "Mario",
                MemberId = 185265,
                Nickname = "testAccount",
                Status = "Active",
                Type = "CKG"
            };
        }

        [Test]
        public void NicknameExists_KeepsNickname()
        {
            stubbedAccountsRepository.SetMockAccount(mockAccount);
            var result = sut.GetAccount(1);
            Assert.AreEqual("testAccount", result.Nickname);
        }

        [TestCase("CKG","Checking")]
        [TestCase("SAV", "Savings")]
        public void NicknameDoesNotExist_SetsNicknameBasedOnType(string type, string expectedNickname)
        {
            mockAccount.Type = type;
            mockAccount.Nickname = "";
            stubbedAccountsRepository.SetMockAccount(mockAccount);
            var result = sut.GetAccount(1);
            Assert.AreEqual(expectedNickname, result.Nickname);
        }

        [Test]
        public void AccountNumberIsValid_TruncatesToLastFour()
        {
            stubbedAccountsRepository.SetMockAccount(mockAccount);
            var result = sut.GetAccount(mockAccount.MemberId);
            Assert.AreEqual("1100", result.LastFour);
            Assert.AreEqual(4, result.LastFour.Length);
        }

        [Test]
        public void AccountNumberIsTooShort_TruncateThrowsException()
        {
            mockAccount.AccountNo = "999";
            stubbedAccountsRepository.SetMockAccount(mockAccount);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAccount(1));
        }

        [TestCase("active", 1)]
        [TestCase("inactive", 0)]
        public void ListOfAccounts_ReturnsListOfAccountsBasedOnStatus(string status, int expectedAcctCount)
        {
            mockAccount.Status = status;
            List<Account> accounts = new List<Account> { mockAccount };

            stubbedAccountsRepository.SetMockAccounts(accounts);
            var result = sut.GetAccountsForMember(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAcctCount, result.Count);
        }
    }

    public class StubbedAccountsRepository : IAccountsRepository
    {
        Account mockAccount;
        List<Account> mockAccounts;

        public void SetMockAccount(Account mockAccount)
        {
            this.mockAccount = mockAccount;
        }

        public void SetMockAccounts(List<Account> mockAccounts)
        {
            this.mockAccounts = mockAccounts;
        }

        public Account GetAccount(int accountId)
        {
            return mockAccount;
        }

        public List<Account> GetAccountsForMember(int rim)
        {
            return mockAccounts;
        }

        public void UpdateNickname(AccountDTO accountDto)
        {
            throw new NotImplementedException();
        }
    }
}