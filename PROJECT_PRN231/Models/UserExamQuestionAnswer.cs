using System;
using System.Collections.Generic;

namespace PROJECT_PRN231.Models
{
    public partial class UserExamQuestionAnswer
    {
        public int? UserId { get; set; }
        public int? ExamId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public bool? IsCorrect { get; set; }
        public int Id { get; set; }

        public virtual Answer? Answer { get; set; }
        public virtual Exam? Exam { get; set; }
        public virtual Question? Question { get; set; }
        public virtual User? User { get; set; }
    }
}
