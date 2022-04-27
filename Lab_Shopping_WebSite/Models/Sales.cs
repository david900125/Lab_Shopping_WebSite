// 訂單
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Sales")]
    public class Sales : IModel
    {
        // Constructor
        public Sales()
        {
        }

        #region 屬性
        [Key]
        [MaxLength(12)]
        [Required(ErrorMessage = "SaleID is required")]
        public string? SaleID { get; set; }

        [Precision(10, 2)]
        [Required(ErrorMessage = "Discount_Total is required")]
        public int Discount_Total { get; set; }

        [Precision(10, 2)]
        [Required(ErrorMessage = "Total_Price is required")]
        public int Total_Price { get; set; }

        [MaxLength(35)]
        [Required(ErrorMessage = "Total_Price is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "MemberID is required")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "PaymentID is required")]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Delivery_optionID is required")]
        public int Delivery_optionID { get; set; }

        [Precision(7, 2)]
        [Required(ErrorMessage = "Delivery_Cost is required")]
        public decimal Delivery_Cost { get; set; }

        [MaxLength(9)]
        public string? InVoice { get; set; }

        [Required(ErrorMessage = "InVoice is required.")]
        public DateTime Established { get; set; }

        public DateTime SendDate { get; set; }

        [Required(ErrorMessage = "isChecked is required")]
        public bool isChecked { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("MemberID"), InverseProperty("Sales")]
        public virtual Members? Member { get; set; }

        [ForeignKey("PaymentID"), InverseProperty("Sales")]
        public virtual Payments? Payment { get; set; }

        [ForeignKey("Delivery_optionID"), InverseProperty("Sales")]
        public virtual Delivery_Options? Delivery_Option { get; set; }

        [ForeignKey("Creator"), InverseProperty("SalesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("SalesModifer")]
        public virtual Members? ModifyMember { get; set; }
        public ICollection<Coupon_Uses>? Coupon_Uses { get; set; }

        public ICollection<Inventories>? Inventories { get; set; }
        public ICollection<Sales_items>? Sales_items { get; set; }
        #endregion
    }
}