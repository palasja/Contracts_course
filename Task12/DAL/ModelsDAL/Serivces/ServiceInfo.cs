using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ModelsDAL.Serivces
{
    public class ServiceInfo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double MainCost { get; set; }
        [Required]
        public double AdditionalCost { get; set; }
        public string? Description { get; set; }
    }
}
