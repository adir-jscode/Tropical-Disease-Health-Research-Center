using System.ComponentModel.DataAnnotations;

namespace TDHRC.Models
{
    public class Blogs
    {
        public string Id { get; set; } = "B-011" + DateTime.Now.ToString("yyyyMMddHHmmss");

        [Required(ErrorMessage = "The Title field is required.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "The Content field is required.")]
        public string? Content { get; set; }

        public string? ImageUrl { get; set; }
    }
}
