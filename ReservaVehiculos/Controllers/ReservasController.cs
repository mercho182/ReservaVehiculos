using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReservaVehiculos.Data;
using ReservaVehiculos.Models;

namespace ReservaVehiculos.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ReservaVehiculosContext _context;

        public ReservasController(ReservaVehiculosContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter ,string searchString,
                                                int? page)
        {
            ViewData["LugarPSortParm"] = String.IsNullOrEmpty(sortOrder) ? "lugarP_desc" : "";
            ViewData["FechaPSortParm"]=sortOrder == "fechaP_asc"? "fechaP_desc": "fechaP_asc";

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var reservas = from s in _context.Reserva select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                reservas = reservas.Where(s => s.LugarPickup.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "lugarP_desc":
                    reservas = reservas.OrderByDescending(s => s.LugarPickup);
                    break;
                case "fechaP_desc":
                    reservas = reservas.OrderByDescending(s => s.FechaPickup);
                    break;
                case "fechaP_asc":
                    reservas = reservas.OrderBy(s => s.FechaPickup);
                    break;
                default:
                    reservas = reservas.OrderBy(s => s.LugarPickup);
                    break;
            }
            //return View(await reservas.AsNoTracking().ToListAsync());
            //return View(await _context.Reserva.ToListAsync());
            int pageSize = 10;
            return View(await Paginacion<Reserva>.CreateAsync(reservas.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .FirstOrDefaultAsync(m => m.Reservaid == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Reservaid,NombreCliente,Correo,FechaPickup,LugarPickup,FechaDropoff,LugarDropoff,Marca,Modelo,Precio")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Reservaid,NombreCliente,Correo,FechaPickup,LugarPickup,FechaDropoff,LugarDropoff,Marca,Modelo,Precio")] Reserva reserva)
        {
            if (id != reserva.Reservaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Reservaid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .FirstOrDefaultAsync(m => m.Reservaid == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Reservaid == id);
        }

        
    }
}
