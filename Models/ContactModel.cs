using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HMZ4th.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "This one is required")]
        [StringLength(50, ErrorMessage = "Name can't be more than {1} characters.")]
        [Display(Name = "Your full name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "This one is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(150, ErrorMessage = "Email can't be more than {1} characters.")]
        [RegularExpression("^(([^<>()\\[\\]\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$",
            ErrorMessage = "Not a valid email!")]
        [Display(Name = "And your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This one is required")]
        [StringLength(150, ErrorMessage = "Subject can't be more than {1} characters.")]
        [Display(Name = "The subject of your message")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "This one is required")]
        [DataType(DataType.MultilineText)]
        [StringLength(5000, MinimumLength = 30, ErrorMessage = "Message should be between {2} and {1} characters.")]
        [Display(Name = "And finally, your message")]
        public string Message { get; set; }

        [JsonPropertyName("g-recaptcha-response")]
        public string RecpatchaResponse { get; set; }
    }
}
