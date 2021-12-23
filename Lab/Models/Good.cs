using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Models
{
    public class Good
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Count { get; set; }

        [Required]
        public string Descr { get; set; }
}
}