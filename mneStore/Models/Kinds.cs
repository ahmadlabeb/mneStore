using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mneStore.Models
{
    public class Kinds
    {
        public int id { get; set; }
        [Required]
        [DisplayName("نوع لعنصر")]
        public string nameKind { get; set; }

        public virtual ICollection<items> item { get; set; }
    }
}