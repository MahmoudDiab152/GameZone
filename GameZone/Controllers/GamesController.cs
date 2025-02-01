using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
	public class GamesController : Controller
	{
		private readonly ICategoriesService _categoriesService;
		private readonly IDevicesService _devicesService;
		private readonly IGameService _gamesService;

		public GamesController(ICategoriesService categoriesService, IDevicesService devicesService, IGameService gamesService)
		{
			_categoriesService = categoriesService;
			_devicesService = devicesService;
			_gamesService = gamesService;
		}

		public IActionResult Index()
		{
			var games = _gamesService.GetAll();
			return View(games);
		}
		[HttpGet]
		public IActionResult Create()

		{
			CreateGameFormViewModel viewModel = new CreateGameFormViewModel
			{
				Categories = _categoriesService.GetSelectList(),
				Devices = _devicesService.GetSelctList()

			};
			return View(viewModel);
		}
		[HttpPost]
		[AutoValidateAntiforgeryToken]

		public async Task<IActionResult> Create(CreateGameFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _categoriesService.GetSelectList();
				model.Devices = _devicesService.GetSelctList();

				return View(model);
			}
			await _gamesService.Create(model);
			return RedirectToAction(nameof(Index));

		}
		public IActionResult Details(int id)
		{
			var game = _gamesService.GetById(id);
			if (game == null)
				return NotFound();
			return View(game);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var game = _gamesService.GetById(id);
			if (game is null)
				return NotFound();
			EditGameFormViewModel viewModel = new()
			{
				Id = id,
				Name = game.Name,
				Description = game.Description,
				CategoryId = game.CategoryId,
				SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
				Categories = _categoriesService.GetSelectList(),
				Devices = _devicesService.GetSelctList(),
				CurrentCover = game.Cover,
			};
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditGameFormViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.Categories = _categoriesService.GetSelectList();
				viewModel.Devices = _devicesService.GetSelctList();
				return View(viewModel);
			}
			var game = await _gamesService.Update(viewModel);
			if (game is null) return BadRequest();
			return RedirectToAction(nameof(Index));
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var isDeleted = _gamesService.Delete(id);
			return isDeleted ? Ok() : BadRequest();
		}

	}
}
