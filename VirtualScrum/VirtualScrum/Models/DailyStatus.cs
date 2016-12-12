﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VirtualScrum.Models
{
    public class DailyStatus
    {
        [Key]
        public int DailyStatusId { get; set; }

        #region IxDailyStatus - NonCluster
        [Index("IxDailyStatus", 1, IsClustered = false, IsUnique = true)]
        public DateTime Date { get; set; }

        [ForeignKey("ScrumTeamMember"), Column(Order = 0)]
        [Index("IxDailyStatus", 2, IsClustered = false, IsUnique = true)]
        public int ScrumTeamId { get; set; }

        [ForeignKey("ScrumTeamMember"), Column(Order = 1)]
        [Index("IxDailyStatus", 3, IsClustered = false, IsUnique = true)]
        public int MemberId { get; set; }
        #endregion

        public ScrumTeamMember ScrumTeamMember { get; set; }
    }
}