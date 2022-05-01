// 複合主鍵
// 訂單內容
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Sales_items")]
    public class Sales_items : IModel
    {
        // Constructor
        public Sales_items()
        {
        }

        #region 屬性
        [Required]
        [MaxLength(12)]
        public string SaleID { get; set; }

        [Required]
        public int Commodity_SizeID { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Amount { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Unit_Price { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Total_Price { get; set; }

        public int StatusID { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("SalesitemsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("SalesitemsModifer")]
        public virtual Members? ModifyMember { get; set; }

        [ForeignKey("SaleID"), InverseProperty("Sales_items")]
        public virtual Sales? Sale { get; set; }

        [ForeignKey("Commodity_SizeID"), InverseProperty("Sales_Items")]
        public virtual Commodity_Sizes? Commodity_Size { get; set; }

        [ForeignKey("StatusID"), InverseProperty("Sales_items")]
        public virtual Status? Status { get; set; }
        #endregion
    }
}