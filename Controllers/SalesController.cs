﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory.Models;
using projectDemo.Data;

namespace projectDemo.Controllers
{
    public class SalesController : Controller
    {
        private readonly projectDemoContext _context;

        public SalesController(projectDemoContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var projectDemoContext = _context.Sales.Include(s => s.Order).Include(s => s.product);
            return View(await projectDemoContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales
                .Include(s => s.Order)
                .Include(s => s.product)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // G
        // ET: Sales/Create
        //public IActionResult Create()
        //{










        //    ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId");
        //    ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
        //    return View();
        //}

        //// POST: Sales/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("SaleId,Quantity,TotalAmount,OrderId,ProductId")] Sales sales)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Product product = _context.Set<Product>().Where(x => x.ProductId == sales.ProductId).FirstOrDefault();
        //        if (sales.Quantity < product.Stock)
        //        {
        //            _context.Add(sales);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));

        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Stock is less");
        //            return View(sales);
        //        }

        //    }
        //    ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", sales.OrderId);
        //    ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", sales.ProductId);
        //    return View(sales);
        //}

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", sales.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", sales.ProductId);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,Quantity,TotalAmount,OrderId,ProductId")] Sales sales)
        {
            if (id != sales.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesExists(sales.SaleId))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", sales.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", sales.ProductId);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales
                .Include(s => s.Order)
                .Include(s => s.product)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sales = await _context.Sales.FindAsync(id);
            if (sales != null)
            {
                _context.Sales.Remove(sales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesExists(int id)
        {
            return _context.Sales.Any(e => e.SaleId == id);
        }
    }
}
