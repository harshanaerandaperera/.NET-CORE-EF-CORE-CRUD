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

        /// <summary>
        /// Name Of the user
        /// </summary>
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Age of the user
        /// </summary>
        [Range(1, 121)]
        public int Age { get; set; }

        /// <summary>
        /// Phone number of the user
        /// </summary>
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Id of the user
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
