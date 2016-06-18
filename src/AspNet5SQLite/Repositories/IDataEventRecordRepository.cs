using System.Collections.Generic;
using AspNet5SQLite.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNet5SQLite.Repositories
{

    /// <summary>
    /// 
    /// </summary>
    public interface IDataEventRecordRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DataEventRecord Get(long id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<DataEventRecord> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataEventRecord"></param>
        void Post(DataEventRecord dataEventRecord);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataEventRecord"></param>
        void Put(long id, [FromBody] DataEventRecord dataEventRecord);
    }
}