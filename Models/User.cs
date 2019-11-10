using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        
        [Range(1,121)]
        public int  Age { get; set; }
        
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
