namespace Mission11_Nance.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
