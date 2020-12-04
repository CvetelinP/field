namespace FieldPlatformWeb.ViewModels.Admin
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
