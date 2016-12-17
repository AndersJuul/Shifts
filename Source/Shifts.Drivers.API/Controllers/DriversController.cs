using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Shifts.Drivers.Contracts;
using Dapper;

namespace Shifts.Drivers.API.Controllers
{
    [Route("api/[controller]")]
    public class DriversController : Controller
    {
        private AppSettings _appSettings;

        public DriversController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "driver";
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Driver driver)
        {
            var connection = new SqlConnection
            {
                ConnectionString = _appSettings.ConnectionString
            };
            await connection
                .OpenAsync(CancellationToken.None)
                .ConfigureAwait(false);

            await connection
                .ExecuteAsync("insert into Drivers (Name) values (@Name)", driver, null, 10);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}