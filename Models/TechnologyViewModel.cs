using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpaceEmpire4XTracker.Models
{
    public class TechnologyViewModel
    {


        [Key]
        public int TechId { get; set; }

        [Required]
        [Display(Name = "Technology")]
        public string TechnologyName { get; set; }

        [Display(Name = "Level")]
        public virtual TechnologyLevelViewModel TechnologyLevel { get; set; }
        public IEnumerable<SelectListItem> TechLevelDropDownList { get; set; }

        [Display(Name = "Cost")]
        public virtual CostViewModel Cost { get; set; }
        public IEnumerable<SelectListItem> CostDropDownList { get; set; }
    }
}
