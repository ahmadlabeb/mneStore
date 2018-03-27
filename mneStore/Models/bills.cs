using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mneStore.Models
{
    public class bills
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="nameBuy",ResourceType =typeof(Resource))]
        public string nameBuy { get; set; }
        [Required]
        [Display(Name = "billNumber", ResourceType = typeof(Resource))]
        public string billNumber { get; set; }
        [Required]
        [Display(Name = "dateBill", ResourceType = typeof(Resource))]
        public DateTime dateBill { get; set; }
        [Display(Name = "currunciesId", ResourceType = typeof(Resource))]
        public int currunciesId { get; set; }
        public virtual Curruncies curruncies { get; set; }

        public virtual ICollection<items> items { get; set; }
    }
    
}