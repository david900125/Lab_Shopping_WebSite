// 價格分類
// 商品價格
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Prices")]
    public class Prices : IModel
    {
        // Constructor
        public Prices()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "PriceID is required.")]
        public int PriceID { get; set; }
        public string? Price { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("PricesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("PricesModifer")]
        public virtual Members? ModifyMember { get; set; }
        public ICollection<Commodity_Prices>? Commodity_Prices { get; set; }
        #endregion
    }
}
