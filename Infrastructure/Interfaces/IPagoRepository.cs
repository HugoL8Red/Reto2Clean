using Reto2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto2.Infrastructure.Interfaces
{
    public interface IPagoRepository
    {
        public Task<int> RealizarPago(Pago pago);
    }
}
