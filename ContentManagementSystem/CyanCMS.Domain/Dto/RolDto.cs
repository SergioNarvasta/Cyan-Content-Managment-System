using CyanCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanCMS.Domain.Dto
{
    public class RolDto
    {
        public string Name { get; set; } = "user";
        public string? Description { get; set; }
    }
}
