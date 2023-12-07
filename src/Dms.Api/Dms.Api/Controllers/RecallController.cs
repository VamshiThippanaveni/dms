using Dms.Core.Interfaces;
using Dms.Models.ReCall;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Dms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecallController : ControllerBase
    {
        private readonly IRecallRepository _recallRepository;
        private readonly ILogger<RecallController> _logger;

        public RecallController(IRecallRepository recallRepository, ILogger<RecallController> logger)
        {
            _recallRepository = recallRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllRecalls")]
        public async Task<IActionResult> GetAllRecalls()
        {
            try
            {
                _logger.LogInformation("Get all Recalls method started");
                var recalls = await _recallRepository.GetAllRecallsAsync();
                return Ok(recalls);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occured while fetching all recalls method");
                return StatusCode(500, "Internal server error");
            }
        }
        //[HttpGet]
        [HttpGet("{id}")]
        //[Route("GetRecallById")]
        public async Task<IActionResult> GetRecallById(Guid id)
        {
            try
            {
                _logger.LogInformation($"Get Recall by Id:{id}");
                var recall = await _recallRepository.GetRecallByIdAsync(id);
                if (recall == null)
                {
                    _logger.LogInformation($"Recall with Id:{id} is not found");
                    return NotFound();
                }
                _logger.LogInformation($"Successfully retrieved recall by Id:{id}");
                return Ok(recall);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving recall by Id");
                return StatusCode(500, "Internal server error");
            }          
        }

        [HttpPost]
        //[Route("AddRecall")]
        public async Task<IActionResult> AddRecall([FromBody] Recall recall)
        {
            try
            {
                _logger.LogInformation($"Adding a new recall");
                await _recallRepository.AddRecallAsync(recall);
                _logger.LogInformation($"Successfully added new recall by Id:{recall.RecallId}");
                return CreatedAtAction(nameof(GetRecallById), new { id = recall.RecallId }, recall);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding new recall");
                return StatusCode(500, "Internal server error");
            }          
        }
        //[HttpPut]
        [HttpPut("{id}")]
        //[Route("UpdateRecall")]
        public async Task<IActionResult> UpdateRecall(Guid id, [FromBody] Recall recall)
        {
            try
            {
                _logger.LogInformation($"Updating recall by Id:{id}");
                var existingRecall = await _recallRepository.GetRecallByIdAsync(id);
                if (existingRecall == null)
                {
                    _logger.LogInformation($"Recall with Id:{id} is not found");
                    return NotFound();
                }
                await _recallRepository.UpdateRecallAsync(existingRecall);
                _logger.LogInformation($"Successfully updated the recall by Id:{id}");
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while updating the recall");
                return StatusCode(500, "Internal server error");
            }           
        }
        //[HttpDelete]
        [HttpDelete("{id}")]
        //[Route("DeleteRecall")]
        public async Task<IActionResult> DeleteRecall(Guid id)
        {
            try
            {
                _logger.LogInformation($"Deleting the recall by Id:{id}");
                var recall = await _recallRepository.GetRecallByIdAsync(id);
                if (recall == null)
                {
                    _logger.LogInformation($"Recall with Id:{id} is not found");
                    return NotFound();
                }
                await _recallRepository.DeleteRecallByIdAsync(id);
                _logger.LogInformation($"Successfully deleted the recall with Id:{id}");
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while deleting the recall");
                return StatusCode(500, "Internal server error");
            }           
        }
    }
}

