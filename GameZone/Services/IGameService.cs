using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Services
{
	public interface IGameService
	{
		Task Create(CreateGameFormViewModel game);
		IEnumerable<Game> GetAll();
		Game? GetById(int id);
		Task<Game?> Update(EditGameFormViewModel game);
		bool Delete(int id);
	}
}
