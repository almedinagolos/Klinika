using Klinika.Database;
using Klinika.DB;
using Klinika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Controllers
{
    public class PacijentController : Controller
    {
        private readonly MyDbContext _context;
        public PacijentController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pacijenti = await _context.Pacijent.ToListAsync();
            
            return View(pacijenti);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddPacijentVM());
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPacijentVM addPacijentaRequest)
        {
            if(!ModelState.IsValid)
                return View();

            var pacijent = new Pacijent()
            {
                ImePrezime = addPacijentaRequest.ImePrezime,
                DatumRodjenja = (DateTime)addPacijentaRequest.DatumRodjenja,
                Spol = addPacijentaRequest.Spol,
                Adresa = addPacijentaRequest.Adresa,
                BrojTelefona = addPacijentaRequest.BrojTelefona
            };
            await _context.Pacijent.AddAsync(pacijent);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index"); 
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pacijent = await _context.Pacijent.FirstOrDefaultAsync(x => x.PacijentId == id);
            if (pacijent != null)
            {
                var editModel = new UpdatePacijentVM()
                {
                    PacijentId = pacijent.PacijentId,
                    ImePrezime = pacijent.ImePrezime,
                    DatumRodjenja = pacijent.DatumRodjenja,
                    Spol = pacijent.Spol,
                    Adresa = pacijent.Adresa,
                    BrojTelefona = pacijent.BrojTelefona
                };
                return View(editModel);
            }
                return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePacijentVM model)
        {
            var pacijent = await _context.Pacijent.FindAsync(model.PacijentId);
            if(!ModelState.IsValid)
                return View(model);

            if(pacijent != null)
            {
                pacijent.ImePrezime = model.ImePrezime;
                pacijent.DatumRodjenja = (DateTime)model.DatumRodjenja;
                pacijent.Spol = model.Spol;
                pacijent.Adresa = model.Adresa;
                pacijent.BrojTelefona = model.BrojTelefona;
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var pacijent = await _context.Pacijent.FirstOrDefaultAsync(x => x.PacijentId == id);

            if (pacijent != null)
            {
                _context.Pacijent.Remove(pacijent);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
