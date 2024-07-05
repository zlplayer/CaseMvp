using AutoMapper;
using CaseMvp.Dtos;
using CaseMvp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseMvp.Controllers
{
    public class CaseController : Controller
    {
        private readonly ILogger<CaseController> _logger;
        private readonly ICaseService _caseService;
        private readonly IMapper _mapper;
        private readonly ISkinService _skinService;
        public CaseController(ILogger<CaseController> logger,ICaseService caseService, IMapper mapper,ISkinService skinService)
        {
            _logger = logger;
            _caseService =caseService;
            _mapper=mapper;
            _skinService=skinService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cases = await _caseService.GetAll();
            return View(cases);
        }
        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var cases = await _caseService.GetAll();
            return View(cases);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var box = await _caseService.GetSkinsByCaseIdAsync(id);
            if (box is null)
            {
                return NotFound();
            }
            ViewBag.CaseId = id;
            return View(box);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCaseDto caseDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _caseService.Create(caseDto);
            return RedirectToAction("IndexAdmin");
        }
        [HttpGet("Case/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var caseDto = await _caseService.GetById(id);

            if (caseDto is null)
            {
                return NotFound();
            }
            UpdateCaseDto model = _mapper.Map<UpdateCaseDto>(caseDto);
            return View(model);
        }
        [HttpPost("Case/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, UpdateCaseDto caseDto)
        {
            var car = await _caseService.GetById(id);
            if (car is null)
            {
                return NotFound();
            }
            await _caseService.Update(id, caseDto);
            return RedirectToAction("IndexAdmin");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var caseDto = await _caseService.GetById(id);
            if (caseDto is null)
            {
                return NotFound();
            }
            await _caseService.Delete(id);
            return RedirectToAction("IndexAdmin");
        }

        [HttpGet("Case/ShowAllSkins/{caseId}")]
        public async Task<IActionResult> ShowAllSkins([FromRoute]int caseId)
        {
            var skins = await _skinService.GetAll();
            ViewBag.CaseId = caseId;
            return View(skins);
        }

        [HttpPost("Case/ShowAllSkins/{caseId}")]
        public async Task<IActionResult> ShowAllSkins([FromRoute] int caseId, [FromForm] int skinId)
        {
            await _caseService.AddSkinsToCaseAsync(caseId, skinId);
            return RedirectToAction("ShowAllSkins");
        }

        [HttpPost]
        public async Task<IActionResult> DrawSkin(int caseId)
        {
            try
            {
                var skinDto = await _caseService.DrawSkinAsync(caseId);
                return RedirectToAction("DrawnSkin", new { skinId = skinDto.Id, caseId });
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Details", new { id = caseId });
            }
        }

        public async Task<IActionResult> DrawnSkin(int skinId, int caseId)
        {
            var skinDto = await _caseService.GetSkinByIdAsync(skinId);

            if (skinDto == null)
            {
                return NotFound();
            }

            ViewBag.CaseId = caseId; // Przekazywanie caseId do ViewBag
            return View(skinDto);
        }
    }
}
