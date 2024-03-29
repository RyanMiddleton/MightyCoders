﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class NoteType
    {
        [Key]
        public int NoteTypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
