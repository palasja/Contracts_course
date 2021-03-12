using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO.Serivces
{
    public class ServiceInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MainCost { get; set; }
        public double AdditionalCost { get; set; }
        public string Description { get; set; }
    }
}
