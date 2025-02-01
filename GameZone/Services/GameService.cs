using GameZone.Models;
using GameZone.Settings;
using GameZone.ViewModels;

namespace GameZone.Services
{
	public class GameService : IGameService
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _ImagesPath;

		public GameService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			_ImagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
		}

		public async Task Create(CreateGameFormViewModel model)
		{
			var coverName = await SaveCover(model.Cover);
			Game game = new()
			{
				Name = model.Name,
				CategoryId = model.CategoryId,
				Cover = coverName,
				Description = model.Description,
				Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()

			};
			_context.Add(game);
			_context.SaveChanges();
		}

		public bool Delete(int id)
		{
			var isDeleted = false;
			var game = _context.Games.Find(id);
			if(game is null) {
				return isDeleted;
			}
			_context.Games.Remove(game);
			var effectedRows = _context.SaveChanges();
			if(effectedRows>0)
			{
				isDeleted = true;
				var cover = Path.Combine(_ImagesPath, game.Cover);
				File.Delete(cover);
			}
			return isDeleted;
		}

		public IEnumerable<Game> GetAll()
		{
			return _context.Games.Include(x =>  x.Category).Include(i=>i.Devices).ThenInclude(o=>o.Device).AsNoTracking().ToList();
		}

		public Game? GetById(int id)
		{
			return _context.Games.Include(x => x.Category).Include(i => i.Devices).ThenInclude(o => o.Device).AsNoTracking().FirstOrDefault(x => x.Id == id);

		}

		public async Task<Game?> Update(EditGameFormViewModel model)
		{
			var game = _context.Games.Include(g=>g.Devices).SingleOrDefault(c=>c.Id == model.Id);
			if(game is  null) 
				return null;
			var hasNewCover = model.Cover != null;
			var oldCover = game.Cover;
			game.Name = model.Name;
			game.Description = model.Description;
			game.CategoryId = model.CategoryId;
			game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();
			if (hasNewCover)
			{
				game.Cover = await SaveCover(model.Cover!);
			}
			var effectedRows = _context.SaveChanges();
			if(effectedRows>0)
			{
				if (hasNewCover)
				{
					var cover = Path.Combine(_ImagesPath, oldCover);
					File.Delete(cover);
				}
			return game;
			}
			else
			{
				var cover = Path.Combine(_ImagesPath, game.Cover);
				File.Delete(cover);
				return null;
			}
		}
		private async Task<string> SaveCover(IFormFile cover)
		{
			var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
			var path = Path.Combine(_ImagesPath, coverName);
			using var stream = File.Create(path);
			await cover.CopyToAsync(stream);
			return coverName;
		}
	}
}
