using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nvd_Lesson10.Data;
using Nvd_Lesson10.Models;

namespace Nvd_Lesson10.Controllers;

public class LearnerController : Controller
{
    private const int PageSize = 3;
    private readonly SchoolContext _context;

    public LearnerController(SchoolContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? mid, string? keyword, int pageIndex = 1)
    {
        var learners = GetFilteredLearners(mid, keyword);
        var totalCount = await learners.CountAsync();
        var pageCount = (int)Math.Ceiling(totalCount / (double)PageSize);
        pageIndex = Math.Clamp(pageIndex, 1, Math.Max(pageCount, 1));

        ViewBag.Majors = await _context.Majors.AsNoTracking().OrderBy(major => major.MajorName).ToListAsync();
        ViewBag.MajorId = mid;
        ViewBag.Keyword = keyword;
        ViewBag.PageIndex = pageIndex;
        ViewBag.PageCount = pageCount;
        ViewBag.TotalCount = totalCount;

        var page = await learners.OrderBy(learner => learner.LearnerID)
            .Skip((pageIndex - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        return View(page);
    }

    [HttpGet]
    public async Task<IActionResult> LearnerFilter(int? mid, string? keyword, int? pageIndex)
    {
        var learners = GetFilteredLearners(mid, keyword);
        var totalCount = await learners.CountAsync();
        var pageCount = (int)Math.Ceiling(totalCount / (double)PageSize);
        var page = Math.Clamp(pageIndex ?? 1, 1, Math.Max(pageCount, 1));

        ViewBag.MajorId = mid;
        ViewBag.Keyword = keyword;
        ViewBag.PageIndex = page;
        ViewBag.PageCount = pageCount;
        ViewBag.TotalCount = totalCount;

        var learnersOnPage = await learners.OrderBy(learner => learner.LearnerID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        return PartialView("_LearnerTable", learnersOnPage);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateMajorsAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
    {
        if (ModelState.IsValid)
        {
            _context.Learners.Add(learner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateMajorsAsync(learner.MajorID);
        return View(learner);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var learner = await _context.Learners.FindAsync(id);
        if (learner == null)
            return NotFound();

        await PopulateMajorsAsync(learner.MajorID);
        return View(learner);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
    {
        if (id != learner.LearnerID)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(learner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateMajorsAsync(learner.MajorID);
        return View(learner);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var learner = await _context.Learners
            .Include(item => item.Major)
            .Include(item => item.Enrollments)
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.LearnerID == id);

        if (learner == null)
            return NotFound();

        return View(learner);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var learner = await _context.Learners
            .Include(item => item.Enrollments)
            .FirstOrDefaultAsync(item => item.LearnerID == id);

        if (learner == null)
            return NotFound();

        if (learner.Enrollments.Count > 0)
        {
            TempData["DeleteError"] = "Không thể xóa Learner đã đăng ký khóa học.";
            return RedirectToAction(nameof(Delete), new { id });
        }

        _context.Learners.Remove(learner);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateMajorsAsync(int? selectedMajor = null)
    {
        ViewData["MajorID"] = new SelectList(
            await _context.Majors.AsNoTracking().OrderBy(major => major.MajorName).ToListAsync(),
            "MajorID", "MajorName", selectedMajor);
    }

    private IQueryable<Learner> GetFilteredLearners(int? majorId, string? keyword)
    {
        IQueryable<Learner> learners = _context.Learners
            .Include(learner => learner.Major)
            .AsNoTracking();

        if (majorId.HasValue)
            learners = learners.Where(learner => learner.MajorID == majorId.Value);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var search = keyword.Trim();
            learners = learners.Where(learner =>
                learner.FirstMidName.Contains(search) || learner.LastName.Contains(search));
        }

        return learners;
    }
}
