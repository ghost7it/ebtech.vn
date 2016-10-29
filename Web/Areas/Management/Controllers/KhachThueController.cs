﻿using Common;
using Entities.Enums;
using Entities.Models;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Areas.Management.Filters;
using Web.Areas.Management.Helpers;
using Web.Helpers;

namespace Web.Areas.Management.Controllers
{
    [RouteArea("Management", AreaPrefix = "quan-ly")]
    [RoutePrefix("khachthue")]
    public class KhachThueController : BaseController
    {
        [Route("danh-sach-khach-thue", Name = "KhachThueIndex")]
        [ValidationPermission(Action = ActionEnum.Read, Module = ModuleEnum.Khach)]
        public ActionResult Index()
        {
            return View();
        }

        [Route("them-moi-khach-thue", Name = "KhachThueCreate")]
        [ValidationPermission(Action = ActionEnum.Create, Module = ModuleEnum.Khach)]
        public async Task<ActionResult> Create()
        {
            //ViewBag.CategoryTypes = await _repository.GetRepository<CategoryType>().GetAllAsync();
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Route("them-moi-khach-thue")]
        [ValidationPermission(Action = ActionEnum.Create, Module = ModuleEnum.Khach)]
        public async Task<ActionResult> Create(KhachThueCreatingViewModel model)
        {
            if (ModelState.IsValid)
            {
                Khach khach = new Khach();

                khach.GhiChu = StringHelper.KillChars(model.GhiChu);
                khach.LinhVuc = StringHelper.KillChars(model.LinhVuc);
                khach.NgayTao = DateTime.Now;
                khach.NguoiTaoId = AccountId;
                khach.PhanKhuc = StringHelper.KillChars(model.PhanKhuc);
                khach.SoDienThoai = StringHelper.KillChars(model.SoDienThoai);
                khach.SPChinh = StringHelper.KillChars(model.SPChinh);
                khach.TenKhach = StringHelper.KillChars(model.TenKhach);
                khach.TenNguoiLienHeVaiTro = StringHelper.KillChars(model.TenNguoiLienHeVaiTro);
                khach.TrangThai = 0; //Chờ duyệt
                int result = 0;
                try
                {
                    result = await _repository.GetRepository<Khach>().CreateAsync(khach, AccountId);
                }
                catch { }
                if (result > 0)
                {
                    var khachNewerId = khach.Id;
                    NhuCauThue nhucauthue = new NhuCauThue();
                    nhucauthue.BeNgangLotLong = string.IsNullOrEmpty(model.BeNgangLotLong) ? 0 : float.Parse(model.BeNgangLotLong, CultureInfo.InvariantCulture.NumberFormat);
                    nhucauthue.CapDoTheoDoiId = Convert.ToInt32(model.CapDoTheoDoiId);
                    nhucauthue.DiChungChu = model.DiChungChu == "1" ? true : false;
                    nhucauthue.DienTichDat = string.IsNullOrEmpty(model.DienTichDat) ? 0 : float.Parse(model.DienTichDat, CultureInfo.InvariantCulture.NumberFormat);
                    nhucauthue.DienTichDatSuDungTang1 = string.IsNullOrEmpty(model.DienTichDatSuDungTang1) ? 0 : float.Parse(model.DienTichDatSuDungTang1, CultureInfo.InvariantCulture.NumberFormat);
                    nhucauthue.DuongId = Convert.ToInt64(model.DuongId);
                    var item1 = await _repository.GetRepository<Duong>().ReadAsync(nhucauthue.DuongId);
                    if (item1 != null) { nhucauthue.DuongName = item1.Name; }
                    nhucauthue.GhiChu = StringHelper.KillChars(model.GhiChuNhuCau);
                    nhucauthue.GiaThueBQ = string.IsNullOrEmpty(model.GiaThueBQ) ? 0 : Convert.ToDecimal(model.GiaThueBQ);
                    nhucauthue.Ham = model.Ham == "1" ? true : false;
                    nhucauthue.KhachId = khachNewerId;
                    nhucauthue.MatBangId = Convert.ToInt32(model.MatBangId);
                    nhucauthue.MatTienTreoBien = string.IsNullOrEmpty(model.MatTienTreoBien) ? 0 : float.Parse(model.MatTienTreoBien, CultureInfo.InvariantCulture.NumberFormat);
                    nhucauthue.NgayCNHenLienHeLai = string.IsNullOrEmpty(model.NgayCNHenLienHeLai) ? (DateTime?)null : DateTime.ParseExact(model.NgayCNHenLienHeLai, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    nhucauthue.NguoiTaoId = AccountId;
                    nhucauthue.CapDoTheoDoiId = Convert.ToInt32(model.CapDoTheoDoiId);
                    nhucauthue.NoiThatKhachThueCuId = Convert.ToInt32(model.NoiThatKhachThueCuId);
                    nhucauthue.QuanId = Convert.ToInt64(model.QuanId);
                    var item = await _repository.GetRepository<Quan>().ReadAsync(nhucauthue.QuanId);
                    if (item != null) { nhucauthue.QuanName = item.Name; }
                    nhucauthue.SoNha = StringHelper.KillChars(model.SoNha);
                    nhucauthue.SoTang = Convert.ToInt32(model.SoTang);
                    nhucauthue.TenToaNha = StringHelper.KillChars(model.TenToaNha);
                    nhucauthue.ThangMay = model.ThangMay == "1" ? true : false;
                    nhucauthue.TongDienTichSuDung = string.IsNullOrEmpty(model.TongDienTichSuDung) ? 0 : float.Parse(model.TongDienTichSuDung, CultureInfo.InvariantCulture.NumberFormat);
                    nhucauthue.TongGiaThue = string.IsNullOrEmpty(model.TongGiaThue) ? 0 : Convert.ToDecimal(model.TongGiaThue);
                    nhucauthue.NgayTao = DateTime.Now;
                    nhucauthue.TrangThai = 0; //Chờ duyệt
                    int resultnhucauthue = 0;
                    try
                    {
                        resultnhucauthue = await _repository.GetRepository<NhuCauThue>().CreateAsync(nhucauthue, AccountId);
                    }
                    catch (Exception ex)
                    {
                    }
                    if (resultnhucauthue > 0)
                    {
                        TempData["Success"] = "Nhập dữ liệu khách thuê mới thành công!";
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DangMatBang = await _repository.GetRepository<MatBang>().GetAllAsync();
                ModelState.AddModelError(string.Empty, "Nhập dữ liệu khách thuê mới không thành công! Vui lòng kiểm tra và thử lại!");
                return View(model);
            }


        }

        protected void SetViewBag()
        {
            //Mặt bằng
            var matBang = _repository.GetRepository<MatBang>().GetAll();
            ViewBag.MatBang = matBang.ToList().ToSelectList();

            //Địa chỉ quận - đường
            NhaCreatingViewModel model = new NhaCreatingViewModel();
            var quan = _repository.GetRepository<Quan>().GetAll().OrderBy(o => o.Name).ToList();
            ViewBag.QuanDropdownlist = new SelectList(quan, "Id", "Name", model.QuanId);
            ViewBag.DuongDropdownlist = new SelectList(_repository.GetRepository<Duong>().GetAll(o => o.QuanId == model.QuanId).OrderBy(o => o.Name).ToList(), "Id", "Name", model.DuongId);

            var listYesOrNo = new SelectList(new[] 
            {
                new { ID = "0", Name = "Không" },
                new { ID = "1", Name = "Có" },
            }, "ID", "Name", 1);

            ViewBag.ListYesOrNo = listYesOrNo;

            //Nội thất khách thuê cũ
            var noiThatKhachThueCu = _repository.GetRepository<NoiThatKhachThueCu>().GetAll();
            ViewBag.NoiThatKhachThueCu = noiThatKhachThueCu.ToList().ToSelectList();

            //Đánh giá phù hợp với
            var danhGiaPhuHopVoi = _repository.GetRepository<DanhGiaPhuHopVoi>().GetAll();
            ViewBag.DanhGiaPhuHopVoi = danhGiaPhuHopVoi.ToList().ToSelectList();

            //Cấp độ theo dõi
            var capDoTheoDoi = _repository.GetRepository<CapDoTheoDoi>().GetAll();
            ViewBag.CapDoTheoDoi = capDoTheoDoi.ToList().ToSelectList();
        }

        /* protected void SetViewBag()
         {
             //Mặt bằng
             var matBang = _repository.GetRepository<MatBang>().GetAll();
             ViewBag.MatBang = matBang.ToList().ToSelectList();

             //Địa chỉ quận - đường
             NhaCreatingViewModel model = new NhaCreatingViewModel();
             var quan = _repository.GetRepository<Quan>().GetAll().OrderBy(o => o.Name).ToList();
             ViewBag.QuanDropdownlist = new SelectList(quan, "Id", "Name", model.QuanId);
             ViewBag.DuongDropdownlist = new SelectList(_repository.GetRepository<Duong>().GetAll(o => o.QuanId == model.QuanId).OrderBy(o => o.Name).ToList(), "Id", "Name", model.DuongId);

             var listYesOrNo = new SelectList(new[] 
             {
                 new { ID = "0", Name = "Không" },
                 new { ID = "1", Name = "Có" },
             }, "ID", "Name", 1);

             ViewBag.ListYesOrNo = listYesOrNo;

             //Nội thất khách thuê cũ
             var noiThatKhachThueCu = _repository.GetRepository<NoiThatKhachThueCu>().GetAll();
             ViewBag.NoiThatKhachThueCu = noiThatKhachThueCu.ToList().ToSelectList();

             //Đánh giá phù hợp với
             var danhGiaPhuHopVoi = _repository.GetRepository<DanhGiaPhuHopVoi>().GetAll();
             ViewBag.DanhGiaPhuHopVoi = danhGiaPhuHopVoi.ToList().ToSelectList();

             //Cấp độ theo dõi
             var capDoTheoDoi = _repository.GetRepository<CapDoTheoDoi>().GetAll();
             ViewBag.CapDoTheoDoi = capDoTheoDoi.ToList().ToSelectList();
         }
         */

        [Route("danh-sach-khach-thue-json", Name = "GetKhachThueJson")]
        public ActionResult GetKhachThueJson()
        {
            string drawReturn = "1";

            byte status;

            int skip = 0;
            int take = 10;

            string start = Request.Params["start"];//Đang hiển thị từ bản ghi thứ mấy
            string length = Request.Params["length"];//Số bản ghi mỗi trang
            string draw = Request.Params["draw"];//Số lần request bằng ajax (hình như chống cache)
            string key = Request.Params["search[value]"];//Ô tìm kiếm            
            string orderDir = Request.Params["order[0][dir]"];//Trạng thái sắp xếp xuôi hay ngược: asc/desc
            orderDir = string.IsNullOrEmpty(orderDir) ? "asc" : orderDir;
            string orderColumn = Request.Params["order[0][column]"];//Cột nào đang được sắp xếp (cột thứ mấy trong html table)
            orderColumn = string.IsNullOrEmpty(orderColumn) ? "1" : orderColumn;
            string orderKey = Request.Params["columns[" + orderColumn + "][data]"];//Lấy tên của cột đang được sắp xếp
            orderKey = string.IsNullOrEmpty(orderKey) ? "UpdateDate" : orderKey;

            if (!string.IsNullOrEmpty(start))
                skip = Convert.ToInt16(start);
            if (!string.IsNullOrEmpty(length))
                take = Convert.ToInt16(length);
            if (!string.IsNullOrEmpty(draw))
                drawReturn = draw;

            string objectStatus = Request.Params["objectStatus"];//Lọc trạng thái bài viết
            if (!string.IsNullOrEmpty(objectStatus))
                byte.TryParse(objectStatus.ToString(), out status);
            Paging paging = new Paging()
            {
                TotalRecord = 0,
                Skip = skip,
                Take = take,
                OrderDirection = orderDir
            };
            //var articles = _repository.GetRepository<Khach>().GetAll(ref paging,
            //                                                       orderKey,
            //                                                       o => (key == null ||
            //                                                             key == "" ||
            //                                                             o.TenKhach.Contains(key) ||
            //                                                             o.SoDienThoai.Contains(key)))
            //                                                             .Join(_repository.GetRepository<NhuCauThue>().GetAll(), b => b.Id, e => e.KhachId, (b, e) => new { Khach = b, NhuCauThue = e == null ? null : e })
            //                                                             .Join(_repository.GetRepository<Quan>().GetAll(), g => g.NhuCauThue.QuanId, f => f.Id, (g, f) => new { NhuCauThue = g, Quan = f == null ? null : f })
            //                                                             .Join(_repository.GetRepository<Duong>().GetAll(), k => k.NhuCauThue.NhuCauThue.DuongId, y => y.Id, (k, y) => new { NhuCauThue = k, Duong = y == null ? null : y }).ToList();

            var articles = _repository.GetRepository<Khach>().GetAll(ref paging,
                                                                  orderKey,
                                                                  o => (key == null ||
                                                                        key == "" ||
                                                                        o.TenKhach.Contains(key) ||
                                                                        o.SoDienThoai.Contains(key)))
                                                                        .LeftJoin(                                           /// Source Collection
                                                                            _repository.GetRepository<NhuCauThue>().GetAll(),/// Inner Collection
                                                                            p => p.Id,                                       /// PK
                                                                            a => a.KhachId,                                  /// FK
                                                                            (p, a) => new { Khach = p, NhuCauThue = a }).ToList();

            //var nhucauthueList = _repository.GetRepository<NhuCauThue>().GetAll().ToList();
            //var quanList = _repository.GetRepository<Quan>().GetAll().ToList();
            //var duongList = _repository.GetRepository<Duong>().GetAll().ToList();


            //var articles1 = (from p in articles
            //                 join c in nhucauthueList on p.Id equals c.KhachId into j1
            //                 from j2 in j1.DefaultIfEmpty()
            //                 join d in quanList on j2.QuanId equals d.Id into j3
            //                 from j4 in j3.DefaultIfEmpty()
            //                 join e in duongList on j2.DuongId equals e.Id into j5
            //                 from j6 in j5.DefaultIfEmpty()
            //                 select new { NhuCauThueId = j2.Id, TenKhach = p.TenKhach, Id = p.Id, TongGiaThue = j2.TongGiaThue, Quan = j4.Name, Duong = j6.Name, SoDienThoai = p.SoDienThoai, TrangThai = j2.TrangThai == 0 ? "Chờ duyệt" : "Đã duyệt" }).ToList();
            
            //var articles3 = (from khach1 in articles2
            //                 from quan in quanList
            //                     .Where(s => s.Id == khach1.Nhucauthue.QuanId)
            //                     .DefaultIfEmpty()
            //                 select new { Quan = quan, Khach = khach1 }).ToList();
            
            //var articles4 = (from khach2 in articles3
            //                 from duong in duongList
            //                     .Where(s => s.Id == khach2.Khach.Nhucauthue.DuongId)
            //                     .DefaultIfEmpty()
            //                 select new { Duong = duong, Khach = khach2 }).ToList(); 


            return Json(new
            {
                draw = drawReturn,
                recordsTotal = paging.TotalRecord,
                recordsFiltered = paging.TotalRecord,
                data = articles.Select(o => new
                {
                    o.Khach.Id,
                    o.Khach.TenKhach,
                    o.Khach.SoDienThoai,
                    //NhuCauThueId = string.IsNullOrEmpty(o.NhuCauThue.Id.ToString()) ? 0 : o.NhuCauThue.Id,
                    NhuCauThueId = o.NhuCauThue == null ? 0 : o.NhuCauThue.Id,
                    Quan = o.NhuCauThue == null ? "" : o.NhuCauThue.QuanName,
                    Duong = o.NhuCauThue == null ? "" : o.NhuCauThue.DuongName,
                    //TongGiaThue = string.IsNullOrEmpty(o.NhuCauThue.TongGiaThue.ToString()) ? 0 : o.NhuCauThue.TongGiaThue,
                    TongGiaThue = o.NhuCauThue == null ?  0 : o.NhuCauThue.TongGiaThue,
                    TrangThai = o.NhuCauThue == null ? "" : (o.NhuCauThue.TrangThai == 0 ? "Chờ duyệt" : "Đã duyệt")
                })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("xet-trang-thai-khach-thue/{ids?}/{status?}", Name = "KhachThueSetKhachThueStatus")]
        public async Task<ActionResult> SetKhachThueStatus(string ids, byte status)
        {
            try
            {
                byte succeed = 0;
                string[] articleIds = Regex.Split(ids, ",");
                if (articleIds != null && articleIds.Any())
                    foreach (var item in articleIds)
                    {
                        long articleId = 0;
                        long.TryParse(item, out articleId);
                        bool result = await SetKhachThueStatus(articleId, status);
                        if (result)
                            succeed++;
                    }
                return Json(new { success = true, message = string.Format(@"Đã ghi nhận thành công trạng thái {0} bản ghi.", succeed) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Đã xảy ra lỗi: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Xét trạng thái của bài viết
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private async Task<bool> SetKhachThueStatus(long articleId, byte status)
        {
            var article = await _repository.GetRepository<NhuCauThue>().ReadAsync(articleId);
            if (article == null)
                return false;
            article.TrangThai = status;

            int result = await _repository.GetRepository<NhuCauThue>().UpdateAsync(article, AccountId);

            if (result > 0)
            {
                //TODO: HuyTQ - Lưu lịch sử thay đổi
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("xoa-khach-thue/{ids?}", Name = "KhachThueDeleteKhachThues")]
        [ValidationPermission(Action = ActionEnum.Delete, Module = ModuleEnum.Khach)]
        public async Task<ActionResult> DeleteKhachThues(string ids, bool isKhach)
        {
            try
            {
                byte succeed = 0;
                string[] articleIds = Regex.Split(ids, ",");
                if (articleIds != null && articleIds.Any())
                    foreach (var item in articleIds)
                    {
                        long articleId = 0;
                        long.TryParse(item, out articleId);
                        bool result = await DeleteArticles(articleId, isKhach);
                        if (result)
                            succeed++;
                    }
                return Json(new { success = true, message = string.Format(@"Đã xóa thành công {0} bản ghi.", succeed) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Không xóa được bài viết. Lỗi: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private async Task<bool> DeleteArticles(long articleId, bool isKhach)
        {
            var result = 0;
            var result1 = 0;
            if (isKhach)
            {
                var article = await _repository.GetRepository<Khach>().ReadAsync(articleId);
                //var article1 = await _repository.ExecuteSqlCommandAsync<NhuCauThue>().ReadAsync(articleId);
                var article1 = _repository.GetRepository<NhuCauThue>().GetAll().Where(o => o.KhachId == articleId).Select(o => o.Id).ToList();

                if (article1.Any())
                {
                    foreach (var item in article1)
                    {
                        result1 = await _repository.GetRepository<NhuCauThue>().DeleteAsync(item, AccountId);
                    }
                }

                if (article == null)
                    return false;

                result = await _repository.GetRepository<Khach>().DeleteAsync(article, AccountId);
            }
            else
            {
                var article = await _repository.GetRepository<NhuCauThue>().ReadAsync(articleId);
                if (article == null)
                    return false;
                result = await _repository.GetRepository<NhuCauThue>().DeleteAsync(article, AccountId);
            }
            if (result > 0)
            {
                //TODO: HuyTQ - Lưu lịch sử thay đổi
                return true;
            }
            return false;
        }

        //[Route("cap-nhat-bai-viet/{id?}", Name = "ArticleUpdate")]
        //[ValidationPermission(Action = ActionEnum.Update, Module = ModuleEnum.Article)]
        //public async Task<ActionResult> Update(long id)
        //{
        //    //ViewBag.Categories = await _repository.GetRepository<Category>().GetAllAsync(o => o.CategoryId == null);
        //    ViewBag.CategoryTypes = await _repository.GetRepository<CategoryType>().GetAllAsync();
        //    Article article = await _repository.GetRepository<Article>().ReadAsync(id);
        //    //Nếu bài viết có trạng thái KHÁC đang biên tập thì không cho sửa
        //    if (article.Status != 1)
        //    {
        //        TempData["Error"] = "Bài viết không cho phép sửa!";
        //        return RedirectToAction("Index");
        //    }
        //    ArticleUpdatingViewModel model = new ArticleUpdatingViewModel()
        //    {
        //        Id = article.Id,
        //        Title = article.Title,
        //        Description = article.Description,
        //        Content = article.Content,
        //        ImageDescription = article.ImageDescription,
        //        EventStartDate = article.EventStartDate.HasValue ? article.EventStartDate.Value.ToString("dd/MM/yyyy") : "",
        //        EventFinishDate = article.EventFinishDate.HasValue ? article.EventFinishDate.Value.ToString("dd/MM/yyyy") : ""
        //    };
        //    List<long> articleCategoryIds = new List<long>();
        //    var articleCategory = await _repository.GetRepository<ArticleCategory>().GetAllAsync(o => o.ArticleId == id);
        //    if (articleCategory != null && articleCategory.Any())
        //    {
        //        articleCategoryIds = articleCategory.Select(o => o.CategoryId).ToList();
        //    }
        //    ViewBag.articleCategoryIds = articleCategoryIds;
        //    return View(model);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //[Route("cap-nhat-bai-viet")]
        //[ValidationPermission(Action = ActionEnum.Update, Module = ModuleEnum.Article)]
        //public async Task<ActionResult> Update(long id, ArticleUpdatingViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Article article = await _repository.GetRepository<Article>().ReadAsync(id);
        //        article.Title = StringHelper.KillChars(model.Title);
        //        article.Description = StringHelper.KillChars(model.Description);
        //        article.Content = StringHelper.KillChars(model.Content);
        //        article.ImageDescription = StringHelper.KillChars(model.ImageDescription);
        //        article.UpdateDate = DateTime.Now;
        //        article.UpdateBy = AccountId;
        //        if (!string.IsNullOrEmpty(model.EventStartDate))
        //        {
        //            try
        //            {
        //                DateTime date = DateTime.ParseExact(model.EventStartDate, "dd/MM/yyyy", null);
        //                article.EventStartDate = date;
        //            }
        //            catch
        //            {
        //                article.EventStartDate = null;
        //            }
        //        }
        //        if (!string.IsNullOrEmpty(model.EventFinishDate))
        //        {
        //            try
        //            {
        //                DateTime date = DateTime.ParseExact(model.EventFinishDate, "dd/MM/yyyy", null);
        //                article.EventFinishDate = date;
        //            }
        //            catch
        //            {
        //                article.EventFinishDate = null;
        //            }
        //        }
        //        int result = await _repository.GetRepository<Article>().UpdateAsync(article, AccountId);
        //        if (result > 0)
        //        {
        //            //Cập nhật danh mục cho bài viết
        //            List<long> articleCategoryIds = new List<long>();
        //            //Danh sách danh mục hiện tại của bài viết
        //            var articleCategory1 = await _repository.GetRepository<ArticleCategory>().GetAllAsync(o => o.ArticleId == id);
        //            //articleCategory1 = article.ArticleCategories;//Chưa thử lại cách này
        //            //Id Danh sách danh mục hiện tại của bài viết
        //            if (articleCategory1 != null && articleCategory1.Any())
        //            {
        //                articleCategoryIds = articleCategory1.Select(o => o.CategoryId).ToList();
        //            }

        //            //Nếu người dùng chọn danh mục nào đó (hoặc danh mục đã được chọn từ lúc biên tập)
        //            if (model.CategoryId != null && model.CategoryId.Any())
        //            {
        //                var articleCategory = model.CategoryId.Select(o => new ArticleCategory()
        //                {
        //                    ArticleId = article.Id,
        //                    CategoryId = Convert.ToInt64(o.ToString())
        //                });
        //                //Danh sách danh mục hiện tại không chứa danh mục được chọn thì xóa
        //                var articleCategoryDelete = articleCategory1.Where(o => !articleCategory.Any(x => x.CategoryId == o.CategoryId));
        //                try
        //                {
        //                    int result2 = await _repository.GetRepository<ArticleCategory>().DeleteAsync(articleCategoryDelete, AccountId);
        //                }
        //                catch { }
        //                //Danh sách danh mục được chọn không có trong danh mục hiện tại thì thêm
        //                var articleCategoryAdd = articleCategory.Where(o => !articleCategoryIds.Contains(o.CategoryId));
        //                try
        //                {
        //                    int result2 = await _repository.GetRepository<ArticleCategory>().CreateAsync(articleCategoryAdd, AccountId);
        //                }
        //                catch { }
        //            }
        //            else
        //            {//Nếu người dùng không chọn vào danh mục nào thì xóa tất cái hiện tại
        //                int result3 = await _repository.GetRepository<ArticleCategory>().DeleteAsync(articleCategory1, AccountId);
        //            }
        //            TempData["Success"] = "Cập nhật bài viết thành công!";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            //ViewBag.Categories = await _repository.GetRepository<Category>().GetAllAsync(o => o.CategoryId == null);
        //            ViewBag.CategoryTypes = await _repository.GetRepository<CategoryType>().GetAllAsync();
        //            List<long> articleCategoryIds = new List<long>();
        //            var articleCategory = await _repository.GetRepository<ArticleCategory>().GetAllAsync(o => o.ArticleId == id);
        //            if (articleCategory != null && articleCategory.Any())
        //            {
        //                articleCategoryIds = articleCategory.Select(o => o.CategoryId).ToList();
        //            }
        //            ViewBag.listArticleCategory = articleCategoryIds;
        //            ModelState.AddModelError(string.Empty, "Cập nhật bài viết không thành công! Vui lòng kiểm tra và thử lại!");
        //            return View(model);
        //        }
        //    }
        //    else
        //    {
        //        //ViewBag.Categories = await _repository.GetRepository<Category>().GetAllAsync(o => o.CategoryId == null);
        //        ViewBag.CategoryTypes = await _repository.GetRepository<CategoryType>().GetAllAsync();
        //        List<long> articleCategoryIds = new List<long>();
        //        var articleCategory = await _repository.GetRepository<ArticleCategory>().GetAllAsync(o => o.ArticleId == id);
        //        if (articleCategory != null && articleCategory.Any())
        //        {
        //            articleCategoryIds = articleCategory.Select(o => o.CategoryId).ToList();
        //        }
        //        ViewBag.articleCategoryIds = articleCategoryIds;
        //        ModelState.AddModelError(string.Empty, "Vui lòng nhập chính xác các thông tin!");
        //        return View(model);
        //    }
        //}
        //[Route("xuat-ban-bai-viet", Name = "ArticlePublish")]
        //[ValidationPermission(Action = ActionEnum.Publish, Module = ModuleEnum.ArticlePublish)]
        //public ActionResult Publish()
        //{
        //    return View();
        //}
        //[Route("danh-sach-bai-viet-json", Name = "ArticleGetArticlesJson")]
        //public ActionResult GetArticlesJson(byte status)
        //{
        //    string drawReturn = "1";

        //    int skip = 0;
        //    int take = 10;

        //    string start = Request.Params["start"];//Đang hiển thị từ bản ghi thứ mấy
        //    string length = Request.Params["length"];//Số bản ghi mỗi trang
        //    string draw = Request.Params["draw"];//Số lần request bằng ajax (hình như chống cache)
        //    string key = Request.Params["search[value]"];//Ô tìm kiếm            
        //    string orderDir = Request.Params["order[0][dir]"];//Trạng thái sắp xếp xuôi hay ngược: asc/desc
        //    orderDir = string.IsNullOrEmpty(orderDir) ? "asc" : orderDir;
        //    string orderColumn = Request.Params["order[0][column]"];//Cột nào đang được sắp xếp (cột thứ mấy trong html table)
        //    orderColumn = string.IsNullOrEmpty(orderColumn) ? "1" : orderColumn;
        //    string orderKey = Request.Params["columns[" + orderColumn + "][data]"];//Lấy tên của cột đang được sắp xếp
        //    orderKey = string.IsNullOrEmpty(orderKey) ? "UpdateDate" : orderKey;

        //    if (!string.IsNullOrEmpty(start))
        //        skip = Convert.ToInt16(start);
        //    if (!string.IsNullOrEmpty(length))
        //        take = Convert.ToInt16(length);
        //    if (!string.IsNullOrEmpty(draw))
        //        drawReturn = draw;

        //    string objectStatus = Request.Params["objectStatus"];//Lọc trạng thái bài viết
        //    if (!string.IsNullOrEmpty(objectStatus))
        //        byte.TryParse(objectStatus.ToString(), out status);
        //    Paging paging = new Paging()
        //    {
        //        TotalRecord = 0,
        //        Skip = skip,
        //        Take = take,
        //        OrderDirection = orderDir
        //    };
        //    var articles = _repository.GetRepository<Article>().GetAll(ref paging, orderKey, o => (key == null || key == "" || o.Title.Contains(key) || o.Description.Contains(key) || o.Content.Contains(key)) &&
        //        (o.Status == status))
        //        .Join(_repository.GetRepository<Account>().GetAll(), b => b.CreateBy, c => c.Id, (b, c) => new { Article = b, Account = c }).ToList();

        //    return Json(new
        //    {
        //        draw = drawReturn,
        //        recordsTotal = paging.TotalRecord,
        //        recordsFiltered = paging.TotalRecord,
        //        data = articles.Select(o => new
        //        {
        //            o.Article.Id,
        //            o.Article.Title,
        //            UpdateDate = o.Article.UpdateDate.HasValue ? o.Article.UpdateDate.Value.ToString("dd/MM/yyyy") : o.Article.CreateDate.ToString("dd/MM/yyyy"),
        //            CreateBy = o.Account.Name,
        //            Status = ((Entities.Enums.ArticleStatusEnum)o.Article.Status).GetDescription(),
        //            CategoryName = string.Join(", ", _repository.GetRepository<ArticleCategory>().GetAll(x => x.ArticleId == o.Article.Id).Select(x => x.Category.Name).ToList())
        //        })
        //    }, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //[Route("xet-trang-thai-bai-viet/{ids?}/{status?}", Name = "ArticleSetArticleStatus")]
        //public async Task<ActionResult> SetArticleStatus(string ids, byte status)
        //{
        //    try
        //    {
        //        byte succeed = 0;
        //        string[] articleIds = Regex.Split(ids, ",");
        //        if (articleIds != null && articleIds.Any())
        //            foreach (var item in articleIds)
        //            {
        //                long articleId = 0;
        //                long.TryParse(item, out articleId);
        //                bool result = await SetArticleStatus(articleId, status);
        //                if (result)
        //                    succeed++;
        //            }
        //        return Json(new { success = true, message = string.Format(@"Đã ghi nhận thành công trạng thái {0} bài viết.", succeed) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Đã xảy ra lỗi: " + ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        ///// <summary>
        ///// Xét trạng thái của bài viết
        ///// </summary>
        ///// <param name="articleId"></param>
        ///// <param name="status"></param>
        ///// <returns></returns>
        //private async Task<bool> SetArticleStatus(long articleId, byte status)
        //{
        //    var article = await _repository.GetRepository<Article>().ReadAsync(articleId);
        //    if (article == null)
        //        return false;
        //    article.Status = status;
        //    if (status == 4)
        //    {
        //        article.PublishDate = DateTime.Now;
        //        article.PublishBy = AccountId;
        //    }
        //    int result = await _repository.GetRepository<Article>().UpdateAsync(article, AccountId);
        //    if (result > 0)
        //    {
        //        //TODO: Ghi nhật ký
        //        return true;
        //    }
        //    return false;
        //}
        //[HttpPost]
        //[Route("xoa-bai-viet/{ids?}", Name = "ArticleDeleteArticles")]
        //[ValidationPermission(Action = ActionEnum.Delete, Module = ModuleEnum.Article)]
        //public async Task<ActionResult> DeleteArticles(string ids)
        //{
        //    try
        //    {
        //        byte succeed = 0;
        //        string[] articleIds = Regex.Split(ids, ",");
        //        if (articleIds != null && articleIds.Any())
        //            foreach (var item in articleIds)
        //            {
        //                long articleId = 0;
        //                long.TryParse(item, out articleId);
        //                bool result = await DeleteArticles(articleId);
        //                if (result)
        //                    succeed++;
        //            }
        //        return Json(new { success = true, message = string.Format(@"Đã xóa thành công {0} bài viết.", succeed) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Không xóa được bài viết. Lỗi: " + ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //private async Task<bool> DeleteArticles(long articleId)
        //{
        //    var article = await _repository.GetRepository<Article>().ReadAsync(articleId);
        //    if (article == null)
        //        return false;
        //    //Nếu bài viết đang biên tập hoặc được trả lại biên tập thì mới cho xóa
        //    if (article.Status == 1 || article.Status == 3)
        //    {
        //        //Xóa ArticleCategory
        //        await _repository.GetRepository<ArticleCategory>().DeleteAsync(o => o.ArticleId == articleId, AccountId);
        //        int result = await _repository.GetRepository<Article>().DeleteAsync(article, AccountId);
        //        if (result > 0)
        //        {
        //            //TODO: Ghi nhật ký
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        ///// <summary>
        ///// Xem chi tiết bài viết theo modal dialog
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[Route("xem-chi-tiet-bai-viet-modal/{id?}", Name = "ArticleDetailModal")]
        //public async Task<ActionResult> DetailModal(long id)
        //{
        //    var article = await _repository.GetRepository<Article>().ReadAsync(id);
        //    var account = await _repository.GetRepository<Account>().ReadAsync(article.CreateBy);
        //    ViewBag.CreateBy = account.Name;
        //    //Lấy danh sách chuyên mục
        //    ViewBag.ArticleCategory = await _repository.GetRepository<ArticleCategory>().GetAllAsync(o => o.ArticleId == id);
        //    return PartialView("_DetailModal", article);
        //}
    }
}