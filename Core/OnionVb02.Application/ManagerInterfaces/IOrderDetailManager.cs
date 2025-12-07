using OnionVb02.Application.DTOClasses;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.ManagerInterfaces
{
    public interface IOrderDetailManager : IManager<OrderDetailDto,OrderDetail>
    {
    }
}
