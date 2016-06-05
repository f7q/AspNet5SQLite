using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using AspNet5SQLite.Repositories;
using AspNet5SQLite.Model;

namespace AspNet5SQLite.Services
{
    public class BLCService : IBLCService
    {
        private readonly ILogger _logger;
        private readonly IDataEventRecordRepository _dataEventRecordRepository;
        public BLCService(IDataEventRecordRepository dataEventRecordRepository, ILoggerFactory loggerFactory)
        {
            _dataEventRecordRepository = dataEventRecordRepository;
            _logger = loggerFactory.CreateLogger("BLCService");
        }

        public List<DataEventRecord> GetAll()
        {
            _logger.LogCritical("Getting a the existing records");
            return _dataEventRecordRepository.GetAll();
        }

        public DataEventRecord Get(long id)
        {
            _logger.LogCritical("--------------------------");
            return _dataEventRecordRepository.Get(id);
        }

        public void Post(DataEventRecord dataEventRecord)
        {
            _logger.LogCritical("--------------------------");
            _dataEventRecordRepository.Post(dataEventRecord);
        }

        public void Put(long id, DataEventRecord dataEventRecord)
        {
            _logger.LogCritical("--------------------------");
            _dataEventRecordRepository.Put(id, dataEventRecord);
        }

        public void Delete(long id)
        {
            _logger.LogCritical("--------------------------");
            _dataEventRecordRepository.Delete(id);
        }
    }
}
