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
        public int NoteId { get; set; }
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }
        // public virtual User User { get; set; }
        [Required]
        public int NoteTypeId { get; set; }
        public NoteType NoteType { get; set; }

        public string Text { get; set; }
    }
}
