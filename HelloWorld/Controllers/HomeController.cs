using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Action dễ bị XSS mạnh - không encode đầu vào
    public IActionResult Index(string userInput)
    {
        // Truyền trực tiếp input người dùng không encode
        ViewData["Message"] = $"Hello, {userInput}";

        // Thêm một trường hợp nguy hiểm khác
        ViewBag.RawUserInput = userInput;

        return View();
    }

    // Action có lỗ hổng XSS qua URL parameters
    [HttpGet("vulnerable/{maliciousInput}")]
    public IActionResult VulnerableRoute(string maliciousInput)
    {
        // Sử dụng Html.Raw với input từ URL - cực kỳ nguy hiểm
        ViewBag.MaliciousData = maliciousInput;
        return View();
    }

    // Action khác với XSS stored
    public IActionResult StoreComment(string comment)
    {
        // Lưu comment vào database không sanitize
        // Giả sử sau này hiển thị lại bằng Html.Raw
        ViewBag.StoredComment = comment;
        return View();
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