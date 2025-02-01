using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
	public class DevicesService : IDevicesService
	{
		private readonly ApplicationDbContext _context;

		public DevicesService(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<SelectListItem> GetSelctList()
		{
			return _context.Devices.Select(x=>new SelectListItem { Value=x.Id.ToString(),Text=x.Name}).OrderBy(c=>c.Text).AsNoTracking().ToList();
		}
	}
}
