using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webbandienthoai.Models;
using X.PagedList;

namespace webbandienthoai.Controllers
{
	public class HomeController : Controller
	{
		QL_DienThoaiDiDongWebContext db = new QL_DienThoaiDiDongWebContext();
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(int? page)
		{
			int pageSize = 12;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var lstsanpham = db.Sanphams
			.Include(sp => sp.MaThuongHieuNavigation)
			.Include(sp => sp.Ctsanphams)
			.Where(sp => sp.Sl > 0)
			.AsNoTracking()
			.OrderBy(sp => sp.Ten);
			PagedList<Sanpham> ls = new PagedList<Sanpham>(lstsanpham, pageNumber, pageSize);
			return View(ls);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}