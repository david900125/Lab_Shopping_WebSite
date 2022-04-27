// 複合主鍵
// 商品圖片
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Commodity_Images")]
    public class Commodity_Images : IModel
    {
        // Constructor
        public Commodity_Images()
        {
        }

        #region 屬性
        [Required(ErrorMessage = "CommodityID is required")]
        public int CommodityID { get; set; }

        [Required]
        public int? FileID { get; set; }

        [Required]
        public int Order { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("CommodityID"), InverseProperty("Images")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("FileID"), InverseProperty("Commodity_Images")]
        public virtual Files? File { get; set; }

        [ForeignKey("Creator"), InverseProperty("CommodityImagesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CommodityImagesModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}
