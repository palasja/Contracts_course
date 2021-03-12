using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO
{
    public class OrganizationDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }
        public string Smdo { get; set; }
        public string Email { get; set; }
        public int AreaId { get; set; }
        public int PersonId { get; set; }
    }
}
