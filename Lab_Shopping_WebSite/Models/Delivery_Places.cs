// 運送地區
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Delivery_Places")]
    public class Delivery_Places : IModel
    {
        // Constructor
        public Delivery_Places()
        {
        }

        #region 屬性
        [Key]
        [Required]
        public int Delivery_PlaceID { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Delivery_Place { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("DeliveryPlacesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("DeliveryPlacesModifer")]
        public virtual Members? ModifyMember { get; set; }

        public ICollection<Delivery_Options>? Delivery_Options { get; set; }
        #endregion
    }
}