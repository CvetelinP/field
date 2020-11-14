namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System.ComponentModel.DataAnnotations;

    public class PromoterGroupInputModel
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
