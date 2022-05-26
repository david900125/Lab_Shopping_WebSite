// 商品
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Commodities")]
    public class Commodities : IModel
    {
        // Constructor
        public Commodities()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "CommodityID is required")]
        public int CommodityID { get; set; }

        [Required]
        public string CommodityName { get; set; }

        [StringLength(250, ErrorMessage = "欄位長度不可大於250個字元")]
        public string? Description { get; set; }

        [StringLength(200, ErrorMessage = "欄位長度不可大於200個字元")]
        public string? Material { get; set; }

        [Required(ErrorMessage = "Commodity Released  is required.")]
        public bool isReleased { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("CommoditiesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CommoditiesModifer")]
        public virtual Members? ModifyMember { get; set; }
        public virtual ICollection<Blog_Hrefs>? Blog_Hrefs { get; set; }
        public virtual ICollection<Commodity_Images>? Images { get; set; }
        public virtual ICollection<Commodity_Prices>? Commodity_Prices { get; set; }
        public virtual ICollection<Commodity_Tags>? Commodity_Tags { get; set; }
        public virtual ICollection<Commodity_Sizes>? Commodity_Sizes { get; set; }
        public virtual ICollection<Like_Commodities>? Like_Commodities { get; set; }
        public virtual ICollection<Recently_Viewed>? Recently_Viewed { get; set; }
        #endregion
    }
}
