using ApiBliss.Data;
using ApiBliss.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBliss.Controllers;

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Person Owner { get; set; }
    public int PersonId { get; set; }
}


[Route("[controller]")]
[ApiController]
public class QuestionsController : Controller
{
    private readonly ApiBlissContext _context;

    public QuestionsController(ApiBlissContext context)
    {
        _context = context;
    }

    [HttpGet("{limit}/{offset}/{filter}")]
    public async Task<ActionResult<IEnumerable<Question>>> GetAsycn(int limit, int offset, string filter)
    {
        var result = await _context.Questions.AsNoTracking().Join(_context.Choices.AsNoTracking(),
                                            question => question.Id,
                                            choice => choice.QuestionId,
                                            (question, choice) => 
                                            new Question {Id = question.Id, 
                                                          Ask = question.Ask, 
                                                          ImageUrl = question.ImageUrl,
                                                          ThumbUrl = question.ThumbUrl,
                                                          PublishedAt = question.PublishedAt,
                                                          Choices = question.Choices}).
                                                            Where(question => question.Ask.Contains(filter)).
                                                            GroupBy(question => question.Id).
                                                            Select(question => question.FirstOrDefault()).
                                                            Skip(0).Take(limit).ToListAsync();

       
        if (result is null)
            return NotFound("Questions don't find.");

        return result;
    }
}
