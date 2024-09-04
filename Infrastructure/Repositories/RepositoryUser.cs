using Infrastructure.Data;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class RepositoryUser : InterfaceUser
{
    private readonly UserDbContext _context;

    public RepositoryUser(UserDbContext context)
    {
        _context = context;
    }

    public async Task CreateUser(User user)
    {
        await _context.Set<User>().AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _context.Set<User>().FindAsync(id);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
    }
}