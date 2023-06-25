using Klinika.Database;
using Klinika.DB;
using Klinika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Klinika.Controllers
{
    public class NalazController : Controller
    {
        private readonly MyDbContext _context;

        public NalazController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int prijemId)
        {
            ViewBag.PrijemId = prijemId;

            var nalazi = await _context.Nalaz.Where(x => x.PrijemId == prijemId).ToListAsync();
            return View(nalazi);
        }

        [HttpGet]
        public IActionResult Add(int? prijemId)
        {
            var addNalaz = new AddNalazVM { PrijemId = prijemId.Value, DatumKreiranja = DateTime.Now };
            return View(addNalaz);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNalazVM addNalaz)
        {
            if (!ModelState.IsValid)
            {
                return View(addNalaz);
            }

            var nalaz = new Nalaz()
            {
                Opis = addNalaz.Opis,
                DatumKreiranja = addNalaz.DatumKreiranja.Value,
                PrijemId = (int)addNalaz.PrijemId
            };

            _context.Nalaz.Add(nalaz);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { prijemId = addNalaz.PrijemId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var nalaz = await _context.Nalaz.FirstOrDefaultAsync(x => x.NalazId == id);

            if (nalaz != null)
            {
                _context.Nalaz.Remove(nalaz);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", new { prijemId = nalaz.PrijemId });
        }
    }
}
