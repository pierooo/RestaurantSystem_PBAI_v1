using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Helpers;

namespace RestaurantSystem.Administracja.Controllers.Abstract;

public abstract class BaseController<TEntity> : Controller
{
    protected readonly RestaurantContext context;
    protected readonly PartialValidator partialvalidator;

    public BaseController(RestaurantContext context, PartialValidator partialvalidator)
    {
        this.context = context;
        this.partialvalidator = partialvalidator;
    }

    // GET: Products
    public abstract Task<List<TEntity>> GetEntityList();


    public async Task<IActionResult> Index()
    {
        return View(await GetEntityList());
    }

    // GET: Products/Create
    public virtual Task SetSelectList()
    {
        return null;
    }

    public async Task<IActionResult> Create()
    {
        await SetSelectList();
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    public async Task<IActionResult> Create(TEntity entity)
    {
        if (ModelState.IsValid)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        await SetSelectList();
        return View(entity);
    }

    // GET: Products/Edit/5
    public abstract Task<TEntity> GetEntity(int? id);

    public async Task<IActionResult> Edit(int? id)
    {
        var item = await GetEntity(id);
        if (item == null)
        {
            return NotFound();
        }
        await SetSelectList();
        return View(item);
    }

    // POST: Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TEntity entity)
    {
        if (ModelState.IsValid)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        await SetSelectList();

        return RedirectToAction(nameof(Index));
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        var product = await GetEntity(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/5
    public abstract void RemoveEntity(TEntity entity);

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var entity = await GetEntity(id);
        if (entity != null)
        {
            RemoveEntity(entity);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
