using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameZone.Services
{
	public interface IDevicesService
	{
		IEnumerable<SelectListItem> GetSelctList();
	}
}
