using ApiBliss.Data;
using ApiBliss.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBliss.Controllers;

[Route("[controller]")]
[ApiController]
public class ChoicesController : ControllerBase
{
    private readonly ApiBlissContext _context;

    public ChoicesController(ApiBlissContext context)
    {
        _context = context;
    }
    [HttpPut("{idQuestion:int:min(1)}")]
    public ActionResult Put(int idQuestion, Choice choice)
    {
        try
        {
            if (choice is null)
                return BadRequest("Data is invalidate.");

            var result = GetQuestionWithId(idQuestion);

            if (result is null || result.Count == 0)
                return NotFound($"Question with ID equal {idQuestion} not found");

            choice.QuestionId = idQuestion;
            _context.Choices.Add(choice);
            _context.SaveChanges();

            return Ok(choice);
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                      "I'm sorry. Have a problem to save your information.");
        }
    }

    private List<Question> GetQuestionWithId(int id)
    {
        var result = _context.Questions.AsNoTracking().Include(question => question.Choices).
                                                             Where(question => question.Id == id).
                                                             ToList();

        return result;
    }
}
