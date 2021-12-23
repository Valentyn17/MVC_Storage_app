using Lab.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Range(0, 1000)]
        public int Count { get; set; }
        public string GoodName { get; set; }

        public decimal Sum { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Items")]
        public Status Status { get; set; }
        public int GoodId { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:  dd MMM yyyy}")]
        public DateTime? Date { get; set; }
    }
}