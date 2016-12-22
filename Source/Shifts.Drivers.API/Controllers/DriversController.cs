using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using Shifts.Drivers.Contracts;

namespace Shifts.Drivers.API.Controllers
{
    public class DriversController : ApiController
    {
        private readonly ConnectionStringSettings _connectionString;

        public DriversController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appcon"];
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "driver";
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Driver driver)
        {
            var connection = new SqlConnection(_connectionString.ConnectionString);

            await connection
                .OpenAsync(CancellationToken.None)
                .ConfigureAwait(false);

            await connection
                .ExecuteAsync("insert into Drivers (Name) values (@Name)", driver, null, 10)
                .ConfigureAwait(false);

        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}