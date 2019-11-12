using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        [Display(Name = "Note Type")]
        public int NoteTypeId { get; set; }
        [Display(Name = "Note Type")]
        public NoteType NoteType { get; set; }

        public string Text { get; set; }
    }
}
