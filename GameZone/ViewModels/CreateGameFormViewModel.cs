using GameZone.Models;
using GameZone.Attributes;

using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GameZone.ViewModels
{
	public class CreateGameFormViewModel : GameFormViewModel
	{
		
		[AllowedExtension(FileSettings.AllowedExtensions)]
		[MaxFileSize(FileSettings.MaxFileSizeInBytes)]
		public IFormFile Cover { get; set; } = default!;

	}
}
