// 頁面
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Pages")]
    public class Pages : IModel
    {
        // Constructor
        public Pages()
        {
        }

        #region 屬性
        [Key]
        [MaxLength(10)]
        public string? PageID { get; set; }

        [MaxLength(10)]
        public string? MenuID { get; set; }

        [MaxLength(35)]
        public string? PageName { get; set; }

        [MaxLength(10)]
        public string? PageUrl { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("MenuID"), InverseProperty("Pages")]
        public virtual Menus? Menu { get; set; }

        [ForeignKey("Creator"), InverseProperty("PagesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("PagesModifer")]
        public virtual Members? ModifyMember { get; set; }

        #endregion
    }
}