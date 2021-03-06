﻿using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dommel;
using StudentFollowingSystem.Models;

namespace StudentFollowingSystem.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student>
    {
        /// <summary>
        /// Gets a student by its <paramref name="id"/> with its corresponding class.
        /// </summary>
        /// <param name="id">The id of the student.</param>
        /// <returns>A student.</returns>
        public override Student GetById(int id)
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                string sql = @"
select * from Students s
left join Classes c on c.Id = s.ClassId
where s.Id = @Id";

                return con.Query<Student, Class, Student>(
                    sql,
                    (s, c) =>
                    {
                        s.Class = c;
                        return s;
                    },
                    new { Id = id }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets all the students joined with their class. 
        /// </summary>
        public override List<Student> GetAll()
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                return con.GetAll<Student, Class, Student>((s, c) =>
                                                           {
                                                               s.Class = c;
                                                               return s;
                                                           }).ToList();
            }
        }

        /// <summary>
        /// Gets a student by its <paramref name="email"/>.
        /// </summary>
        /// <param name="email">The email address of the student.</param>
        /// <returns>A student.</returns>
        public Student GetByEmail(string email)
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                return con.Select<Student>(s => s.Email == email || s.SchoolEmail == email).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets a student by its <paramref name="studentNr"/>.
        /// </summary>
        /// <param name="studentNr">The student number of the student.</param>
        /// <returns>A student.</returns>
        public Student GetByStudentNr(int studentNr)
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                return con.Select<Student>(s => s.StudentNr == studentNr).FirstOrDefault();
            }
        }
    }
}
