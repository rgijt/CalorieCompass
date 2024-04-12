using CalorieCompass.Api.Contract.Mappers;
using CalorieCompass.Api.Contract.Models;
using CalorieCompass.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalorieCompass.Api.Controllers;

    [ApiController]
    [Route("/[controller]")]
    [Produces("application/json", "application/problem+json")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        /// <summary>
        /// Get a specific FoodItem.
        /// </summary>
        /// <remarks>
        /// Returns a specific FoodItem by unique identifier.
        /// </remarks>
        /// <response code="200">Returns a FoodItem.</response>
        /// <response code="404">No FoodItem could be found.</response>
        /// <response code="500">Unable to retreive FoodItem.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FoodItem))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Get()
        {
            var result = await _foodService.GetAsync(Guid.NewGuid());
            
            // If there's a error inside our result IsFailed will be true.
            if(result.IsFailed)
            {
                // Map error(s) to ProblemDetails

                // Pick right IActionResult return type

                // Return
            }

            // Map value in result from Domain to Contract model.
            var response = result.Value.Map();
            return Ok(response);
        }
    }