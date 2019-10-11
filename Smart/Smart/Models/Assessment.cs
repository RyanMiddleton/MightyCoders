using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
        public string Title { get; set; }
        public string Type { get; set; } // maybe we'll add an enumeration for this once we know the types they use
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
