using PlusoftRecommender.Models;
using PlusoftRecommender.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlusoftRecommender.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        public async Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync()
        {
            return await _recommendationRepository.GetAllRecommendationsAsync();
        }

        public async Task<Recommendation> GetRecommendationByIdAsync(int id)
        {
            return await _recommendationRepository.GetRecommendationByIdAsync(id);
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendationsByUserIdAsync(int userId)
        {
            return await _recommendationRepository.GetRecommendationsByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendationsByProductIdAsync(int productId)
        {
            return await _recommendationRepository.GetRecommendationsByProductIdAsync(productId);
        }

        public async Task AddRecommendationAsync(Recommendation recommendation)
        {
            await _recommendationRepository.AddRecommendationAsync(recommendation);
        }

        public async Task UpdateRecommendationAsync(Recommendation recommendation)
        {
            await _recommendationRepository.UpdateRecommendationAsync(recommendation);
        }

        public async Task DeleteRecommendationAsync(int id)
        {
            await _recommendationRepository.DeleteRecommendationAsync(id);
        }
    }
}
