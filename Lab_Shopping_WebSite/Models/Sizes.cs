// 尺寸
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Sizes")]
    public class Sizes : IModel
    {
        // Constructor
        public Sizes()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "SizeID is required")]
        public int SizeID { get; set; }
        [Required(ErrorMessage = "Commodity_KindsID is required.")]
        public int Commodity_KindsID { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "欄位最大10")]
        public string? Size { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Commodity_KindsID"), InverseProperty("Sizes")]
        public virtual Commodity_Kinds? Commodity_Kinds { get; set; }

        [ForeignKey("Creator"), InverseProperty("SizesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("SizesModifer")]
        public virtual Members? ModifyMember { get; set; }
        public virtual ICollection<Commodity_Sizes>? Commodity_Sizes { get; set; }
        #endregion
    }
}
