using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ModelsDAL
{
    public class Area
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string SimpleName { get; set; }
        public ICollection<Organization> Organizations { get; set; }

    }
}
