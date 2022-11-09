namespace Mot_Denis_Lab_2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public ICollection<BookCategory>? BookCategories { get; internal set; }
    }
}

