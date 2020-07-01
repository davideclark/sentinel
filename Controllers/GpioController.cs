using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace sentinelClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController : ControllerBase
    {

        private readonly ILogger<SensorController> _logger;

        public SensorController(ILogger<SensorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetGpio()
        {
            //System.Device.Gpio.GPIOController t= new System.Device.Gpio.GPIOController();
            var c = new GpioController(PinNumberingScheme.Logical); // Board

            var pin = 23;
            var timeOut = 500;

            c.OpenPin(pin, PinMode.Output);

            //            while(true)
            //          {
            c.Write(pin, PinValue.High);
            Thread.Sleep(timeOut);
            c.Write(pin, PinValue.Low);
            Thread.Sleep(timeOut);
            c.Write(pin, PinValue.High);
            Thread.Sleep(timeOut);
            c.Write(pin, PinValue.Low);
            Thread.Sleep(timeOut);

            //        }
            c.ClosePin(pin);

            return "Pin" + pin.ToString() + " Is at " + "unknown";

        }
    }
}
