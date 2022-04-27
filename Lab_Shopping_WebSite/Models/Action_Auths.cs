// API 權限
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Action_Auths")]
    public class Action_Auths : IModel
    {
        // Constructor
        public Action_Auths()
        {
        }

        #region 屬性

        [Key]
        public int ActionID { get; set; }
        [Required]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Controller is Required.")]
        [StringLength(20, ErrorMessage = "欄位長度不可大於20個字元")]
        public string? Controller { get; set; }

        [Required(ErrorMessage = "Action is Required.")]
        [StringLength(20, ErrorMessage = "欄位長度不可大於20個字元")]
        public string? Action { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("RoleID")]
        public virtual Roles? Role { get; set; }

        [ForeignKey("Creator"), InverseProperty("Action_AuthCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("Action_AuthsModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}
