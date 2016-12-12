using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VirtualScrum.Models
{
    public class DailyStatusDetail
    {
        [Key, ForeignKey("DailyStatus")]
        public int DailyStatusDetailsId { get; set; }

        //[Index("IxDailyStatusDetail", 1, IsClustered = false, IsUnique = true)]
        //public int DialyStatusId { get; set; }

        #region StatusUpdate
        public string DidYesterday { get; set; }
        public string DoToday { get; set; }
        public string BlockingIssue { get; set; }
        #endregion

        public DailyStatus DailyStatus { get; set; }
    }
}