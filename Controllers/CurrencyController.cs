using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SystemGlobalServicesTestTask.Services;

namespace SystemGlobalServicesTestTask.Controllers
{
    [ApiController]
    [Route("/")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly CurrencyProxyService _proxy;

            
        public CurrencyController(ILogger<CurrencyController> logger, CurrencyProxyService currencyProxy)
        {
            _logger = logger;
            _proxy = currencyProxy;
        }
      
        
        [HttpGet("currency/{id}")]
        public IActionResult GetCurrency(string id)
        {
            var res = _proxy.GetCurrency(id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpGet("currencies/id={id}&size={size}")]
        public IActionResult GetCurrencies(string id, string size)
        {
            int intSize;
            if (!int.TryParse(size, out intSize) || intSize < 1) return BadRequest();
            var res = _proxy.GetNextCurrencies(id, intSize);
            return res == null ? NotFound() : Ok(res);
        }
    }
}
