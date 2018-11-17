using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace EzShop.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        private static readonly ConcurrentBag<IntPtr> _buffers = new ConcurrentBag<IntPtr>();

        // POST api/memory
        [HttpPost]
        public ActionResult AllocateBytes([FromQuery] int amount)
        {
            if (amount <= 0 || amount > 1024)
                return BadRequest("amount must be between 1-1014 MB");

            Console.WriteLine($"Allocating {amount} MBytes");
            try
            {
                const int kb = 1024 * 1024;
                for (int i = 0; i < amount; i++)
                {
                    IntPtr buffer = Marshal.AllocHGlobal(1024 * kb);
                    for (int j = 0; j < 1024; j++)
                    {
                        Marshal.WriteInt64(buffer + j * kb - 8, 0);
                    }

                    _buffers.Add(buffer);
                }

                Console.WriteLine($"Allocated {amount} MBytes");
                return Ok($"Allocated {amount} MBytes");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Out of memory");
                return StatusCode(500, "Out of memory");
            }
        }

        // POST api/memory
        [HttpDelete]
        public ActionResult AllocateBytes()
        {
            foreach (var buffer in _buffers)
                Marshal.FreeHGlobal(buffer);

            return Ok();
        }
    }
}