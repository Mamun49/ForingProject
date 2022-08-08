namespace ForingProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("First Name : ")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Last Name : ")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Mobile Number : ")]
        public int? MobileNo { get; set; }

        [StringLength(50)]
        [DisplayName("Address : ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Valid Mail : ")]
        public string Mail { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Birth : ")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        [DisplayName("Gender : ")]
        public string Gender { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Confirm Password : ")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        [StringLength(50)]
        [DisplayName("Membership Status : ")]
        public string MemberStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
