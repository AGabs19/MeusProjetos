/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Excel.DataBase;
using Excel.Models;

namespace Excel.Controllers
{
    public class ExcelModelsController : Controller
    {
        private readonly ExcelContext _context;

        public ExcelModelsController(ExcelContext context)
        {
            _context = context;
        }

        // GET: ExcelModels
        public async Task<IActionResult> Index()
        {
              return _context.Movie != null ? 
                          View(await _context.Movie.ToListAsync()) :
                          Problem("Entity set 'ExcelContext.ExcelModel'  is null.");
        }

        // GET: ExcelModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ExcelModel == null)
            {
                return NotFound();
            }

            var excelModel = await _context.ExcelModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excelModel == null)
            {
                return NotFound();
            }

            return View(excelModel);
        }

        // GET: ExcelModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExcelModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,CPF,Numero,Descricao,Longadouro,NumeroCasa,CEP,Complemento,Cargo,DataInicio,Salario,DataInicio2,DataFim2,ObservacaoFuncionario")] ExcelModel excelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excelModel);
        }

        // GET: ExcelModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ExcelModel == null)
            {
                return NotFound();
            }

            var excelModel = await _context.ExcelModel.FindAsync(id);
            if (excelModel == null)
            {
                return NotFound();
            }
            return View(excelModel);
        }

        // POST: ExcelModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Sobrenome,CPF,Numero,Descricao,Longadouro,NumeroCasa,CEP,Complemento,Cargo,DataInicio,Salario,DataInicio2,DataFim2,ObservacaoFuncionario")] ExcelModel excelModel)
        {
            if (id != excelModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcelModelExists(excelModel.Id))
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
            return View(excelModel);
        }

        // GET: ExcelModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ExcelModel == null)
            {
                return NotFound();
            }

            var excelModel = await _context.ExcelModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excelModel == null)
            {
                return NotFound();
            }

            return View(excelModel);
        }

        // POST: ExcelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ExcelModel == null)
            {
                return Problem("Entity set 'ExcelContext.ExcelModel'  is null.");
            }
            var excelModel = await _context.ExcelModel.FindAsync(id);
            if (excelModel != null)
            {
                _context.ExcelModel.Remove(excelModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcelModelExists(long id)
        {
          return (_context.ExcelModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
*/