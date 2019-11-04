using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class File
    {
        //[Key]
        public int FileId { get; set; }
        //[Display(Name = "Student")]
        public int StudentId { get; set; }
        //[ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public string Path { get; set; }
        //[Required]
        public int FileTypeId { get; set; }
        public FileType FileType { get; set; }
    }
}
