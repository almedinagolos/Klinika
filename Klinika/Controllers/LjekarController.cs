using Klinika.Database;
using Klinika.DB;
using Klinika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Controllers
{
    public class LjekarController : Controller
    {
        private readonly MyDbContext _context;
        public LjekarController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ljekari = await _context.Ljekar.ToListAsync();

            return View(ljekari);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddLjekarVM());
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddLjekarVM addLjekaraRequest)
        {
            if (!ModelState.IsValid)
                return View();

            var ljekar = new Ljekar()
            {
                Ime = addLjekaraRequest.Ime,
                Prezime = addLjekaraRequest.Prezime,
                Titula = addLjekaraRequest.Titula,
                Sifra = addLjekaraRequest.Sifra,
            };
            await _context.Ljekar.AddAsync(ljekar);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ljekar = await _context.Ljekar.FirstOrDefaultAsync(x => x.LjekarId == id);
            if (ljekar != null)
            {
                var editModel = new UpdateLjekarVM()
                {
                    LjekarId = ljekar.LjekarId,
                    Ime = ljekar.Ime,
                    Prezime = ljekar.Prezime,
                    Titula = ljekar.Titula,
                    Sifra = ljekar.Sifra
                };
                return View(editModel);

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateLjekarVM model)
        {
            var ljekar = await _context.Ljekar.FindAsync(model.LjekarId);
            if (!ModelState.IsValid)
                return View(model);
            if (ljekar != null)
            {
                ljekar.Ime = model.Ime;
                ljekar.Prezime = model.Prezime;
                ljekar.Titula = model.Titula;
                ljekar.Sifra = model.Sifra;
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var ljekar = await _context.Ljekar.FirstOrDefaultAsync(x => x.LjekarId == id);

            if (ljekar != null)
            {
                _context.Ljekar.Remove(ljekar);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
