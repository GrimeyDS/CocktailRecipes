
using System.ComponentModel.DataAnnotations;

namespace Pin.OpenData.Core.Entities
{
    public class Subscriber
    {
        [Required(ErrorMessage = "Please provide an email.")]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsSubscribed { get; set; }
    }
}
