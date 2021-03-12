using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsBLL
{
    public class PersonWithOrgName
    {
        public PersonDTO Person { get; set; }
        public string OrgName { get; set; }
    }
}
