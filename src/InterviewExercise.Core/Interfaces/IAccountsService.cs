namespace InterviewExercise.Api
{
    using Core.Models;

    public interface IAccountsService
    {
        Account[] GetAccounts(int memberId);
    }
}