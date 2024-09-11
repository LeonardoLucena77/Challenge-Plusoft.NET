using PlusoftRecommender.Models;
using PlusoftRecommender.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlusoftRecommender.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<IEnumerable<User>> GetAllUsersAsync()
		{
			return await _userRepository.GetAllUsersAsync();
		}

		public async Task<User> GetUserByIdAsync(int id)
		{
			return await _userRepository.GetUserByIdAsync(id);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await _userRepository.GetUserByEmailAsync(email);
		}

		public async Task AddUserAsync(User user)
		{
			await _userRepository.AddUserAsync(user);
		}

		public async Task UpdateUserAsync(User user)
		{
			await _userRepository.UpdateUserAsync(user);
		}

		public async Task DeleteUserAsync(int id)
		{
			await _userRepository.DeleteUserAsync(id);
		}
	}
}
