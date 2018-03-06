using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mneStore.Models
{
    public class items
    {
        public int id { get; set; }
        [Required]
        [DisplayName("اسم العنصر")]
        public string nameItem { get; set; }
        [Required]
        [DisplayName("وصف العنصر")]
        public string description { get; set; }
        [Required]
        [DisplayName("brand")]
        public string brand { get; set; }
        [Required]
        [DisplayName("الرقم التسلسلي")]
        public string serialNamber { get; set; }
        [Required]
        [DisplayName("قارئ الباركود")]
        public string barcode { get; set; }


        [Required]
        [DisplayName("الكمية رقماً")]
        public double quantity { get; set; }
        [Required]
        [DisplayName("سعر الوحدة")]
        public decimal price { get; set; }


        public int billsId { get; set; }
        [DisplayName("نوع العنصر")]
        public int KindsId { get; set; }

        public virtual bills bills { get; set; }
        [ForeignKey("KindsId")]
        public virtual Kinds kinds { get; set; }
        [Required]
        [DisplayName("الوحدة")]
        public int UnitItemsId { get; set; }
        [ForeignKey("UnitItemsId")]
        public virtual UnitItems unititems { get; set; }
    }
}