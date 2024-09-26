// Controllers/FornecedoresController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class FornecedoresController : ControllerBase
{
    private readonly MeuDbContext _context;

    public FornecedoresController(MeuDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
    {
        return await _context.Fornecedores.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Fornecedor>> CreateFornecedor(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFornecedores), new { id = fornecedor.IdFornecedor }, fornecedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFornecedor(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.IdFornecedor)
        {
            return BadRequest();
        }

        _context.Entry(fornecedor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FornecedorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
