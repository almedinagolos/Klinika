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
            var nalazi = await _context.Nalaz.Where(x => x.PrijemId == prijemId).ToListAsync();
            var viewModel = new IndexNalazVM
            {
                PrijemId = prijemId,
                Nalazi = nalazi
            };

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Add(int prijemId)
        {
            var viewModel = new AddNalazVM { PrijemId = prijemId };
            return View(viewModel);
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
                DatumKreiranja = DateTime.Now,
                PrijemId = (int)addNalaz.PrijemId

            };

            _context.Nalaz.Add(nalaz);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { addNalaz.PrijemId });
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

            return RedirectToAction("Index", "Nalaz", new { prijemId = nalaz.PrijemId });
        }
    }
}
