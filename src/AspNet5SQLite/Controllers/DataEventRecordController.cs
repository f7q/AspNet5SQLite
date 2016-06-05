using System.Collections.Generic;
using AspNet5SQLite.Model;
using AspNet5SQLite.Repositories;
using Microsoft.AspNetCore.Mvc;
using AspNet5SQLite.Services;
using Microsoft.Extensions.Logging;
namespace AspNet5SQLite.Controllers
{
    [Route("api/[controller]")]
    public class DataEventRecordsController : Controller
    {
        private readonly IBLCService _BLCService;
        private readonly ILogger _logger;

        public DataEventRecordsController(IBLCService bLCService, ILoggerFactory loggerFactory)
        {
            _BLCService = bLCService;
            _logger = loggerFactory.CreateLogger("DataEventRecordsController");
        }

        [HttpGet]
        public IEnumerable<DataEventRecord> Get()
        {
            _logger.LogCritical("::::");
            return _BLCService.GetAll();
        }

        [HttpGet("{id}")]
        public DataEventRecord Get(long id)
        {
            _logger.LogCritical("::::");
            return _BLCService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]DataEventRecord value)
        {
            _logger.LogCritical("::::");
            _BLCService.Post(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]DataEventRecord value)
        {
            _logger.LogCritical("::::");
            _BLCService.Put(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _logger.LogCritical("::::");
            _BLCService.Delete(id);
        }
    }
}
