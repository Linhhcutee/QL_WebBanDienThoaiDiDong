using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using webbandienthoai.Models;

namespace webbandienthoai.Controllers
{
    public class UpdateProductsController : Controller
    {
        QL_DienThoaiDiDongWebContext db = new QL_DienThoaiDiDongWebContext();
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham()
        {
            var lsSanPham = db.Sanphams.ToList();
            return View(lsSanPham);
        }
        [Route("themsanpham")]
        [HttpGet]
        public IActionResult Themsanpham()
        {
            ViewBag.MaThuongHieu = new SelectList(db.Thuonghieus.ToList(), "Id", "Ten");
            return View();
        }
        [Route("themsanpham")]
        [HttpPost]
        public IActionResult Themsanpham(Sanpham sp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Sanphams.Add(sp);
                    db.SaveChanges();
                    return RedirectToAction("DanhMucSanPham");
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi (nếu cần)
                    Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");

                    // Gửi thông báo lỗi đến view
                    ModelState.AddModelError("", "Có lỗi xảy ra khi thêm sản phẩm. Vui lòng thử lại!");
                }
            }

            // Nếu không hợp lệ hoặc lỗi xảy ra, trả về view với model hiện tại
            return View(sp);
        }
        [Route("suasanpham")]
        [HttpGet]
        public IActionResult SuaSanPham(string Tensp)
        {
            ViewBag.MaThuongHieu = new SelectList(db.Thuonghieus.ToList(), "Id", "Ten");
            var sanpham = db.Sanphams.Find(Tensp);
            return View(sanpham);
        }
        [Route("suasanpham")]
        [HttpPost]
        public IActionResult SuaSanPham(Sanpham sp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            ViewBag.MaThuongHieu = new SelectList(db.Thuonghieus.ToList(), "Id", "Ten");
            return View(sp);
        }
        [Route("nhapkho")]
        [HttpGet]
        public IActionResult NhapKho()
        {
            ViewBag.TenNv = new SelectList(db.Taikhoans.ToList(), "TenTk", "Ten");
            ViewBag.DanhSachPhieuNhapKho = db.Phieunhapkhos
            .OrderByDescending(pnk => pnk.Maphieunhapkho) // Sắp xếp giảm dần theo Maphieunhapkho
            .Select(pnk => new
            {
                pnk.Maphieunhapkho,
                pnk.TenNv,
                pnk.Trangthaitt,
                pnk.Thoigian,
                pnk.Tongtien,
                pnk.Mota
            })
            .ToList();
            return View();
        }
        [Route("nhapkho")]
        [HttpPost]
        public IActionResult NhapKho(Phieunhapkho pn)
        {
            if (pn.Trangthaitt.Length != 0)
            {
                db.Phieunhapkhos.Add(pn);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            ViewBag.TenNv = new SelectList(db.Taikhoans.ToList(), "TenTk", "Ten");
            return View(pn);
        }
        [Route("CTPhieuNhapKho")]
        [HttpGet]
        public IActionResult CTPhieuNhapKho()
        {
            ViewBag.Ten = new SelectList(db.Sanphams.ToList(), "Ten", "Ten");
            ViewBag.Maphieunhap = new SelectList(db.Phieunhapkhos
                                      .OrderByDescending(p => p.Thoigian)
                                      .ToList(),
                                      "Maphieunhapkho",
                                      "Maphieunhapkho");

            ViewBag.LoaiSp = new SelectList(db.LoaiSps.ToList(), "Id", "Tenloai");
            // Lấy danh sách chi tiết phiếu nhập kho (hiển thị tất cả ban đầu)
            ViewBag.ChiTietPhieuNhapKho = db.Chitietpnks
            .Include(c => c.MaphieunhapNavigation) // Nạp đối tượng điều hướng Phiếu Nhập Kho
            .OrderByDescending(c => c.MaphieunhapNavigation.Maphieunhapkho) // Sắp xếp giảm dần theo Maphieunhapkho
            .ToList();

            return View();
        }
        [Route("CTPhieuNhapKho")]
        [HttpPost]
        public IActionResult CTPhieuNhapKho(Chitietpnk ctpnk)
        {
            if (ctpnk.Soluong > 0)
            {
                db.Chitietpnks.Add(ctpnk);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            TempData["ErrorMessage"] = "Số lượng phải lớn hơn 0.";
            TempData["Soluong"] = ctpnk.Soluong;
            ViewBag.Ten = new SelectList(db.Sanphams.ToList(), "Ten", "Ten");
            ViewBag.Maphieunhap = new SelectList(db.Phieunhapkhos.ToList(), "Maphieunhapkho", "Maphieunhapkho");
            ViewBag.LoaiSp = new SelectList(db.LoaiSps.ToList(), "Id", "Tenloai");
            return View(ctpnk);
        }
        [Route("NhapPhieuKho")]
        [HttpGet]
        public IActionResult NhapPhieuKho()
        {
            ViewBag.TenNv = new SelectList(
                db.Taikhoans.Where(tk => tk.VaiTroId == 4).ToList(),
                "TenTk",
                "Ten"
            );
            ViewBag.Ten = new SelectList(db.Sanphams.ToList(), "Ten", "Ten");
            ViewBag.LoaiSp = new SelectList(db.LoaiSps.ToList(), "Id", "Tenloai");
            return View(new NhapPhieuKhoViewModel());
        }
        [Route("NhapPhieuKho")]
        [HttpPost]
        public IActionResult NhapPhieuKho(Phieunhapkho phieuNhap, List<Chitietpnk> chiTietNhap)
        {
            try
            {
                using (var connection = db.Database.GetDbConnection())
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "InsertPhieuNhapKhoAndChiTiet";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số cho Phiếu Nhập Kho
                        command.Parameters.Add(new SqlParameter("@TenNv", phieuNhap.TenNv));
                        command.Parameters.Add(new SqlParameter("@Trangthaitt", phieuNhap.Trangthaitt));
                        command.Parameters.Add(new SqlParameter("@Mota", phieuNhap.Mota));

                        // Tạo DataTable để truyền chi tiết nhập kho
                        var chiTietTable = new DataTable();
                        chiTietTable.Columns.Add("Soluong", typeof(int));
                        chiTietTable.Columns.Add("GiaNhap", typeof(decimal));
                        chiTietTable.Columns.Add("Ghichu", typeof(string));
                        chiTietTable.Columns.Add("LoaiSp", typeof(int));
                        chiTietTable.Columns.Add("TenSanPham", typeof(string));

                        // Thêm các chi tiết vào DataTable
                        foreach (var chiTiet in chiTietNhap)
                        {
                            chiTietTable.Rows.Add(chiTiet.Soluong, chiTiet.GiaNhap, chiTiet.Ghichu, chiTiet.LoaiSp, chiTiet.TenSanPham);
                        }

                        // Thêm tham số cho Table Type
                        var chiTietParam = new SqlParameter("@ChiTietNhap", SqlDbType.Structured)
                        {
                            TypeName = "dbo.ChiTietNhapTableType", // Tên của table type trong SQL Server
                            Value = chiTietTable
                        };
                        command.Parameters.Add(chiTietParam);

                        // Thực thi thủ tục
                        command.ExecuteNonQuery();
                    }
                }

                TempData["SuccessMessage"] = "Dữ liệu đã được lưu thành công!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra: " + ex.Message;
            }

            // Load lại ViewModel để hiển thị dữ liệu
            return RedirectToAction("NhapPhieuKho");
        }
    }
}
