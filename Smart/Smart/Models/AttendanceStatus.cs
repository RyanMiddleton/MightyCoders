using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class AttendanceStatus
    {
        //[Key]
        public int AttendanceStatusId { get; set; }
        public string Description { get; set; }

    }
}
