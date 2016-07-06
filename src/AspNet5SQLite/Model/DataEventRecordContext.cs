using Microsoft.EntityFrameworkCore;

namespace AspNet5SQLite.Model
{
    /// <summary>
    /// dotnet . ef migration add testMigration
    /// </summary>
    public class DataEventRecordContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
	    public DataEventRecordContext(DbContextOptions<DataEventRecordContext> options) :base(options)
        { }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<DataEventRecord> DataEventRecords { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.Entity<DataEventRecord>().HasKey(m => m.Id); 
            base.OnModelCreating(builder); 
        } 
    }
}