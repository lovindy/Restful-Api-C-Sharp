using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRestApi.Models;

namespace MyRestApi.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _context.Users
				.Include(u => u.Products)
				.ToListAsync();
		}

		public async Task<User> GetByIdAsync(int id)
		{
			return await _context.Users
				.Include(u => u.Products)
				.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User> GetByEmailAsync(string email)
		{
			return await _context.Users
				.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<User> GetByUsernameAsync(string username)
		{
			return await _context.Users
				.FirstOrDefaultAsync(u => u.Username == username);
		}

		public async Task<User> CreateAsync(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return user;
		}

		public async Task<User> UpdateAsync(User user)
		{
			_context.Entry(user).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return user;
		}

		public async Task DeleteAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
			}
		}
	}
}
