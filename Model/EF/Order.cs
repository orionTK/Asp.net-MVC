namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Deverilies = new HashSet<Deverily>();
        }

        [StringLength(100)]
        public string OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? QuestionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ConfirmDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FinishDate { get; set; }

        [StringLength(100)]
        public string OrderFrom { get; set; }

        [StringLength(100)]
        public string ProductID { get; set; }

        public int? CustomerID { get; set; }

        public int? SaleID { get; set; }

        [Column(TypeName = "text")]
        public string Status { get; set; }

        public int? QuantityReq { get; set; }

        public int? WarehouseID { get; set; }

        public int? PriorityID { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deverily> Deverilies { get; set; }

        public virtual Product Product { get; set; }

        public virtual Prority Prority { get; set; }

        public virtual User User { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
