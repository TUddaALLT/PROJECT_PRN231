using System;
using System.Collections.Generic;

namespace PROJECT_PRN231.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string? Value { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
