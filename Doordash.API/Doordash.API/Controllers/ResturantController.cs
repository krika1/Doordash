using Doordash.Data.Exceptions;
using Doordash.Data.Models;
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
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Create Resturant Failed",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                throw;
            }
        }

        [HttpGet, Route("resturants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ResturantModel>>> GetResturantsAsync([FromQuery] string town)
        {
            try
            {
                var resturantModels = await _resturantService.GetAllResturantsAsync(town);

                return Ok(resturantModels);
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Get All Resturants Failed",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
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

                return Ok(resturantModel);
            }
            catch (NotFoundException ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Resturant not found.",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status404NotFound
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                throw;
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Get Single Resturant Failed",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                throw;
            }
        }

        [HttpDelete, Route("resturants/{resturantId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteResturantByIdAsync([FromRoute] Guid resturantId)
        {
            try
            {
                await _resturantService.DeleteResturantAsync(resturantId);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Resturant not found.",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status404NotFound
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                throw;
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Delete Resturant Failed",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                throw;
            }
        }
    }
}
