using Klinika.Database;
using Klinika.DB;
using Klinika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Klinika.Controllers
{
    public class PrijemController : Controller
    {
        private readonly MyDbContext _context;
        public PrijemController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(DateTime? datumOd, DateTime? datumDo)
        {
            if (!datumOd.HasValue)
            {
                datumOd = DateTime.Now.Date;
            }

            if (!datumDo.HasValue)
            {
                datumDo = new DateTime(DateTime.Now.Year, 12, 31);
            }
            var prijemi = await _context.Prijem.Where(x=>x.DatumPrijema >= datumOd && x.DatumPrijema <= datumDo).Include(x => x.Pacijent).Include(x => x.Ljekar).ToListAsync();
            ViewBag.DatumOd = datumOd;
            ViewBag.DatumDo = datumDo;
            return View(prijemi);

        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddPrijemVM();
            model.DatumPrijema = DateTime.Now;

            model.Pacijenti = _context.Pacijent.ToList().Select(p => new SelectListItem { Value = p.PacijentId.ToString(), Text = p.ImePrezime })
                .ToList();
            model.Pacijenti.Insert(0, new SelectListItem { Value = "0", Text = "Odaberite pacijenta", Selected = true });

            model.Ljekari = _context.Ljekar.Where(x => x.Titula == ((int)Helper.TitulaEnum.Specijalista).ToString())
                .Select(p => new SelectListItem { Value = p.LjekarId.ToString(), Text = p.Ime + " " + p.Prezime }).ToList();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPrijemVM addPrijemRequest)
        {
            if (!ModelState.IsValid)
            {
                addPrijemRequest.DatumPrijema = DateTime.Now;

                addPrijemRequest.Pacijenti = _context.Pacijent.ToList().Select(p => new SelectListItem { Value = p.PacijentId.ToString(), Text = p.ImePrezime })
                    .ToList();
                
                addPrijemRequest.Ljekari = _context.Ljekar.Where(x => x.Titula == ((int)Helper.TitulaEnum.Specijalista).ToString())
                    .Select(p => new SelectListItem { Value = p.LjekarId.ToString(), Text = p.Ime + " " + p.Prezime }).ToList();

                return View(addPrijemRequest);
            }

            var prijem = new Prijem()
                {
                    DatumPrijema = addPrijemRequest.DatumPrijema,
                    PacijentId = addPrijemRequest.PacijentId,
                    LjekarId = addPrijemRequest.LjekarId,
                    HitniPrijem = addPrijemRequest.HitniPrijem,
                };
                await _context.Prijem.AddAsync(prijem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var prijem = await _context.Prijem.FirstOrDefaultAsync(x => x.PrijemId == id);
            if (prijem != null)
            {
                var model = new UpdatePrijemVM();

                model.Pacijenti = _context.Pacijent.ToList().Select(p => new SelectListItem { Value = p.PacijentId.ToString(), Text = p.ImePrezime })
                .ToList();

                model.Ljekari = _context.Ljekar.Where(x => x.Titula == ((int)Helper.TitulaEnum.Specijalista).ToString())
                    .Select(p => new SelectListItem { Value = p.LjekarId.ToString(), Text = p.Ime + " " + p.Prezime }).ToList();

                model.PrijemId = prijem.PrijemId;
                model.DatumPrijema = prijem.DatumPrijema;
                model.PacijentId = prijem.PacijentId;
                model.LjekarId = prijem.LjekarId;
                model.HitniPrijem = prijem.HitniPrijem;
                
                return View(model);

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePrijemVM model)
        {
            var prijem = await _context.Prijem.FindAsync(model.PrijemId);

            if (!ModelState.IsValid)
            {
                model.Pacijenti = _context.Pacijent.ToList().Select(p => new SelectListItem { Value = p.PacijentId.ToString(), Text = p.ImePrezime })
              .ToList();
                model.Ljekari = _context.Ljekar.Where(x => x.Titula == ((int)Helper.TitulaEnum.Specijalista).ToString())
                    .Select(p => new SelectListItem { Value = p.LjekarId.ToString(), Text = p.Ime + " " + p.Prezime }).ToList();
                return View(model);
            }
            if (prijem != null)
            {
                prijem.DatumPrijema = model.DatumPrijema;
                prijem.PacijentId = model.PacijentId;
                prijem.LjekarId = model.LjekarId;
                prijem.HitniPrijem = model.HitniPrijem;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var prijem = await _context.Prijem.FirstOrDefaultAsync(x => x.PrijemId == id);

            if (prijem != null)
            {
                _context.Prijem.Remove(prijem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        public void UcitajDropdow()
        {
            
            //List<Pacijent> pacijenti = _context.Pacijent.ToList();
            //List<SelectListItem> pacijentiList = pacijenti
            //    .Select(p => new SelectListItem { Value = p.PacijentId.ToString(), Text = p.ImePrezime })
            //    .ToList();
            //ViewBag.pacijenti = pacijentiList;

            //List<Ljekar> ljekari = _context.Ljekar.ToList();
            //List<SelectListItem> ljekariList = ljekari.Where(x => x.Titula == "1")
            //    .Select(p => new SelectListItem { Value = p.LjekarId.ToString(), Text = p.Ime + " " + p.Prezime })
            //    .ToList();
            //ViewBag.ljekari = ljekariList;
        }
    }
}

