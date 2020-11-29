namespace AspNetCoreTemplate.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    public class ContactFormViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input your names.")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Your email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a subject for the message")]
        [StringLength(100, ErrorMessage = "The title must be at least {2}ant not more than {1} symbols.", MinimumLength = 5)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the content of the message")]
        [StringLength(10000, ErrorMessage = "The message must be at least {2} symbols.", MinimumLength = 20)]
        [Display(Name = "Content of the message")]
        public string Content { get; set; }

        public string RecaptchaValue { get; set; }
    }
}
