using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace store.Models
{
    public class Curruncies
    {
        public int id { get; set; }
        [Required]
        [DisplayName("العملة")]
        public string nameUnit { get; set; }

        public virtual ICollection<bills> bill { get; set; }
    }
}