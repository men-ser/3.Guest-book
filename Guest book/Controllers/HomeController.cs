using Guest_book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Guest_book.Controllers
{
    public class HomeController : Controller
    {
        private readonly GuestBookContext _context;

        public HomeController(GuestBookContext context)
        {
            _context = context;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var guestBookContext = _context.Messages;
            return _context.Messages != null ?
                    View(await _context.Messages.ToListAsync()) :
                    Problem("Entity set 'Messages'  is null.");
                
        }


    }
}
