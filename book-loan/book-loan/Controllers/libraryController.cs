using book_loan.Data;
using book_loan.modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace book_loan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class libraryController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;
        public libraryController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;


        }


        [HttpGet]
        public IActionResult AllLibraries()
        {
            var _data3 = _appDBContext.library.ToList();
            return Ok(_data3);


        }

        [HttpGet("id")]
        public IActionResult GetLibrariessByID(int id)

        {
            var _data3 = _appDBContext.library.FirstOrDefault(x => x.Id == id);
            return Ok(_data3);
        }
        [HttpPost]
        public IActionResult addLibrary(library data3)
        {

            var _data3 = new library()
            {

                store = data3.store,
                Available = data3.Available,
                amount = data3.amount,

            };

            _appDBContext.library.Add(_data3);

            _appDBContext.SaveChanges();
            ;
            return Ok(data3);

        }
        [HttpPut]
        public IActionResult updateLibraryById(int id, library data3)
        {
            var _data3 = _appDBContext.authors.FirstOrDefault(x => x.ID == id);

            if (_data3 != null)
            {
                data3.store = data3.store;
                data3.Available = data3.Available;
                data3.amount = data3.amount;

                _appDBContext.library.Update(data3);
                _appDBContext.SaveChanges();

            }
            return Ok(data3);
        }

        [HttpDelete("id")]
        public IActionResult deleteALibraryById(int id)
        {

            var _data3 = _appDBContext.library.FirstOrDefault(x => x.Id == id);

            if (_data3 != null)
            {
                _appDBContext.library.Update(_data3);
                _appDBContext.SaveChanges();
            }
            return Ok(id);





        }
    }
}
