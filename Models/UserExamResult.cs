using System;
using System.Collections.Generic;

namespace PROJECT_PRN231.Models
{
    public partial class UserExamResult
    {
        public int ResultId { get; set; }
        public int? UserId { get; set; }
        public int? ExamId { get; set; }
        public double? Score { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
