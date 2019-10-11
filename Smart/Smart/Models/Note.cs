using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Notes { get; set; }
        public NoteType NoteType { get; set; }
    }
}
