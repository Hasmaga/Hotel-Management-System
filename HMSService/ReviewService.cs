using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using HMSRepository.Interface;
using HMSService.Interface;

namespace HMSService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IHelperService _helperService;
        public ReviewService(IReviewRepository reviewRepository, IAccountRepository accountRepository, IRoleRepository roleRepository, IHelperService helperService)
        {
            _reviewRepository = reviewRepository;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _helperService = helperService;
        }

        public async Task<bool> CreateReviewAsync(CreateReviewReqDto newReview)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");

                var review = new Review
                {
                    Comment = newReview.Comment,
                    CustomerId = accLogged.Id,
                    ReviewStar = newReview.ReviewStar,
                    RoomInformationId = newReview.RoomId
                };
                return await _reviewRepository.CreateReviewAsync(review);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteReviewAsync(Guid reviewId)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");

                var review = await _reviewRepository.GetReviewByIdAsync(reviewId) ?? throw new Exception("Review not found");
                if (review.CustomerId != accLogged.Id)
                {
                    throw new Exception("Unauthority");
                }
                return await _reviewRepository.DeleteReviewAsync(review);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetReviewResDto>> GetListReviewAsync()
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");
                var roleAdmin = await _roleRepository.GetRoleByAuthorityAsync("ADMIN") ?? throw new Exception("Role not found");
                if (accLogged.RoleId != roleAdmin.Id)
                {
                    throw new Exception("Unauthority");
                }

                var reviews = await _reviewRepository.GetAllReviewsAsync();
                return reviews.Select(x => new GetReviewResDto
                {
                    Comment = x.Comment,
                    CustomerId = x.CustomerId,
                    ReviewStar = x.ReviewStar,
                    RoomId = x.RoomInformationId,
                    Id = x.Id
                }).ToList();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateReviewAsync(UpdateReviewReqDto updateReview)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");

                var review = await _reviewRepository.GetReviewByIdAsync(updateReview.Id) ?? throw new Exception("Review not found");
                if (review.CustomerId != accLogged.Id)
                {
                    throw new Exception("Unauthority");
                }
                review.Comment = updateReview.Comment ?? review.Comment;
                review.ReviewStar = updateReview.ReviewStar ?? review.ReviewStar;
                return await _reviewRepository.UpdateReviewAsync(review);

            } catch (Exception)
            {
                throw;
            }
        }
    }
}
