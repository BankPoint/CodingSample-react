using CodingSample.Model;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CodingSample.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private IDbService _dbService;
        private ListHelper _listHelper;

        public LoansController(IDbService dbService, ListHelper listHelper)
        {
            _dbService = dbService;
            _listHelper = listHelper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var loans = _dbService.GetLoans();
            var data = _listHelper.GetListResults(loans, new ListSettings());
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(IFormFile formFile)
        {
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var loans = csv.GetRecords<LoanFileRecord>().ToList();
                _dbService.AddLoans(loans);
                return Ok($"Successfully uploaded {loans.Count} loans");
            }
        }
    }
}
