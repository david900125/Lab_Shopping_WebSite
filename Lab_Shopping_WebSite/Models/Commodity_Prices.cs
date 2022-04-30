// 商品價格
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Commodity_Prices")]
    public class Commodity_Prices : IModel
    {
        // Constructor
        public Commodity_Prices()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "Commodity_PriceID is required")]
        public int Commodity_PriceID { get; set; }
        [Required]
        public int CommodityID { get; set; }
        [Required]
        public int PriceID { get; set; }
        public decimal Price { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("CommodityPricesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CommodityPricesModifer")]
        public virtual Members? ModifyMember { get; set; }

        [ForeignKey("CommodityID"), InverseProperty("Commodity_Prices")]
        public virtual Commodities? commodity { get; set; }

        [ForeignKey("PriceID"), InverseProperty("Commodity_Prices")]
        public virtual Prices? PriceTag { get; set; }
        #endregion
    }
}
