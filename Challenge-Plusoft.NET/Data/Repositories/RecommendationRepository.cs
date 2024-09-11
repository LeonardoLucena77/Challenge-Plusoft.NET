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
            // Retorna todas as recomendações
            return await _context.Recommendations
                .Include(r => r.User)       // Inclui o usuário associado (opcional)
                .Include(r => r.Product)    // Inclui o produto associado (opcional)
                .ToListAsync();
        }

        public async Task<Recommendation> GetRecommendationByIdAsync(int id)
        {
            // Retorna uma recomendação pelo ID
            return await _context.Recommendations
                .Include(r => r.User)       // Inclui o usuário associado (opcional)
                .Include(r => r.Product)    // Inclui o produto associado (opcional)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendationsByUserIdAsync(int userId)
        {
            // Retorna todas as recomendações feitas por um usuário específico
            return await _context.Recommendations
                .Where(r => r.UserId == userId)
                .Include(r => r.Product)    // Inclui o produto associado (opcional)
                .ToListAsync();
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendationsByProductIdAsync(int productId)
        {
            // Retorna todas as recomendações para um produto específico
            return await _context.Recommendations
                .Where(r => r.ProductId == productId)
                .Include(r => r.User)       // Inclui o usuário associado (opcional)
                .ToListAsync();
        }

        public async Task AddRecommendationAsync(Recommendation recommendation)
        {
            // Adiciona uma nova recomendação ao contexto e salva as alterações
            _context.Recommendations.Add(recommendation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecommendationAsync(Recommendation recommendation)
        {
            // Atualiza uma recomendação existente no contexto e salva as alterações
            _context.Recommendations.Update(recommendation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecommendationAsync(int id)
        {
            // Encontra a recomendação pelo ID e remove, se encontrada
            var recommendation = await _context.Recommendations.FindAsync(id);
            if (recommendation != null)
            {
                _context.Recommendations.Remove(recommendation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
