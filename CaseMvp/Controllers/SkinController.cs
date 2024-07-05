using AutoMapper;
using CaseMvp.Dtos;
using CaseMvp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaseMvp.Controllers
{
    public class SkinController : Controller
    {
        private readonly ISkinService _skinService;
        private readonly IMapper _mapper;
        public SkinController(ISkinService skinService, IMapper mapper)
        {
            _skinService = skinService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> IndexSkins()
        {
            var skins = await _skinService.GetAll();
            return View(skins);
        }
        [HttpGet]
        public async Task<IActionResult> IndexSkinsAdmin()
        {
            var skins = await _skinService.GetAll();
            return View(skins);
        }
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var skin = await _skinService.GetById(id);
            if (skin is null)
            {
                return NotFound();
            }
            return View(skin);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSkinDto skinDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _skinService.Create(skinDto);
            return RedirectToAction("IndexSkinsAdmin");
        }
        [HttpGet("Skin/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var skinDto = await _skinService.GetById(id);

            if (skinDto is null)
            {
                return NotFound();
            }
            UpdateSkinDto model = _mapper.Map<UpdateSkinDto>(skinDto);
            return View(model);
        }
        [HttpPost("Skin/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, UpdateSkinDto skinDto)
        {
            var skin = await _skinService.GetById(id);
            if (skin is null)
            {
                return NotFound();
            }
            await _skinService.Update(id, skinDto);
            return RedirectToAction("IndexSkinsAdmin");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost("Skin/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var skin = await _skinService.GetById(id);
            if (skin is null)
            {
                return NotFound();
            }
            await _skinService.Delete(id);
            return RedirectToAction("IndexSkinsAdmin");
        }

    }
}
