using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ModelsDTO
{
    public class AreaDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string SimpleName { get; set; }
    }
}
