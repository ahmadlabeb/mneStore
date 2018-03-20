using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mneStore.Models
{
    public class brand
    {
        public int id { get; set; }
        [Required]
        public string nameBrand { get; set; }
        public virtual ICollection<items> items { get; set; }
    }
}