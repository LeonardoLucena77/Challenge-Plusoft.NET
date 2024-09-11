using PlusoftRecommender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlusoftRecommender.Repositories
{
    public interface IRecommendationRepository
    {
        Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync();
        Task<Recommendation> GetRecommendationByIdAsync(int id);
        Task AddRecommendationAsync(Recommendation recommendation);
        Task UpdateRecommendationAsync(Recommendation recommendation);
        Task DeleteRecommendationAsync(int id);
        Task<IEnumerable<Recommendation>> GetRecommendationsByUserIdAsync(int userId);
        Task<IEnumerable<Recommendation>> GetRecommendationsByProductIdAsync(int productId);
    }
}
