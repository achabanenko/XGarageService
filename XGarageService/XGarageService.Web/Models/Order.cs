using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGarageService.Web.Models
{
    public class ServiceOrder 
    {
        public string Id { get; set; }
        public string RegNumber { get; set; }
        public DateTime SelectedDate { get; set; }
        public bool IsRepair { get; set; }
        public string Remarks { get; set; }
    }
}
