using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string UserName { get; set; }
        #endregion


        #region StatusUpdate
        public string DidYesterday { get; set; }
        public string DoToday { get; set; }
        public string BlockingIssue { get; set; }
        #endregion

        public ScrumTeamMember ScrumTeamMember { get; set; }
    }

    public class DailyStatusInfo
    {
        public IList<SelectListItem> ScrumTeamInfoList { get; set; }
    }
}