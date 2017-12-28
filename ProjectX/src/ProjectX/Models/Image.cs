using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime UploadTime { get; set; }
        [ForeignKey("User")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
