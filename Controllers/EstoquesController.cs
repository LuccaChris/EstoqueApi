// Controllers/EstoquesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EstoquesController : ControllerBase
{
    private readonly MeuDbContext _context;

    public EstoquesController(MeuDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoques()
    {
        return await _context.Estoques.Include(e => e.Produto).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Estoque>> CreateEstoque(Estoque estoque)
    {
        _context.Estoques.Add(estoque);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEstoques), new { id = estoque.IdEstoque }, estoque);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEstoque(int id, Estoque estoque)
    {
        if (id != estoque.IdEstoque)
        {
            return BadRequest();
        }

        _context.Entry(estoque).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstoqueExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstoque(int id)
    {
        var estoque = await _context.Estoques.FindAsync(id);
        if (estoque == null)
        {
            return NotFound();
        }

        _context.Estoques.Remove(estoque);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EstoqueExists(int id)
    {
        return _context.Estoques.Any(e => e.IdEstoque == id);
    }
}
