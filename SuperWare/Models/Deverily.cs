namespace SuperWare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deverily")]
    public partial class Deverily
    {
        public int DeverilyID { get; set; }

        public DateTime? DeverilyDate { get; set; }

        public int? QuanityDeverily { get; set; }

        [StringLength(100)]
        public string OderID { get; set; }

        public virtual Order Order { get; set; }
    }
}
