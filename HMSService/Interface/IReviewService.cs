using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService.Interface
{
    public interface IReviewService
    {
        Task<bool> CreateReviewAsync(CreateReviewReqDto newReview);
        Task<List<GetReviewResDto>> GetListReviewAsync();
        Task<bool> UpdateReviewAsync(UpdateReviewReqDto updateReview);
        Task<bool> DeleteReviewAsync(Guid reviewId);
    }
}
