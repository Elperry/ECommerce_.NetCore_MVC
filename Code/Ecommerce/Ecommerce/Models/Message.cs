using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Texting { get; set; }
    }
}
