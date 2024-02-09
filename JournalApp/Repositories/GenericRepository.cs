using JournalApp.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JournalApp.Repositories;

internal class GenericRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    public GenericRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<TEntity> Create(TEntity entity)
    {
        try
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity!;
        }
        catch( Exception ex )
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        try
        {
            var entity = await _context.Set<TEntity>().ToListAsync();
            return entity!;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<TEntity> Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var updateEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            _context.Entry(updateEntity!).CurrentValues.SetValues(entity); 
            await _context.SaveChangesAsync();
            return updateEntity!;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            _context.Remove(entity!); 
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
