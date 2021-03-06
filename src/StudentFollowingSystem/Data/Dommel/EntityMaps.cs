﻿using Dapper.FluentMap.Dommel.Mapping;
using StudentFollowingSystem.Models;

namespace StudentFollowingSystem.Data.Dommel
{
    public class ClassesMap : DommelEntityMap<Class>
    {
        public ClassesMap()
        {
            // Map entity 'Class' to table 'Classes'.
            ToTable("Classes");
        }
    }
}
