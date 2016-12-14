using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VirtualScrum.Models
{
    public class ScrumTeamMember
    {
        public ScrumTeam ScrumTeam { get; set; }
        [Key, ForeignKey("ScrumTeam"), Column(Order = 1)]
        public int ScrumTeamId { get; set; }

        //public Member Member { get; set; }
        [Key, Column(Order = 2)]
        public string UserName { get; set; }
        public bool isActive { get; set; }
        public string ScrumDesignation { get; set; }
    }
}