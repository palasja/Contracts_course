using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ModelsDAL
{
    public class Organization
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string? Smdo { get; set; }
        public string? Email { get; set; }
        public Area Area { get; set; }
        public int AreaId { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
