using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualScrum.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public bool IsActive { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}