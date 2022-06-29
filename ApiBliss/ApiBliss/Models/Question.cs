using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBliss.Models;

[Table("Questions")]
public class Question
{
    [Key]    
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} requied")]
    [StringLength(300, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} amd {1}")]
    public string? Ask { get; set; }

    [StringLength(500)]
    public string? ImageUrl { get; set; }

    [StringLength(500)]
    public string? ThumbUrl { get; set; }

    [Required]    
    public DateTime PublishedAt { get; set; }

    public ICollection<Choice>? Choices { get; set; }

    public Question()
    {
        Choices = new Collection<Choice>();
    }
}
