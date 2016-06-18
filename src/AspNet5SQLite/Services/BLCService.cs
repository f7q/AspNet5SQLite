using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using AspNet5SQLite.Repositories;
using AspNet5SQLite.Model;

namespace AspNet5SQLite.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class BLCService : IBLCService
    {
        private readonly ILogger _logger;
        private readonly IDataEventRecordRepository _dataEventRecordRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataEventRecordRepository"></param>
        /// <param name="loggerFactory"></param>
        public BLCService(IDataEventRecordRepository dataEventRecordRepository, ILoggerFactory loggerFactory)
        {
            _dataEventRecordRepository = dataEventRecordRepository;
            _logger = loggerFactory.CreateLogger("BLCService");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DataEventRecord> GetAll()
        {
            _logger.LogCritical("Getting a the existing records");
            return _dataEventRecordRepository.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataEventRecord Get(long id)
        {
            _logger.LogCritical("--------------------------");
            return _dataEventRecordRepository.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataEventRecord"></param>
        public void Post(DataEventRecord dataEventRecord)
        {
            _logger.LogCritical("--------------------------");
            _dataEventRecordRepository.Post(dataEventRecord);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataEventRecord"></param>
        public void Put(long id, DataEventRecord dataEventRecord)
        {
            _logger.LogCritical("--------------------------");
            _dataEventRecordRepository.Put(id, dataEventRecord);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            _logger.LogCritical("--------------------------");
            _dataEventRecordRepository.Delete(id);
        }
    }
}
