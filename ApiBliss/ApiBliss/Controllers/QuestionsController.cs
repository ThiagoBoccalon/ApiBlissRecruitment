using ApiBliss.Data;
using ApiBliss.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ApiBliss.Controllers;

[Route("[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly ApiBlissContext _context;

    public QuestionsController(ApiBlissContext context)
    {
        _context = context;
    }

    [HttpGet("{limit}/{offset}/{filter}")]
    public async Task<ActionResult<IEnumerable<Question>>> GetAsycn(int limit, int offset, string filter)
    {
        try
        {
            var result = await _context.Questions.AsNoTracking().Include(question => question.Choices).
                                                             Where(question => question.Ask.Contains(filter)).
                                                             Skip(0).Take(limit).ToListAsync();

            if (result is null || result.Count == 0)
                return NotFound("Questions don't find.");

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                           "I'm sorry. Have a problem to save your information.");
        }
    }

    [HttpGet("{id}", Name="GetQuestion")]
    public async Task<ActionResult<IEnumerable<Question>>> GetAsycn(int id)
    {
        try
        {
            var result = await _context.Questions.AsNoTracking().Include(question => question.Choices).
                                                             Where(question => question.Id == id).
                                                             ToListAsync();

            if (result is null || result.Count == 0)
                return NotFound("Question don't find.");

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                           "I'm sorry. Have a problem to save your information.");
        }        
    }

    [HttpPost]
    public ActionResult Post(Question question)
    {
        try
        {
            if (question is null)
                return BadRequest("Data is invalidate.");

            _context.Questions.Add(question);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetQuestion",
                new { id = question.Id }, question);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                      "I'm sorry. Have a problem to save your information.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Question question)
    {
        try
        {
            if (id != question.Id)
                return BadRequest();

            _context.Entry(question).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(question);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                      "I'm sorry. Have a problem to save your information.");
        }        
    }
}
