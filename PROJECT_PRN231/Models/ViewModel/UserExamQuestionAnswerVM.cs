namespace PROJECT_PRN231.Models.ViewModel
{
    public class UserExamQuestionAnswerVM
    {
        public int? UserId { get; set; }
        public int? ExamId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public bool? IsCorrect { get; set; }
        public int Id { get; set; }
    }
}
