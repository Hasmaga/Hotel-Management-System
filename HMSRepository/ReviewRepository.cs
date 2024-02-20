using HMSBuinessObject.HMSDbContext;
using HMSBuinessObject.Model;
using HMSRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HMSRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HMSDBContexts _db;

        public ReviewRepository(HMSDBContexts db)
        {
            _db = db;
        }

        public async Task<bool> CreateReviewAsync(Review review)
        {
            try
            {
                await _db.Reviews.AddAsync(review);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteReviewAsync(Review review)
        {
            try
            {
                _db.Reviews.Remove(review);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            try
            {
                return await _db.Reviews.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Review?> GetReviewByIdAsync(Guid id)
        {
            try
            {
                return await _db.Reviews.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateReviewAsync(Review review)
        {
            try
            {
                _db.Reviews.Update(review);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
