using System.ComponentModel.DataAnnotations;

namespace ApiBliss.Models;

public class Choice
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} requied")]
    public string? OptionOfChoice { get; set; }
    public int Votes { get; set; }
    public int QuestionId { get; set; }
}
