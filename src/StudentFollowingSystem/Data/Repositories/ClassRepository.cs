﻿using System.Collections.Generic;
using System.Linq;
using Dapper;
using StudentFollowingSystem.Models;

namespace StudentFollowingSystem.Data.Repositories
{
    public class ClassRepository : RepositoryBase<Class>
    {
        /// <summary>
        /// Gets all the classes with the corresponding counseler.
        /// </summary>
        /// <returns>A collection of classes.</returns>
        public override List<Class> GetAll()
        {
            using (var con = ConnectionFactory.GetOpenConnection())
            {
                string sql = @"
select * from Classes class
inner join Counselers counseler on class.CounselerId = counseler.Id";
                return con.Query<Class, Counseler, Class>(sql, (@class, counseler) =>
                                                               {
                                                                   @class.Counseler = counseler;
                                                                   return @class;
                                                               })
                          .ToList();
            }
        }
    }
}
