using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace store.Models
{
    public class storeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public storeContext() : base("name=storeContext")
        {
        }

        public System.Data.Entity.DbSet<store.Models.bills> bills { get; set; }

        public System.Data.Entity.DbSet<store.Models.Curruncies> Curruncies { get; set; }

        public System.Data.Entity.DbSet<store.Models.items> items { get; set; }

        public System.Data.Entity.DbSet<store.Models.Kinds> Kinds { get; set; }
    }
}
