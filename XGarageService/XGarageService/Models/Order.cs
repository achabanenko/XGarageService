using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGarageService.Models
{
    public class Order: BaseModel
    {
        public string Id { get; set; }
        public string RegNumber { get; set; }
        public DateTime SelectedDate { get; set; }
        public bool IsRepair { get; set; }
        public bool IsService { get; set; }
        public bool IsPickupMyCar { get; set; }
        public bool IsReturnMyCar { get; set; }
        public string Remarks { get; set; }
    }
    public class ServiceOrder : BaseModel
    {
        public string Id { get; set; }
        public string RegNumber { get; set; }
        public DateTime SelectedDate { get; set; }
        public bool IsRepair { get; set; }
        public string Remarks { get; set; }
    }

}
