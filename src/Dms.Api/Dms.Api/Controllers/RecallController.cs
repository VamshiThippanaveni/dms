using Dms.Core.Interfaces;
using Dms.Models.ReCall;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecallController : ControllerBase
    {
        private readonly IRecallRepository _recallRepository;

        public RecallController(IRecallRepository recallRepository)
        {
            _recallRepository = recallRepository;
        }

        [HttpGet]
        [Route("GetAllRecalls")]
        public async Task<IActionResult> GetAllRecalls()
        {
            var recalls = await _recallRepository.GetAllRecallsAsync();
            return Ok(recalls);
        }
        //[HttpGet]
        [HttpGet("{id}")]
        //[Route("GetRecallById")]
        public async Task<IActionResult> GetRecallById(Guid id)
        {
            var recall = await _recallRepository.GetRecallByIdAsync(id);
            if (recall == null)
            {
                return NotFound();
            }
            return Ok(recall);
        }

        [HttpPost]
        //[Route("AddRecall")]
        public async Task<IActionResult> AddRecall([FromBody] Recall recall)
        {
            await _recallRepository.AddRecallAsync(recall);
            return CreatedAtAction(nameof(GetRecallById), new { id = recall.RecallId }, recall);
        }
        //[HttpPut]
        [HttpPut("{id}")]
        //[Route("UpdateRecall")]
        public async Task<IActionResult> UpdateRecall(Guid id, [FromBody] Recall recall)
        {
            var existingRecall = await _recallRepository.GetRecallByIdAsync(id);
            if (existingRecall == null)
            {
                return NotFound();
            }
            await _recallRepository.UpdateRecallAsync(existingRecall);
            return NoContent();
        }
        //[HttpDelete]
        [HttpDelete("{id}")]
        //[Route("DeleteRecall")]
        public async Task<IActionResult> DeleteRecall(Guid id)
        {
            var recall = await _recallRepository.GetRecallByIdAsync(id);
            if (recall == null)
            {
                return NotFound();
            }
            await _recallRepository.DeleteRecallByIdAsync(id);
            return NoContent();
        }
    }
}

