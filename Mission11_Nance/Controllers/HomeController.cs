using Microsoft.AspNetCore.Mvc;
using Mission11_Nance.Models;
using Mission11_Nance.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Nance.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum, string? bookType)
        {
            int pageSize = 3;

            var blah = new BooksListViewModel
            {
                Books = _repo.Books
                .Where(x => x.Classification == bookType || bookType == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = bookType == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Classification == bookType).Count()
                },

                CurrentBookType = bookType
            };


            return View(blah);
        }

    }
}
