using System;
using System.Collections.Generic;

namespace PROJECT_PRN231.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? CorrectAnswer { get; set; }
        public int? DifficultyLevel { get; set; }
    }
}
