using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mneStore.Models
{
    public class DescriptionKinds
    {
        public int id { get; set; }
        [Required]
        [DisplayName("ملاحظات")]
        public string description { get; set; }
        public int KindsId { get; set; }
        public int itemsId { get; set; }
        [ForeignKey("KindsId")]
        public virtual Kinds kinds { get; set; }
        [ForeignKey("itemsId")]
        public virtual items items { get; set; }
    }
}