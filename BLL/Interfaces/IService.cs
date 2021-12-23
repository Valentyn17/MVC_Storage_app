using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService
    {
        void MakeOrder(OrderDTO orderDto);
        GoodDTO GetGood(int? id);
        void AddGoodsToStorage(int? id, int Count);
        IEnumerable<GoodDTO> GetGoods();
        IEnumerable<OrderDTO> GetOrders();

        IEnumerable<GoodDTO> FindByName(string Name);
        void CreateGood(GoodDTO goodDTO);

        void DeleteGood(int id);
        void DeleteOrder(int id);

        OrderDTO GetOrder(int? id);
        void ChangeOrderStatus(OrderDTO orderDTO);
        void UpdateGood(GoodDTO goodDTO);
        void Dispose();
    }
}
