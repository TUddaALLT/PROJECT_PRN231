using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Models;

namespace PROJECT_PRN231.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionControllerDemo : ControllerBase
    {
         

        // GET: api/Questions
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            ExamSystemContext examSystemContext = new ExamSystemContext();
            List<Question> _questions = examSystemContext.Questions.ToList();
            return _questions;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            ExamSystemContext examSystemContext = new ExamSystemContext();
            List<Question> _questions = examSystemContext.Questions.ToList();
            var question = _questions.FirstOrDefault(q => q.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }

        // POST: api/Questions
        [HttpPost]
        public ActionResult<Question> Post([FromBody] Question question)
        {
            ExamSystemContext examSystemContext = new ExamSystemContext();
            Console.WriteLine(question);
            examSystemContext.Questions.Add(question);
            examSystemContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = question.QuestionId }, question);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Question updatedQuestion)
        {
            ExamSystemContext examSystemContext = new ExamSystemContext();
            List<Question> _questions = examSystemContext.Questions.ToList();
            var existingQuestion = _questions.FirstOrDefault(q => q.QuestionId == id);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            existingQuestion.QuestionText = updatedQuestion.QuestionText;
          
            existingQuestion.DifficultyLevel = updatedQuestion.DifficultyLevel;
            examSystemContext.Questions.Update(existingQuestion);
            examSystemContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = existingQuestion.QuestionId }, existingQuestion);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ExamSystemContext examSystemContext = new ExamSystemContext();
            List<Question> _questions = examSystemContext.Questions.ToList();
            var questionToRemove = _questions.FirstOrDefault(q => q.QuestionId == id);
            if (questionToRemove == null)
            {
                return NotFound();
            }

            examSystemContext.Questions.Remove(questionToRemove);
            examSystemContext.SaveChanges();
            return NoContent();
        }
    }
}
