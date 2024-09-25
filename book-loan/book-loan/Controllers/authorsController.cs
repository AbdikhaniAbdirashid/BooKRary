using book_loan.Data;
using book_loan.modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authorsController : ControllerBase
    {

        private readonly AppDBContext _appDBContext;
        public authorsController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public IActionResult AllAuthors()
        {
            var _data2 = _appDBContext.authors.ToList();
            return Ok(_data2);


        }

        [HttpGet("id")]
        public IActionResult GetAuthorsByID(int id)

        {
            var _data2 = _appDBContext.authors.FirstOrDefault(x => x.ID == id);
            return Ok(_data2);
        }
        [HttpPost]
        public IActionResult addAuthor(authors data2)
        {

            var _data2 = new authors()
            {
                firstName = data2.firstName,

                lastName = data2.lastName,
                age = data2.age,
                ImageCoverUrl = data2.ImageCoverUrl,

                biografi = data2.biografi,

                nationality = data2.nationality


            };
            _appDBContext.authors.Add(_data2);

            _appDBContext.SaveChanges();
            ;
            return Ok(data2);
        }

        [HttpPut]

        public IActionResult updateAuthorById(int id, authors data2) {


            var _data2 = _appDBContext.authors.FirstOrDefault(x => x.ID == id);

            if (_data2 != null)
            {


                data2.firstName = data2.firstName;

                data2.lastName = data2.lastName;
                data2.age = data2.age;
                data2.ImageCoverUrl = data2.ImageCoverUrl;

                data2.biografi = data2.biografi;

                data2.nationality = data2.nationality;
              
                _appDBContext.authors.Update(data2);
                _appDBContext.SaveChanges();
            }
           return Ok(data2);

        }
        [HttpDelete("id")]
        public IActionResult deleteAuthorById(int id)
        {

            var _data2 = _appDBContext.authors.FirstOrDefault(x => x.ID == id);

            if (_data2 != null)
            {
                _appDBContext.authors.Update(_data2);
                _appDBContext.SaveChanges();
            }
            return Ok(id);

        }
        
         

    }
}



