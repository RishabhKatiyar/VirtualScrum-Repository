using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VirtualScrum.Models
{
    public class VirtualScrumEntities : DbContext
    {
        //public VirtualScrumEntities() : base("name=VirtualScrumEntities")
        //{
        //    var ensureDLLIsCopied =
        //        System.Data.Entity.SqlServer.SqlProviderServices.Instance;   
        //}
        //public DbSet<Member> Members { get; set; }
        public DbSet<ScrumTeam> ScrumTeams { get; set; }
        public DbSet<ScrumTeamMember> ScrumTeamMembers { get; set; }
        public DbSet<DailyStatus> DailyStatus { get; set; }
        public DbSet<DailyStatusDetail> DailyStatusDetail { get; set; }
    }
}