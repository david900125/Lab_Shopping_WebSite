// 複合主鍵
// 優惠券
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Coupons")]
    public class Coupons : IModel
    {
        // Constructor
        public Coupons()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "CouponID is required")]
        public int CouponID { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Coupon_Key is required")]
        public string? Coupon_Key { get; set; }

        [MaxLength(255)]
        public string? Coupon_Title { get; set; }

        [MaxLength(255)]
        public string? Coupon_Content { get; set; }

        [Required(ErrorMessage = "Coupon_WayID is required.")]
        public int Coupon_WayID { get; set; }

        [Precision(7, 2)]
        public decimal Amount_Achieved { get; set; }

        [Precision(7, 2)]
        public decimal Discount { get; set; }

        public int? Issued_Amount { get; set; }

        [Required]
        public DateTime Issued_Date { get; set; }
        public DateTime End_Date { get; set; }

        [Required]
        public bool isIssued { get; set; }

        [Required]
        public int Received_Amount { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Coupon_WayID"), InverseProperty("Coupons")]
        public Coupon_Ways? Coupon_Ways { get; set; }

        [ForeignKey("Creator"), InverseProperty("CouponsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CouponsModifer")]
        public virtual Members? ModifyMember { get; set; }
        public ICollection<Coupon_Uses>? Coupon_Uses { get; set; }
        public ICollection<Received_Coupons>? Received_Coupons { get; set; }
        #endregion
    }
}