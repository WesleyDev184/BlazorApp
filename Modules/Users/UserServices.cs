using BlazorApp.Data;
using BlazorApp.Modules.Users.Dto;
using BlazorApp.Modules.Users.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Modules.Users;

public class UserServices(AppDbContext context)
{

  private readonly AppDbContext _context = context;

  public async Task<User> Create(User user)
  {

    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<User> Update(string? name, string? cpf, Guid id)
  {
    var user = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");

    user.UpdateUser(name, cpf);

    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<bool> Delete(Guid id)
  {
    var user = await _context.Users.FindAsync(id) ;

    if (user == null)
    {
      return false;
    }

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<List<ResponseEntityUserDTO>> GetAll()
  {
    return await _context.Users
                .Select(u => new ResponseEntityUserDTO(u.Id, u.Name, u.CPF))
                .ToListAsync();
  }

  public async Task<User> GetById(Guid id)
  {
    var user = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");

    return user;
  }

}
