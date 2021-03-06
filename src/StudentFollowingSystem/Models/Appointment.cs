﻿using System;

namespace StudentFollowingSystem.Models
{
    /// <summary>
    /// An appointment for a counseling between an counseler and student.
    /// </summary>
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CounselerId { get; set; }

        public Counseler Counseler { get; set; }

        public string Location { get; set; }

        public bool Accepted { get; set; }

        public bool Noted { get; set; }
    }
}
