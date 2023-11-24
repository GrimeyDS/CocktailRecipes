

using System.ComponentModel.DataAnnotations;

namespace Pin.OpenData.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a name.")]
        [StringLength(50, ErrorMessage ="Please provide a name not longer 50 characters.")]
        public string Name { get; set; }
    }
}
