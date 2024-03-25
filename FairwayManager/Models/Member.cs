using System;
using System.ComponentModel.DataAnnotations;

namespace FairwayManager.Models
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Member
    {
        [Key]
        public int MembershipID { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Please enter a name between 5 and 30 characters long.")]
        public string Name { get; set; }

        public Sex Sex { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Range(0, 54, ErrorMessage = "Please enter a handicap between 0 and 54.")]
        public int Handicap { get; set; }
    }
}
