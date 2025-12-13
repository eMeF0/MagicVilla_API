using System.Net;
using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//Add some test line
namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        protected APIResponse _response;
        private readonly IMapper _mapper;

        public VillaAPIController(IVillaRepository dbVilla, IMapper mapper)
        {
            _dbVilla = dbVilla;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDto>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaById(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(x => x.Id == id);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaDto>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };

            }
            return _response;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaDtoCreate createDto)
        {
            try
            {
                if (_dbVilla.GetAsync(x => x.Name.ToLower() == createDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Villa already exists!");
                    return BadRequest(ModelState);
                }
                if (createDto is null)
                {
                    return BadRequest(createDto);
                }

                Villa villa = _mapper.Map<Villa>(createDto);

                await _dbVilla.CreateAsync(villa);
                await _dbVilla.SaveAsync();
                _response.Result = _mapper.Map<VillaDto>(villa);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVillaById", new { id = villa.Id }, villa);
            }
            catch (Exception e)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };

            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var villa = await _dbVilla.GetAsync(x => x.Id == id);
                if (villa is null)
                {
                    return NotFound();
                }
                await _dbVilla.RemoveAsync(villa);
                await _dbVilla.SaveAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.isSuccess = true;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };

            }
            return _response;

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody]VillaDtoUpdate updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.Id)
                {
                    return BadRequest();
                }

                Villa model = _mapper.Map<Villa>(updateDto);

                await _dbVilla.UpdateAsync(model);
                await _dbVilla.SaveAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.isSuccess = true;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };

            }
            return _response;

        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaDtoUpdate> patchDto)
        {
            if (patchDto is null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.GetAsync(x => x.Id == id, tracked:false);
            VillaDtoUpdate modeluPDATE = _mapper.Map<VillaDtoUpdate>(villa);
            if (villa is null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(modeluPDATE, ModelState);
            Villa model = _mapper.Map<Villa>(modeluPDATE);

            await _dbVilla.UpdateAsync(model);
            await _dbVilla.SaveAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
