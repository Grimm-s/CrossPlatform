using LAB5.DTO;
using LAB5.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB5.Controllers
{
    [Authorize]
    public class LabController : Controller
    {
        public IActionResult Lab1()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Lab1([FromForm] RunLabDTO body)
        {
            return View(new LabResultViewModal
            {
                Result = LAB5_LIB.Lab1.Run(body.data)
            });
        }

        public IActionResult Lab2()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Lab2([FromForm] RunLabDTO body)
        {
            return View(new LabResultViewModal
            {
                Result = LAB5_LIB.Lab2.Run(body.data)
            });
        }

        public IActionResult Lab3()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Lab3([FromForm] RunLabDTO body)
        {
            return View(new LabResultViewModal
            {
                Result = LAB5_LIB.Lab3.Run(body.data)
            });
        }
    }
}