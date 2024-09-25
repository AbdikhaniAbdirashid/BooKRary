using book_loan.Data;
using book_loan.modals;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;
        public PublisherController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        [HttpGet]
        public IActionResult AllPublishers()
        {
            var _data4= _appDBContext.library.ToList();
            return Ok(_data4);


        }

        [HttpGet("id")]
        public IActionResult GetPublishersByID(int id)

        {
            var _data4 = _appDBContext.publisher.FirstOrDefault(x => x.ID == id);
            return Ok(_data4);
        }

        [HttpPost]
        public IActionResult addPublisher(publisher data4)
        {

            var _data4 = new publisher()
            {
                Name = data4.Name,
                Edition = data4.Edition,
                PrintingCountry = data4.PrintingCountry


            };
            _appDBContext.publisher.Add(_data4);

            _appDBContext.SaveChanges();
            ;
            return Ok(data4);
        }

        [HttpPut]

        public IActionResult updateAuthorById(int id, publisher data4)
        {


            var _data4 = _appDBContext.publisher.FirstOrDefault(x => x.ID == id);

            if (_data4 != null)
            {

                data4.Name = data4.Name;
                data4.Edition = data4.Edition;
                data4.PrintingCountry = data4.PrintingCountry;





                _appDBContext.publisher.Update(data4);
                _appDBContext.SaveChanges();
            }
            return Ok(data4);

        }
        [HttpDelete("id")]
        public IActionResult deletePublisherById(int id)
        {

            var _data4 = _appDBContext.publisher.FirstOrDefault(x => x.ID == id);

            if (_data4 != null)
            {
                _appDBContext.publisher.Update(_data4);
                _appDBContext.SaveChanges();
            }
            return Ok(id);




        }

        }
}
