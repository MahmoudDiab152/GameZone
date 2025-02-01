using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GameZone.ViewModels
{
	public class GameFormViewModel
	{
		[MaxLength(250)]
		public string Name { get; set; } = string.Empty;
		public IEnumerable<SelectListItem> Categories = Enumerable.Empty<SelectListItem>();
		[DisplayName("Category")]
		public int CategoryId { get; set; }

		public IEnumerable<SelectListItem> Devices = Enumerable.Empty<SelectListItem>();
		[Display(Name = "Supported Devices")]
		public List<int> SelectedDevices { get; set; } = default!;
		[MaxLength(2500)]
		public string Description { get; set; } = string.Empty;
	}
}
