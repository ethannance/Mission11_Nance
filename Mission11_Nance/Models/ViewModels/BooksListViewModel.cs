namespace Mission11_Nance.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IQueryable<Book> Books { get; set;}
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    }
}
