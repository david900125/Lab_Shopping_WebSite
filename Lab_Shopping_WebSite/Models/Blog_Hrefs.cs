// 複合主鍵
// Blog 連結
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Blog_Hrefs")]
    public class Blog_Hrefs : IModel
    {
        // Constructor
        public Blog_Hrefs()
        {
        }

        #region 屬性
        // 複合主鍵
        [Required]
        public int BlogID { get; set; }

        [Required]
        public int CommodityID { get; set; }

        [Required]
        public int Order { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("BlogID"), InverseProperty("Hrefs")]
        public virtual Blogs? Blog { get; set; }

        [ForeignKey("CommodityID"), InverseProperty("Blog_Hrefs")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("Creator"), InverseProperty("Blog_HrefsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("Blog_HrefsModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}
