using ERPS.Application.Interfaces.v1;
using ERPS.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERPS.Web.Controllers
{
    public class StatusController : Controller
    {
		private readonly IStatusService _svc;

		public StatusController(IStatusService svc)
		{
			_svc = svc;
		}

		public async Task<IActionResult> Index()
        {
            var data = await _svc.GetAllAsync([]);
            return View(data);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var data = await _svc.GetByIDAsync(id);

			return View(data);
        }
    }
}
