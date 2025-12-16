using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using MagicVilla_Web.Models.VM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
            _villaService = villaService;
        }
        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> list = new();
            var response = await _villaNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberCreateVM = new();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.isSuccess)
            {
                villaNumberCreateVM.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>
                    (Convert.ToString(response.Result)).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });
            }

            return View(villaNumberCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber);
                if (response != null && response.isSuccess && response.ErrorMessages.Count == 0 )
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _villaService.GetAllAsync<APIResponse>();
            if (resp != null && resp.isSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>
                    (Convert.ToString(resp.Result)).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });
            }

            return View(model);
        }

        public async Task<IActionResult> UpdateNumberVilla(int villaId)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(villaId);
            if (response != null && response.isSuccess)
            {
                VillaDto model = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaDtoUpdate>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateNumberVilla(VillaNumberDTOUpdate model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<APIResponse>(model);
                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteNumberVilla(int villaId)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(villaId);
            if (response != null && response.isSuccess)
            {
                VillaDto model = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNumberVilla(VillaNumberDTO model)
        {

            var response = await _villaNumberService.DeleteAsync<APIResponse>(model.VillaNo);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }

            return View(model);
        }
    }
}
