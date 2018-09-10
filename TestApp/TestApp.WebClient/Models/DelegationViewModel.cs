using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.WebClient.Models
{
    public class DelegationViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AgendaTitle { get; set; }
        public int HostId { get; set; }
        public int LocationId { get; set; }

        public override string ToString()
        {
            return string.Format("('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}),", Name, Description, StartDate, EndDate, AgendaTitle, HostId, LocationId);
        }
    }
}