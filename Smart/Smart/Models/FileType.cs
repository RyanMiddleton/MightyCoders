using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class FileType
    {
        //[Key]
        public int FileTypeId { get; set; }
        public string Description { get; set; }
    }
}
