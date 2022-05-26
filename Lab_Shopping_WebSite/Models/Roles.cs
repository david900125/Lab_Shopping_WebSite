// Roles 角色
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Roles")]
    public class Roles : IModel
    {
        public Roles()
        {
        }

        [Key]
        [Required]
        public int RoleID { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("RolesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("RolesModifer")]
        public virtual Members? ModifyMember { get; set; }

        public virtual ICollection<Members>? Members { get; set; }
    }
}