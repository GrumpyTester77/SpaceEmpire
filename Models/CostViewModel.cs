using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceEmpire4XTracker.Models
{
    public class CostViewModel
    {
        [Key]
        public int CostId { get; set; }

        public int Cost { get; set; }
    }
}
