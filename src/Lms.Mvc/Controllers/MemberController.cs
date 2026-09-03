using Lms.Mvc.Models;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers;

public class MemberController : Controller
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string searchText = "", int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var response = await _memberService.GetMemberList(searchText, pageNumber, pageSize, cancellationToken);
        return View(response.Data);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(MemberModel memberModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(memberModel);
        }

        var response = await _memberService.CreateMemberAsync(
            memberModel,
            cancellationToken);

        if (response.IsError)
        {
            ModelState.AddModelError(
                string.Empty,
                response.Message);

            return View(memberModel);
        }

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Detail(int memberId, CancellationToken cancellationToken)
    {
        var response = await _memberService.GetMemberByIdAsync(
        memberId,
        cancellationToken);

        return View(response.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Update(
     int memberId,
     CancellationToken cancellationToken)
    {
        var response = await _memberService.GetMemberByIdAsync(
            memberId,
            cancellationToken);

        return View(response.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(
        MemberModel memberModel,
        CancellationToken cancellationToken)
    {
        var response = await _memberService.UpdateMemberAsync(memberModel, cancellationToken);
        if (response.IsError)
        {
            return View("Error", new ErrorViewModel()
            {
                RequestId = response.Message
            });
        }
        else if (response.Data)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(memberModel);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int memberId, CancellationToken cancellationToken)
    {
        var response = await _memberService.DeleteMemberAsync(memberId, cancellationToken);
        if (response.IsError)
        {
            return View("Error", new ErrorViewModel()
            {
                RequestId = response.Message
            });
        }
        else if (response.Data)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return RedirectToAction(nameof(Detail), new { memberId });
        }
    }
}
