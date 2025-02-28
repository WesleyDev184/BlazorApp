using BlazorApp.Data;
using BlazorApp.Modules.Users.Entity;

namespace BlazorApp.Modules.Users;

public class UserServices
{

  private readonly AppDbContext _context;

  public UserServices(AppDbContext context)
  {
    _context = context;
  }

  public async Task<User> Create(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<User> Update(User user)
  {
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<User> Delete(Guid id)
  {
    var user = await _context.Users.FindAsync(id);
    if (user == null)
    {
      return null;
    }

    user.IsActive = false;
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return user;
  }

  //get all users
  public async Task<List<User>> GetAll()
  {
    return await _context.Users
                .Select()
                .ToListAsync();
  }

}
