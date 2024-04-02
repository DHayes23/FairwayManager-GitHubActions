using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FairwayManager.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        [Display(Name = "Tee Time")]
        public DateTime TeeTime { get; set; }

        [Required]
        [Display(Name = "Player One Membership ID")]
        public int PlayerOneMembershipID { get; set; }
        [ForeignKey("PlayerOneMembershipID")]
        public Member PlayerOne { get; set; }

        [Display(Name = "Player Two Membership ID")]
        public int? PlayerTwoMembershipID { get; set; }
        [ForeignKey("PlayerTwoMembershipID")]
        public Member PlayerTwo { get; set; }

        [Display(Name = "Player Three Membership ID")]
        public int? PlayerThreeMembershipID { get; set; }
        [ForeignKey("PlayerThreeMembershipID")]
        public Member PlayerThree { get; set; }

        [Display(Name = "Player Four Membership ID")]
        public int? PlayerFourMembershipID { get; set; }
        [ForeignKey("PlayerFourMembershipID")]
        public Member PlayerFour { get; set; }
    }
}
