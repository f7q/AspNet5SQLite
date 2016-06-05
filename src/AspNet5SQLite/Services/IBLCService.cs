using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNet5SQLite.Model;
namespace AspNet5SQLite.Services
{
    public interface IBLCService
    {
        void Delete(long id);
        DataEventRecord Get(long id);
        List<DataEventRecord> GetAll();
        void Post(DataEventRecord dataEventRecord);
        void Put(long id, DataEventRecord dataEventRecord);

    }
}
