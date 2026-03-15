using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PagoRepository : IPagoRepository
    {

        private readonly AppDbContext _context;

        public PagoRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pago"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int RealizarPago(Pago pago)
        {
            _context.Pagos.Add(pago);
            _context.SaveChanges();
            return 1;
        }
    }
}
