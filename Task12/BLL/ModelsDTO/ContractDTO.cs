using BLL.ModelsDTO.Serivces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public string Number{ get; set; }
        public DateTime SatartDate { get; set; }
        public DateTime EndDate { get; set; }
/*        public ICollection<ServiceSoftware> ServicesSoftware { get; set; }
        public ICollection<ServiceHardware> ServicesHardware { get; set; }*/
        public int OrganizationId { get; set; }
    }
}
