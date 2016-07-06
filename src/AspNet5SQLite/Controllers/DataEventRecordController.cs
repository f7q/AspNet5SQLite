using System.Collections.Generic;
using AspNet5SQLite.Model;
using AspNet5SQLite.Repositories;
using Microsoft.AspNetCore.Mvc;
using AspNet5SQLite.Services;
using Microsoft.Extensions.Logging;
namespace AspNet5SQLite.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class DataEventRecordsController : Controller
    {
        private readonly IBLCService _BLCService;
        private readonly ILogger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bLCService"></param>
        /// <param name="loggerFactory"></param>
        public DataEventRecordsController(IBLCService bLCService, ILoggerFactory loggerFactory)
        {
            _BLCService = bLCService;
            _logger = loggerFactory.CreateLogger("DataEventRecordsController");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DataEventRecord> Get()
        {
            _logger.LogInformation("::::");
            return _BLCService.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public DataEventRecord Get(long id)
        {
            _logger.LogInformation("::::");
            return _BLCService.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]DataEventRecord value)
        {
            _logger.LogInformation("::::");
            _BLCService.Post(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]DataEventRecord value)
        {
            _logger.LogInformation("::::");
            _BLCService.Put(id, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _logger.LogInformation("::::");
            _BLCService.Delete(id);
        }
    }
}
