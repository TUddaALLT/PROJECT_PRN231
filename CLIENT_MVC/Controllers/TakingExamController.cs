using CLIENT_MVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Models;
using PROJECT_PRN231.Models.ViewModel;
using System.Net;

namespace CLIENT_MVC.Controllers
{
    public class TakingExamController : Controller
    {
        const string CONTROLLER_EXAMQUESTION = "ExamQuestion/";
        const string CONTROLLER_USER = "User/";
        const string CONTROLLER_USEREXAMQUESTIONANSWER = "UserExamQuestionAnswer/";

		private readonly APIHelper _apiHelper;
        public TakingExamController(APIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<IActionResult> Index(int? examId)
        {
            if (examId == null)
            {
                return BadRequest("No examId");
            }
            var result = await _apiHelper.RequestGetAsync<List<ExamQuestion>>(CONTROLLER_EXAMQUESTION + $"examId/{examId.Value}");
            return View(result);
        }
        [HttpPost]
        public async void SelectAnswer(string userId, string examId, string questionId, string answerId, string isCorrect)
        {
            var model = new UserExamQuestionAnswerVM
            {
                AnswerId = int.Parse(answerId),
                ExamId = int.Parse(examId),
                IsCorrect = bool.Parse(isCorrect),
                QuestionId = int.Parse(questionId),
                UserId = int.Parse(userId)
            };
            var result = await _apiHelper.RequestPostAsync<UserExamQuestionAnswerVM>(CONTROLLER_USEREXAMQUESTIONANSWER + "SelectAnswer", model);
			if (result.Response.IsSuccessStatusCode)
			{
				ViewBag.Result = result.Body;
				//return RedirectToAction("Index", "Home");
			}
			else if (result.Response.StatusCode == HttpStatusCode.BadRequest || result.Response.StatusCode == HttpStatusCode.NotFound)
			{
				ViewBag.Validate = result.Body;
			}
		}
    }
}
