namespace GaussClub.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }
        void Save();
    }
}
