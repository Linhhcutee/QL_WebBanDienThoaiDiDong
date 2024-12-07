using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webbandienthoai.Models;

namespace webbandienthoai.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        QL_DienThoaiDiDongWebContext db = new QL_DienThoaiDiDongWebContext();
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhsachtaikhoan")]
        public IActionResult DanhSachTaiKhoan()
        {
            var lsNhanVien = db.Taikhoans // Chỉ lấy tài khoản có trạng thái "Hoạt động"
            .Join(db.VaiTros,
                tk => tk.VaiTroId,  // Trường khóa ngoại của bảng Taikhoan
                vt => vt.Id,        // Trường khóa chính của bảng VaiTro
                (tk, vt) => new TaiKhoanViewModel
                {  // Sử dụng ViewModel
                    TenTk = tk.TenTk,
                    Mk = tk.Mk,
                    HoDem = tk.HoDem,
                    Ten = tk.Ten,
                    VaiTro = vt.TenVaiTro,  // Tên vai trò
                    TrangThai = tk.TrangThai ?? false // Trạng thái
                })
            .ToList();
            return View(lsNhanVien);
        }
        [Route("themtaikhoan")]
        [HttpGet]
        public IActionResult ThemTaiKhoan()
        {
            ViewBag.VaiTroId = new SelectList(db.VaiTros.ToList(), "Id", "TenVaiTro");
            return View();
        }
        [Route("themtaikhoan")]
        [HttpPost]
        public IActionResult ThemTaiKhoan(Taikhoan tk)
        {
            if (ModelState.IsValid)
            {
                db.Taikhoans.Add(tk);
                db.SaveChanges();
                return RedirectToAction("danhsachtaikhoan");
            }
            ViewBag.VaiTroId = new SelectList(db.VaiTros.ToList(), "Id", "TenVaiTro");
            return View(tk);
        }
    }
}
