// 複合主鍵
// 領取優惠券
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Received_Coupons")]
    public class Received_Coupons : IModel
    {
        // Constructor
        public Received_Coupons()
        {
        }

        #region 屬性
        [Required]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Payment is required.")]
        public int CouponID { get; set; }

        [Required]
        [Precision(5, 2)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Received_Date { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }
        [ForeignKey("MemberID"), InverseProperty("Received_Coupons")]
        public virtual Members? Member { get; set; }

        [ForeignKey("CouponID"), InverseProperty("Received_Coupons")]
        public virtual Coupons? Coupon { get; set; }

        [ForeignKey("Creator"), InverseProperty("ReceivedCouponsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("ReceivedCouponsModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}