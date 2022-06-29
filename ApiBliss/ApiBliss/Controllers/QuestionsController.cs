using ApiBliss.Data;
using ApiBliss.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ApiBliss.Controllers;

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

       
        if (result is null || result.Count == 0)
            return NotFound("Questions don't find.");

        return result;
    }

    [HttpGet("{id}", Name="GetQuestion")]
    public async Task<ActionResult<IEnumerable<Question>>> GetAsycn(int id)
    {
        
        var result = await _context.Questions.AsNoTracking().Join(_context.Choices.AsNoTracking(),
                                            question => question.Id,
                                            choice => choice.QuestionId,
                                            (question, choice) =>
                                            new Question
                                            {
                                                Id = question.Id,
                                                Ask = question.Ask,
                                                ImageUrl = question.ImageUrl,
                                                ThumbUrl = question.ThumbUrl,
                                                PublishedAt = question.PublishedAt,
                                                Choices = question.Choices
                                            }).
                                                            Where(question => question.Id == id).ToListAsync(); 


        if (result is null || result.Count == 0)
            return NotFound("Questions don't find.");

        return result;
    }

    [HttpPost]
    public ActionResult Post(Question question)
    {
        try
        {
            if (question is null)
                return BadRequest("Dados inválidos");

            _context.Questions.Add(question);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = question.Id }, question);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                      "Ocorreu um problema ao tratar a sua solicitação.");
        }
    }
}
