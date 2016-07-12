using System.Collections.Generic;
using System.Linq;
using AspNet5SQLite.Model;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Logging;

namespace AspNet5SQLite.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class DataEventRecordRepository : IDataEventRecordRepository
    {
        private readonly DataEventRecordContext _context;

        private readonly ILogger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggerFactory"></param>
        public DataEventRecordRepository(DataEventRecordContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger(nameof(DataEventRecordRepository));          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DataEventRecord> GetAll()
        {
            _logger.LogInformation("Getting a the existing records");
            return _context.DataEventRecords.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataEventRecord Get(long id)
        {
            _logger.LogInformation("::::--------------------------");
            return _context.DataEventRecords.First(t => t.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataEventRecord"></param>
        [HttpPost]
        public void Post(DataEventRecord dataEventRecord )
        {
            _logger.LogInformation("::::--------------------------");
            _context.DataEventRecords.Add(dataEventRecord);
            _context.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataEventRecord"></param>
        public void Put(long id, [FromBody]DataEventRecord dataEventRecord)
        {
            _logger.LogInformation("::::--------------------------");
            _context.DataEventRecords.Update(dataEventRecord);
            _context.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            _logger.LogInformation("::::--------------------------");
            var entity = _context.DataEventRecords.First(t => t.Id == id);
            _context.DataEventRecords.Remove(entity);
            _context.SaveChanges();
        }
    }
}
