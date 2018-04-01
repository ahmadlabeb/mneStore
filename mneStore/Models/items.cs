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
        [Display(Name = "nameItem",ResourceType =typeof(Resource))]
        public int idNameItems { get; set; }
        [Required]
        [Display(Name ="description",ResourceType =typeof(Resource))]
        public string description { get; set; }
        //[Required]
        //[DisplayName("الماركة")]
        //public string brand { get; set; }
        [Display(Name ="serialNamber", ResourceType = typeof(Resource))]
        public string serialNamber { get; set; }
        [Display(Name ="barcode", ResourceType = typeof(Resource))]
        public string barcode { get; set; }


        [Required]
        [Display(Name ="quantity", ResourceType = typeof(Resource))]
        public double quantity { get; set; }
        [Required]
        [Display(Name ="price", ResourceType = typeof(Resource))]
        public decimal price { get; set; }
        [ForeignKey("idNameItems")]
        public virtual NameItems nameItem { get; set; }

        public int billsId { get; set; }
        [Display(Name ="KindsId", ResourceType = typeof(Resource))]
        public int KindsId { get; set; }
        public virtual bills bills { get; set; }
        [ForeignKey("KindsId")]
        public virtual Kinds kinds { get; set; }

        [Required]
        [Display(Name ="UnitItemsId", ResourceType = typeof(Resource))]
        public int UnitItemsId { get; set; }


        [ForeignKey("UnitItemsId")]
        public virtual UnitItems unititems { get; set; }
        [Required]
        [Display(Name="brandId", ResourceType = typeof(Resource))]
        public int brandId { get; set; }
        [ForeignKey("brandId")]
        public virtual brand brands { get; set; }

    }
}