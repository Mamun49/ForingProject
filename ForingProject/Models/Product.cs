namespace ForingProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [StringLength(50)]
        [DisplayName("Product Name : ")]
        public string ProductName { get; set; }

        [StringLength(50)]
        [DisplayName("Product Price : ")]
        public string ProductPrice { get; set; }

        [StringLength(50)]
        [DisplayName("Product Type : ")]
        public string ProductType { get; set; }
    }
}
