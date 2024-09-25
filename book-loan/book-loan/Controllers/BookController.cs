using book_loan.Data;
using book_loan.modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public BookController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            
        }

        [HttpGet]
        public IActionResult GETALLBooks()
        {
            var _data = _appDBContext.Books.ToList();

            return Ok(_data);
        }

        [HttpGet("id")]
        public IActionResult GetBookBYID(int id)
        {
            var _data = _appDBContext.Books.FirstOrDefault(x => x.Id == id);
                return Ok(_data);
        }

        [HttpPost]

        public IActionResult AddBook(Book data)
        {
            var _data = new Book()
            {
                BookName = data.BookName,
                ImageCoverURL = data.ImageCoverURL,
                Author = data.Author,
                Available = data.Available,
                DateAdded = data.DateAdded



            };

            _appDBContext.Books.Add(_data);
            _appDBContext.SaveChanges();

            return Ok(_data);





            }
       
        
        [HttpPut] 
        public IActionResult UpdateBookById(int id,Book data)
        { 

           var _data = _appDBContext.Books.FirstOrDefault(x => x.Id == id);

            if (_data != null) {

              _data.BookName = data.BookName;
               _data.ImageCoverURL = data.ImageCoverURL;
               _data.Author = data.Author;
               _data.Available = data.Available;
               _data.DateAdded = data.DateAdded;

                _appDBContext.Books.Update(_data);
                _appDBContext.SaveChanges();

            }
            return Ok(_data);
        }
       
        
        [HttpDelete("id")]
        public IActionResult DeleteBookByID(int id)
        {
            var _data = _appDBContext.Books.FirstOrDefault(x => x.Id == id);

            if (_data !=null)
            {
                _appDBContext.Books.Remove(_data);
                _appDBContext.SaveChanges();
            }
            return Ok();
        }


    }
}
