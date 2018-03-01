using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mneStore.Models
{
    public class mneStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public mneStoreContext() : base("name=mneStoreContext")
        {
        }

        public System.Data.Entity.DbSet<mneStore.Models.bills> bills { get; set; }

        public System.Data.Entity.DbSet<mneStore.Models.items> items { get; set; }
        public System.Data.Entity.DbSet<mneStore.Models.Curruncies> curruncies { get; set; }
        public System.Data.Entity.DbSet<mneStore.Models.Kinds> kinds { get; set; }

    }
}
