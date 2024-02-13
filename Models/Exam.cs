using System;
using System.Collections.Generic;

namespace PROJECT_PRN231.Models
{
    public partial class Exam
    {
        public int ExamId { get; set; }
        public string? ExamName { get; set; }
        public int? Duration { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
