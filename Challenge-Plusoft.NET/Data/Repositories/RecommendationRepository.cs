using Microsoft.EntityFrameworkCore;
using PlusoftRecommender.Data;
using PlusoftRecommender.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusoftRecommender.Repositories
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly ApplicationDbContext _context;

        public RecommendationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync()
        {
            // Retorna todas as recomenda��es
            return await _context.Recommendations
                .Include(r => r.User)       // Inclui o usu�rio associado (opcional)
                .Include(r => r.Product)    // Inclui o produto associado (opcional)
                .ToListAsync();
        }

        public async Task<Recommendation> GetRecommendationByIdAsync(int id)
        {
            // Retorna uma recomenda��o pelo ID
            return await _context.Recommendations
                .Include(r => r.User)       // Inclui o usu�rio associado (opcional)
                .Include(r => r.Product)    // Inclui o produto associado (opcional)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendationsByUserIdAsync(int userId)
        {
            // Retorna todas as recomenda��es feitas por um usu�rio espec�fico
            return await _context.Recommendations
                .Where(r => r.UserId == userId)
                .Include(r => r.Product)    // Inclui o produto associado (opcional)
                .ToListAsync();
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendationsByProductIdAsync(int productId)
        {
            // Retorna todas as recomenda��es para um produto espec�fico
            return await _context.Recommendations
                .Where(r => r.ProductId == productId)
                .Include(r => r.User)       // Inclui o usu�rio associado (opcional)
                .ToListAsync();
        }

        public async Task AddRecommendationAsync(Recommendation recommendation)
        {
            // Adiciona uma nova recomenda��o ao contexto e salva as altera��es
            _context.Recommendations.Add(recommendation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecommendationAsync(Recommendation recommendation)
        {
            // Atualiza uma recomenda��o existente no contexto e salva as altera��es
            _context.Recommendations.Update(recommendation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecommendationAsync(int id)
        {
            // Encontra a recomenda��o pelo ID e remove, se encontrada
            var recommendation = await _context.Recommendations.FindAsync(id);
            if (recommendation != null)
            {
                _context.Recommendations.Remove(recommendation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
