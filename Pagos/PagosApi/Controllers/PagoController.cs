using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _PagoService;

        public PagoController(IPagoService pagoService)
        {
            _PagoService = pagoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pago"></param>
        /// <returns></returns>
        [HttpPost]
        public int RealizarPago(Pago Pago)
        {
            var PagoId = _PagoService.RealizarPago(Pago);
            return 0;
        }
    }
}
