using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class userrrr
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ID{ get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        public string firstName { get; set; }

        public string? lastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string contactNumber { get; set; }

        [Required]
        public roleName role { get; set; }

        [Required]
        public bool isActive { get; set; }

        public DateTime dob { get; set; }

        [Required]
        public DateTime createdOn { get; set; }
    }
}
