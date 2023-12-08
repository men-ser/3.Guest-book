using Guest_book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            MessagesModel model = new MessagesModel();
            ICollection<Messages> temp = new List<Messages>();
            if (_context.Messages.ToList().Count != 0 && _context.Users.ToList().Count != 0) 
            {
                foreach (var msg in _context.Messages.ToList())
                {
                    temp.Add(msg);
                }
            }
            model.Messages = temp;

            /*foreach (var user in _context.Users)
            {
                if (msg.UserId == user.UserId)
                    msg.Name.Login = user.Login;
            }*/

            return model != null ?
                    View(model) :
                    Problem("Entity set 'Messages'  is null.");
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MessagesModel item)
        {
            Messages message = new Messages();
            message.MessageDate = item.MessageDate;
            message.Message = item.Message;

            if (_context.Users.ToList().Count != 0)
            {
                foreach (var user in _context.Users)
                {
                    if (item.Name.Login == user.Login)
                        message.UserId = user.UserId;
                }
            }           
           
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", messages.UserId);
            return RedirectToAction("Index", "Home");
        }

        

    }
}
