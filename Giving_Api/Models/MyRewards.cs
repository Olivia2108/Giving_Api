using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Giving_Api.Models
{
    public class MyRewards
    {
        [Key]
        public Guid Id { get; set; }
    }
}
