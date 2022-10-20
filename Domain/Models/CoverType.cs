using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CoverType
    {
        public int Id { get; set; }
        [Display(Name = "CoverType Name")]
        public string Name { get; set; } = string.Empty;
    }
}
