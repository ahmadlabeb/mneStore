using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mneStore.Models
{
    public class brand
    {
        public int id { get; set; }
        public string nameBrand { get; set; }
        public virtual ICollection<items> items { get; set; }
    }
}