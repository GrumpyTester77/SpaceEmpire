using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceEmpire4XTracker.Models
{
    public class TechnologyLevelViewModel
    {
        [Key]
        public int LevelId { get; set; }

        [Required]
        [Display(Name = "Level")]
        public string LevelNumber { get; set; }

    }
}