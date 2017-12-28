using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Models
{
    public class ImageProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Image Image { get; set; }

        [ForeignKey("User")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
