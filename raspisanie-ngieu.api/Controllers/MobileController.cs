using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using raspisanie_ngieu.api.Models;

namespace raspisanie_ngieu.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly raspisanieContext _context;

        public MobileController(raspisanieContext context)
        {
            _context = context;
        }

    }
}
