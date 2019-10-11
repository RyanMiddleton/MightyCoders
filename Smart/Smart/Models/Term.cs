using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Term
    {
        [Key]
        public int Id { get; set; }
        public string TermName { get; set; } // couldn't name it Term since the class is already named that
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
