﻿using System.Collections.Generic;
using System.Linq;
using Dommel;
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
                return con.GetAll<Class, Counseler, Class>((@class, counseler) =>
                                                           {
                                                               @class.Counseler = counseler;
                                                               return @class;
                                                           })
                          .ToList();
            }
        }
    }
}
