using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Count { get; set; }
        public int GoodId { get; set; }

        
        public decimal Sum { get; set; }
        public Status Status { get; set; }
        public string GoodName { get; set; }
        public DateTime? Date { get; set; }
    }
}
