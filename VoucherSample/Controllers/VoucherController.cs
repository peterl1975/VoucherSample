using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace VoucherSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoucherController : ControllerBase
    {
        
        private readonly ILogger<VoucherController> _logger;

        public VoucherController(ILogger<VoucherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetVoucher(string val)
        {
            RedemptionFactory redemption;
            if (val == null)
            {
                val = "1";
            }
            var str = val.Substring(val.Length - 1);
            DateTime dat;
            switch (str.ToUpper())
            {
                case "1":
                    dat = DateTime.UtcNow.AddDays(4);
                    redemption = new SingleRedemptionFactory();
                    break;
                case "2":
                    dat = DateTime.UtcNow.AddDays(8);
                    redemption = new SingleRedemptionFactory();
                    break;
                case "3":
                    dat = DateTime.UtcNow.AddDays(24);
                    redemption = new SingleRedemptionFactory();
                    break;
                case "4":
                    dat = DateTime.UtcNow.AddDays(6);
                    redemption = new MultiRedemptionFactory();
                    break;
                case "5":
                    dat = DateTime.UtcNow.AddDays(-34);
                    redemption = new MultiRedemptionFactory();
                    break;
                case "6":
                    dat = DateTime.UtcNow.AddDays(5);
                    redemption = new MultiRedemptionFactory();
                    break;
                case "7":
                    dat = DateTime.UtcNow.AddDays(14);
                    redemption = new XRedemptionFactory();
                    break;
                case "8":
                    dat = DateTime.UtcNow.AddDays(-4);
                    redemption = new XRedemptionFactory();
                    break;
                case "9":
                    dat = DateTime.UtcNow.AddDays(44);
                    redemption = new XRedemptionFactory();
                    break;
                default:
                    return "not found";
            }
            if (dat < DateTime.Now)
            {
                return "Vocher expired";
            } 
            Voucher voucher = new Voucher(redemption); 
            return voucher.ProcessDeduction();
        }

        [HttpPost]
        public IActionResult CreateVoucher(VoucherObject voucherRequest )
        {
            voucherRequest.ValidDateFrom = DateTime.Now.AddDays(3);
            voucherRequest.Approved = true;
            return Ok(voucherRequest); 
        }
    }
}
