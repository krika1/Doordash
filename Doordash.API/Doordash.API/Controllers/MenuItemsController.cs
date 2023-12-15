using Doordash.Data.Exceptions;
using Doordash.Data.Models;
using Doordash.Data.Models.MenuItems;
using Doordash.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doordash.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IResturantService _resturantService;
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IResturantService resturantService, IMenuItemService menuItemService)
        {
            _resturantService = resturantService;
            _menuItemService = menuItemService;
        }

        [HttpPost, Route("resturants/{resturantId}/menu-items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MenuItemModel>> CreateMenuItemAsync([FromRoute] Guid resturantId, CreateMenuItemRequest request)
        {
            try
            {
                await _resturantService.GetResturantByIdAsync(resturantId);

                var menuItem = await _menuItemService.CreateMenuItemAsync(resturantId, request);

                return Ok(menuItem);
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
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Create Menu item Failed",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpGet, Route("resturants/{resturantId}/menu-items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MenuItemModel>>> GetAllResturantMenuItemsAsync([FromRoute] Guid resturantId)
        {
            try
            {
                await _resturantService.GetResturantByIdAsync(resturantId);

                var menuItems = await _menuItemService.GetAllResturantMenuItemsAsync(resturantId);

                return Ok(menuItems);
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
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Get all Menu item Failed",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpGet, Route("resturants/{resturantId}/menu-items/{menuItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MenuItemModel>>> GetSingleMenuItemAsync([FromRoute] Guid resturantId, [FromRoute] Guid menuItemId)
        {
            try
            {
                await _resturantService.GetResturantByIdAsync(resturantId);

                var menuItem = await _menuItemService.GetSingleMenuItem(menuItemId);

                return Ok(menuItem);
            }
            catch (NotFoundException ex)
            {
                var errorModel = new ErrorModel
                {
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status404NotFound
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorModel
                {
                    Title = "Get Single Menu item Failed",
                    Details = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return new ObjectResult(errorModel)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
