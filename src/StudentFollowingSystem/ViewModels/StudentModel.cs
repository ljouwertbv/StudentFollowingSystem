﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using StudentFollowingSystem.Models;

namespace StudentFollowingSystem.ViewModels
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student nr")]
        public int StudentNr { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        [Required]
        public string Email { get; set; }

        [Required]
        public string SchoolEmail { get; set; }

        public int ClassId { get; set; }

        public IEnumerable<SelectListItem> ClassesList { get; set; }

        public string Telephone { get; set; }

        public string StreetName { get; set; }

        public int StreetNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollDate { get; set; }

        public string PreStudy { get; set; }

        public Status Status { get; set; }

        public bool Active { get; set; }

        public string Details { get; set; }
    }
}
