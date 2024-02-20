using HMSBuinessObject.Model.RequestDto;
using HMSService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("ReviewApi")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("CreateReview")]        
        [Authorize]
        public async Task<IActionResult> CreateReviewAsync(CreateReviewReqDto newReview)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _reviewService.CreateReviewAsync(newReview));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteReview")]        
        [Authorize]
        public async Task<IActionResult> DeleteReviewAsync(Guid reviewId)
        {
            try
            {
                return Ok(await _reviewService.DeleteReviewAsync(reviewId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllReview")]        
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> GetAllReviewAsync()
        {
            try
            {
                return Ok(await _reviewService.GetListReviewAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateReview")]
        [Authorize]
        public async Task<IActionResult> UpdateReviewAsync(UpdateReviewReqDto updateReview)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _reviewService.UpdateReviewAsync(updateReview));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
