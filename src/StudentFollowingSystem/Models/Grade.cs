﻿namespace StudentFollowingSystem.Models
{
    /// <summary>
    /// A grade of a student for an exam unit with a result.
    /// </summary>
    public class Grade
    {
        public int Id { get; set; }

        public int ExamUnitId { get; set; }

        public ExamUnit ExamUnit { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public decimal Result { get; set; }

        public string Notes { get; set; }
    }
}
