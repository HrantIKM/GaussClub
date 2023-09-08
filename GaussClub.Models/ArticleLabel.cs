namespace GaussClub.Models
{
    public class ArticleLabel
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int LabelId { get; set; }
        public Label Label { get; set; }
    }
}
