using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace store.Models
{
    public class bills
    {
        public int id { get; set; }
        [Required]
        [DisplayName("جهة الشراء")]
        public string nameBuy { get; set; }
        [Required]
        [DisplayName("رقم الفاتورة")]
        public string billNumber { get; set; }
        [Required]
        [DisplayName("تاريخ الفاتورة")]
        public DateTime dateBill { get; set; }
        [DisplayName("العملة")]
        public int currunciesId { get; set; }
        public virtual Curruncies curruncies { get; set; }

        public virtual ICollection<items> items { get; set; }
    }
}