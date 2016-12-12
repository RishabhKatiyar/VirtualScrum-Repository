using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualScrum.Models
{
    public class ScrumTeam
    {
        [Key]
        public int ScrumTeamId { set; get; }
        public string TeamProjectName { set; get; }
        public bool IsActive { get; set; }
    }
}