// 色彩
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Colors")]
    public class Colors : IModel
    {
        // Constructor
        public Colors()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "ColorID is required")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Required]
        public string Url { get; set; }

        [ForeignKey("Creator"), InverseProperty("ColorsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("ColorsModifer")]
        public virtual Members? ModifyMember { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        public virtual ICollection<Commodity_Sizes>? Commodity_Sizes { get; set; }
        #endregion
    }
}
