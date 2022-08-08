namespace ForingProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("UserRole")]
    public partial class UserRole
    {
        public int Id { get; set; }
        [DisplayName("User Mail")]
        public int UserId { get; set; }

        [Column("UserRole")]
        [Required]
        [StringLength(50)]
        [DisplayName("Select Role")]
        public string Role { get; set; }
        [NotMapped]
        public List<user> UserCollection { get; set; }

        public virtual user user { get; set; }
    }
}
