namespace SuperWare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        [StringLength(100)]
        public string ProductID { get; set; }

        [StringLength(100)]
        public string Barcode { get; set; }

        public decimal? Quantity { get; set; }

        public double? Weight { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        [StringLength(200)]
        public string NameEnglish { get; set; }

        [StringLength(200)]
        public string NameVietNamese { get; set; }

        public int? MOQ { get; set; }

        public int? QuanityOPackage { get; set; }

        public int? PatternID { get; set; }

        public int PromotionID { get; set; }

        public int? CategoryID { get; set; }

        public bool? Status { get; set; }

        public int? ReqStockID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public DateTime? TimeCreated { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Pattern Pattern { get; set; }

        public virtual Promotion Promotion { get; set; }

        public virtual ReqStock ReqStock { get; set; }
    }
}
