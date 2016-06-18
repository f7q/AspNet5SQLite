using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNet5SQLite.Model;
namespace AspNet5SQLite.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBLCService
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
        void Put(long id, DataEventRecord dataEventRecord);

    }
}
