namespace InterviewExercise.Tests
{
    using Core.Models;
    using Core.Repositories;
    using Core.Services;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class AccountServiceTests
    {
        [Test]
        public void ShouldLimitAccountNumberToLastFour()
        {
            IAccountRepository stubbedAccountRepository = new StubbedAccountRepository();
            IMemberRepository stubbedMemberRepository = new StubbedMemberRepository();
            var sut = new AccountService(stubbedAccountRepository, stubbedMemberRepository);

            var account = sut.GetAccount("1");

            Assert.AreEqual("1234", account.LastFour);
        }
    }

    public class StubbedMemberRepository : IMemberRepository
    {
        public Member GetMember(string memberId)
        {
            return new Member();
        }
    }

    public class StubbedAccountRepository : IAccountRepository
    {
        public List<Account> GetAccountsForMember(string memberId)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccount(string accountId)
        {
            return new Account
            {
                AccountNo = "1234561234"
            };
        }

        public Account UpdateAccount(Account account)
        {
            throw new System.NotImplementedException();
        }
    }
}