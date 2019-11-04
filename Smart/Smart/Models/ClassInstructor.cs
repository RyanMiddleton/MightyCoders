﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ClassInstructor
    {
        //[Key]
        public int ClassId { get; set; }
        //[ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
        public int UserId { get; set; } // will add this as PK/FK when identities are setup
    }
}
