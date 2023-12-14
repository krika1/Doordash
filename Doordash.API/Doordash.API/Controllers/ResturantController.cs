using Doordash.Data.Models.Resturants;
using Doordash.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _resturantService;

        public ResturantController(IResturantService resturantService)
        {
            _resturantService = resturantService;
        }

        [HttpPost, Route("resturants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResturantModel>> CreateResturantAsync([BindRequired, FromBody] CreateResturantRequest request)
        {
            try
            {
                var resturantModel = await _resturantService.CreateResturantAsync(request);

                return Ok(resturantModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("resturants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ResturantModel>>> GetResturantsAsync()
        {
            try
            {
                var resturantModels = await _resturantService.GetAllResturantsAsync();

                return Ok(resturantModels);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("resturants/{resturantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ResturantModel>>> GetResturantByIdAsync([FromRoute] Guid resturantId)
        {
            try
            {
                var resturantModel = await _resturantService.GetResturantByIdAsync(resturantId);

                if (resturantModel is null) return NotFound();

                return Ok(resturantModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
