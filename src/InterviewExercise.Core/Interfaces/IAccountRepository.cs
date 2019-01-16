namespace InterviewExercise.Core
{
    using Models;

    public interface IAccountRepository
    {
        Account[] GetAccounts(int memberId);
    }
}