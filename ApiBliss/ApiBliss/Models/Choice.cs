using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiBliss.Models;

[Table("Choices")]
public class Choice
{
    [Key]
    [JsonIgnore]
    public int Id { get; set; }

    [Required]
    [StringLength(140)]
    public string? OptionOfChoice { get; set; }
    public int Votes { get; set; }
    
    [JsonIgnore]
    public int QuestionId { get; set; }
    
    [JsonIgnore]
    public Question? Question { get; set; }
}
