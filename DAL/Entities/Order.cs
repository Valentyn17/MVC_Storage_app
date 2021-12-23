using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int GoodId { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Good Good { get; set; }

        [Required]
        public Status Status { get; set; }

    }
}
