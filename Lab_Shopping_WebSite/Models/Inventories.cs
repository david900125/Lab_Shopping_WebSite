// 庫存
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Inventories")]
    public class Inventories : IModel
    {
        // Constructor
        public Inventories()
        {
        }

        #region 屬性
        [Key]
        public int InventoryID { get; set; }

        [Required]
        public int Commodity_SizeID { get; set; }

        [Required]
        public bool Increase_Decrease { get; set; }

        [MaxLength(12)]
        public string? SaleID { get; set; }

        [Precision(6, 2)]
        [Required]
        public decimal Amount { get; set; }

        [Precision(10, 2)]
        [Required]
        public decimal Total_Amount { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Commodity_SizeID"), InverseProperty("inventories")]
        public virtual Commodity_Sizes? Commodity_Sizes { get; set; }

        [ForeignKey("SaleID"), InverseProperty("Inventories")]
        public virtual Sales? Sale { get; set; }

        [ForeignKey("Creator"), InverseProperty("InventoriesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("InventoriesModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}