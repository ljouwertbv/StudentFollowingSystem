﻿namespace StudentFollowingSystem.Models
{
    /// <summary>
    /// A counseler.
    /// </summary>
    public class Counseler
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
