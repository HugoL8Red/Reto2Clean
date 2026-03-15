using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IPagoRepository
    {
        public int RealizarPago(Pago pago);
    }
}
