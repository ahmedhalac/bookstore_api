using BookStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repository;

public class Repository<T, TContext> : IRepository<T>
    where T : class
    where TContext: DbContext
{

    private readonly TContext context;

    public Repository(TContext context)
    {
        this.context = context;
    }

    public async Task<T> Add(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Delete(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        if(entity == null)
        {
            return null;
        }

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
        return entity;

    }

    public async Task<T> Get(int id)
    {
        return await context.Set<T>().FindAsync(id);

    }

    public async Task<List<T>> GetAll()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T> Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
}

