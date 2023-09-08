namespace GaussClub.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }
        IArticleRepository ArticleRepository { get; }
        ILabelRepository LabelRepository { get; }
        void Save();
    }
}
