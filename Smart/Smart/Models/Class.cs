﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Term")]
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public virtual Term Term { get; set; }
        public string ClassName { get; set; }
        public string InstructorName { get; set; } 
        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}