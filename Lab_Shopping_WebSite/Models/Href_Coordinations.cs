// 圖片商品連結位置
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Href_Coordinations")]
    public class Href_Coordinations : IModel
    {
        // Constructor
        public Href_Coordinations()
        {
        }

        #region 屬性
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Href_CoordinationID { get; set; }

        public int FileID { get; set; }

        [Precision(5, 2)]
        [Comment("CSS:Position Top")]
        public decimal? Top { get; set; }

        [Precision(5, 2)]
        [Comment("CSS:Position Right")]
        public decimal? Right { get; set; }

        [Precision(5, 2)]
        [Comment("CSS:Position Bottom")]
        public decimal? Bottom { get; set; }

        [Precision(5, 2)]
        [Comment("CSS:Position Left")]
        public decimal? Left { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("HrefCoordinationsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("HrefCoordinationsModifer")]
        public virtual Members? ModifyMember { get; set; }

        [ForeignKey("FileID"), InverseProperty("Href_Coordinations")]
        public virtual Files? File { get; set; }

        #endregion
    }
}