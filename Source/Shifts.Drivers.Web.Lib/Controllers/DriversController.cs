using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Dapper;
using Shifts.Drivers.Contracts;

namespace Shifts.Drivers.Web.Lib.Controllers
{
    //[RoutePrefix("drivers")]
    [Route("drivers")]
    public class DriversController : ApiController
    {
        public IHttpActionResult Get()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["shiftDriversDb"].ConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return Ok(db.Query<Driver>("Select * From Drivers").ToList());
            }
        }
    }
}