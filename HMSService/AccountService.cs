using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using HMSRepository.Interface;
using HMSService.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HMSService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;
        private readonly IHelperService _helperService;

        public AccountService(IAccountRepository accountRepository, IRoleRepository roleRepository, IConfiguration configuration, IHelperService helperService)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
            _helperService = helperService;
        }

        public async Task<bool> CreateAdminAsync(CreateAdminReqDto createAdminReqDto)
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
                Account account = new Account
                {
                    Name = "Admin",
                    Mobile = "0000000000",
                    Birthday = new DateOnly(2000, 1, 1),
                    IdentityCard = "000000000",
                    LicenceNumber = "000000000",
                    LicenceDate = new DateOnly(2000, 1, 1),
                    Email = createAdminReqDto.Email.ToLower(),
                    Password = createAdminReqDto.Password,
                    RoleId = roleAdmin.Id
                };
                return await CreateAccountMainAsync(account);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateCustomerAsync(CreateCustomerReqDto newCustomer)
        {
            try
            {
                var roleCustomer = await _roleRepository.GetRoleByAuthorityAsync("CUSTOMER") ?? throw new Exception("Role not found");
                Account account = new Account
                {
                    Name = newCustomer.Name,
                    Mobile = newCustomer.Mobile,
                    Birthday = newCustomer.Birthday,
                    IdentityCard = newCustomer.IdentityCard,
                    LicenceNumber = newCustomer.LicenceNumber,
                    LicenceDate = newCustomer.LicenceDate,
                    Email = newCustomer.Email.ToLower(),
                    Password = newCustomer.Password,
                    RoleId = roleCustomer.Id
                };
                return await CreateAccountMainAsync(account);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetListCustomerResDto>> GetListCustomerAsync()
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
                var roleCustomer = await _roleRepository.GetRoleByAuthorityAsync("CUSTOMER") ?? throw new Exception("Role not found");
                var listAcc = await _accountRepository.GetListAccountAsync();
                var listCustomer = listAcc.Where(acc => acc.RoleId == roleCustomer.Id).ToList();
                return listCustomer.Select(customer => new GetListCustomerResDto
                {
                    Id = customer.Id,
                    CustomerName = customer.Name,
                    Mobile = customer.Mobile,
                    Birthday = customer.Birthday,
                    IdentityCard = customer.IdentityCard,
                    LicenceNumber = customer.LicenceNumber,
                    LicenceDate = customer.LicenceDate,
                    Email = customer.Email
                }).ToList();                               
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> LoginAsync(LoginReqDto loginReqDto)
        {
            try
            {
                var account = await _accountRepository.GetAccountByEmailAsync(loginReqDto.Email);
                if (account == null)
                {
                    throw new Exception("Account not found");
                }
                if (account.Password != loginReqDto.Password)
                {
                    throw new Exception("Password is incorrect");
                }
                return CreateBearerTokenAccount(account);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCustomerInfoByIdAsync(UpdateCustomerInfoReqDto updateCustomerInfoReqDto)
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
                var account = await _accountRepository.GetAccountByIdAsync(updateCustomerInfoReqDto.Id) ?? throw new Exception("Account not found");
                account.Name = updateCustomerInfoReqDto.CustomerName ?? account.Name;
                account.Mobile = updateCustomerInfoReqDto.Mobile ?? account.Mobile;
                account.Birthday = updateCustomerInfoReqDto.Birthday;
                account.IdentityCard = updateCustomerInfoReqDto.IdentityCard ?? account.IdentityCard;
                account.LicenceNumber = updateCustomerInfoReqDto.LicenceNumber ?? account.LicenceNumber;
                account.LicenceDate = updateCustomerInfoReqDto.LicenceDate;
                account.Email = updateCustomerInfoReqDto.Email ?? account.Email;
                return await _accountRepository.UpdateAccountAsync(account);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateProfileAsync(UpdateProfileReqDto updateProfileReqDto)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");
                accLogged.Name = updateProfileReqDto.Name ?? accLogged.Name;
                accLogged.Mobile = updateProfileReqDto.Mobile ?? accLogged.Mobile;
                accLogged.Birthday = updateProfileReqDto.Birthday ?? accLogged.Birthday;
                accLogged.IdentityCard = updateProfileReqDto.IdentityCard ?? accLogged.IdentityCard;
                accLogged.LicenceNumber = updateProfileReqDto.LicenceNumber ?? accLogged.LicenceNumber;
                accLogged.LicenceDate = updateProfileReqDto.LicenceDate ?? accLogged.LicenceDate;
                accLogged.Email = updateProfileReqDto.Email ?? accLogged.Email;
                accLogged.Password = updateProfileReqDto.Password ?? accLogged.Password;
                return await _accountRepository.UpdateAccountAsync(accLogged);
            } catch (Exception)
            {
                throw;
            }
        }


        #region Private Methods
        private async Task<bool>CreateAccountMainAsync(Account account)
        {
            try
            {
                var isExist = await _accountRepository.GetAccountByEmailAsync(account.Email.ToLower());
                if (isExist != null)
                {
                    throw new Exception("Account already exist");
                }
                return await _accountRepository.CreateAccountAsync(account);               
            } catch (Exception)
            {
                throw;
            }
        }

        private string CreateBearerTokenAccount(Account loginedAcc)
        {
            List<Claim> claims =
            [
                new Claim(ClaimTypes.Sid, loginedAcc.Id.ToString()),
            ];
            var securityKey = _configuration.GetSection("AppSettings:Token").Value ?? throw new Exception("Server Error");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token == null ? throw new Exception("Server Error") : tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
