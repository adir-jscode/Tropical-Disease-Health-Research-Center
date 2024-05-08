using System;
using System.ComponentModel.DataAnnotations;

public class Publications
{
    public string Id { get; set; } = "P-011" + DateTime.Now.ToString("yyyyMMddHHmmss");

   
    public string? Title { get; set; }

   
    //public string? Author { get; set; }

    [Required(ErrorMessage = "The Content field is required.")]
    public string Content { get; set; }

    public string? JournalLink { get; set; }

    public string? ImageUrl { get; set; }
}
