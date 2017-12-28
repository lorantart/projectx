using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Images = new List<Image>();
            ImageProfiles = new List<ImageProfile>();
        }
        public string LegacyId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public string LegacyPassword { get; set; }
        public string Address { get; set; }
        public DateTime Premium { get; set; }
        public bool Newsletter { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public string Avatar { get; set; }
        public string BillingName { get; set; }
        public string BillingAddress { get; set; }
        public string BankAccountNum { get; set; }
        public int Balance { get; set; }
        public string FacebookProfile { get; set; }
        public string InstagramProfile { get; set; }
        public string Website { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<ImageProfile> ImageProfiles { get; set; }
    }
}
