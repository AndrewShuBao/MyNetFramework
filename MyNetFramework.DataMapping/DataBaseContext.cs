using System.Data.Entity;

namespace MyNetFramework.DataMapping
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("Name=MyNetFramework")
        {
            Database.SetInitializer<DataBaseContext>(null);
        }

    }
}
