using HMSBuinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSRepository.Interface
{
    public interface IReviewRepository
    {
        Task<bool> CreateReviewAsync(Review review);
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review?> GetReviewByIdAsync(Guid id);
        Task<bool> UpdateReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(Review review);
    }
}
