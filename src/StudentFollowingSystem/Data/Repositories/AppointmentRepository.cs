﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dommel;
using StudentFollowingSystem.Models;

namespace StudentFollowingSystem.Data.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>
    {
        /// <summary>
        /// Gets all the appointments joined with the counseler and student.
        /// </summary>
        public override List<Appointment> GetAll()
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                return con.GetAll<Appointment, Counseler, Student, Appointment>(
                    (a, c, s) =>
                    {
                        a.Counseler = c;
                        a.Student = s;
                        return a;
                    }).ToList();
            }
        }

        /// <summary>
        /// Gets an appointment by its id joined with the counseler and student.
        /// </summary>
        /// <param name="id">The id of the appointment.</param>
        public override Appointment GetById(int id)
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                return con.Get<Appointment, Counseler, Student, Appointment>(id,
                    (a, c, s) =>
                    {
                        a.Counseler = c;
                        a.Student = s;
                        return a;
                    });
            }
        }

        /// <summary>
        /// Gets all the appointments for te specified <paramref name="counselerId"/> 
        /// within the specified date range joined with the student and counseler.
        /// </summary>
        /// <param name="counselerId">The counseler id.</param>
        /// <param name="toDate">The starting date.</param>
        /// <param name="nowDate">The end date.</param>
        /// <returns>A collection of appointments.</returns>
        public List<Appointment> GetAppointmentsByCounseler(int counselerId, DateTime toDate, DateTime nowDate)
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                string sql = @"
select * from Appointments a
join Students s on a.StudentId = s.Id
join Counselers c on a.CounselerId = c.Id
where a.Accepted = 1 and a.Noted = 0 and a.CounselerId = @counselerId and a.DateTime < @toDate and a.DateTime >= @nowDate
order by a.DateTime desc";

                return con.Query<Appointment, Student, Counseler, Appointment>(sql, (a, s, c) =>
                                                                         {
                                                                             a.Student = s;
                                                                             a.Counseler = c;
                                                                             return a;
                                                                         },
                    new { counselerId = counselerId, toDate = toDate, nowDate = nowDate })
                          .ToList();
            }
        }

        /// <summary>
        /// Gets all the appointments  for te specified <paramref name="studentId"/> 
        /// within the specified date range.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="toDate">The starting date.</param>
        /// <param name="nowDate">The end date.</param>
        /// <returns>A collection of appointments.</returns>
        public List<Appointment> GetAppointmentsByStudent(int studentId, DateTime toDate, DateTime nowDate)
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                string sql = @"
select * from Appointments a
inner join Counselers c on a.CounselerId = c.Id
where a.Accepted = 1 and a.Noted = 0 and a.StudentId = @StudentId and a.DateTime < @toDate and a.DateTime >= @nowDate
order by a.DateTime desc";

                return con.Query<Appointment, Counseler, Appointment>(sql, (a, c) =>
                                                                           {
                                                                               a.Counseler = c;
                                                                               return a;
                                                                           },
                    new { studentId, toDate, nowDate })
                          .ToList();
            }
        }
    }
}
