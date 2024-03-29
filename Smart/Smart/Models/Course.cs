﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public bool IsCoreRequirement { get; set; }
        public bool IsTaughtHere { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
