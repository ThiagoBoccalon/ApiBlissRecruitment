using System.ComponentModel.DataAnnotations;

namespace ApiBliss.Models;

public class Question
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} requied")]
    [StringLength(140, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} amd {1}")]
    public string? Ask { get; set; }
    public string? ImageUrl { get; set; }
    public string? ThumbUrl { get; set; }

    [Required(ErrorMessage = "{0} requied")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime PublishedAt { get; set; }

    public ICollection<Choice>? Choices { get; set; }

    public Question()
    {
        Choices = new List<Choice>();
    }
}
