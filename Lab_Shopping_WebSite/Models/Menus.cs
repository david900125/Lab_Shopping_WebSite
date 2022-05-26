// 選單
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Menus")]
    public class Menus : IModel
    {
        // Constructor
        public Menus()
        {
        }

        #region 屬性
        [Key]
        [MaxLength(10)]
        public string? MenuID { get; set; }

        [MaxLength(35)]
        public string? MenuName { get; set; }

        [MaxLength(10)]
        public string? MenuUrl { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("MenusCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("MenusModifer")]
        public virtual Members? ModifyMember { get; set; }

        public virtual ICollection<Pages>? Pages { get; set; }
        #endregion
    }
}