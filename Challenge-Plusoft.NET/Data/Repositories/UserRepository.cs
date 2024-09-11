using Microsoft.EntityFrameworkCore;
using PlusoftRecommender.Data;
using PlusoftRecommender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlusoftRecommender.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserRepository()
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            // Retorna todos os usuários com suas respectivas informações
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id) =>
            // Retorna um usuário específico pelo ID
            await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task AddUserAsync(User user)
        {
            // Adiciona um novo usuário ao contexto e salva as alterações
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            // Atualiza um usuário existente no contexto e salva as alterações
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            // Encontra o usuário pelo ID e remove, se encontrado
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
