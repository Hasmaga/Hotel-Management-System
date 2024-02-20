using HMSBuinessObject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HMSBuinessObject.HMSDbContext
{
    public class HMSDBContexts : DbContext
    {
        public HMSDBContexts()
        {
        }
        public HMSDBContexts(DbContextOptions<HMSDBContexts> options) : base(options)
        {            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingReservation>()
                .Property(e => e.ActualPrice)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<RoomInformation>()
                .Property(e => e.BookingPrice)
                .HasColumnType("decimal(18, 0)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(GetConnectionString() ?? "Server=(local);Database=HotelManagemrntSytem;User ID=sa;Password=123456;TrustServerCertificate=True;Trusted_Connection=True");

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config.GetConnectionString("DefaultConnection");
        }
         

        public DbSet<Account> Accounts { get; set; } 
        public DbSet<BookingReservation> BookingReservations { get; set; } 
        public DbSet<RoomInformation> RoomInformations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public void InitializeData()
        {
            if (!Roles.Any())
            {
                Roles.Add(new Role
                {
                    Authority = "ADMIN"
                });
                Roles.Add(new Role
                {
                    Authority = "CUSTOMER"
                });
                SaveChanges();
            }

            if (!Accounts.Any())
            {
                var roleAdmin = Roles.FirstOrDefault(x => x.Authority == "ADMIN") ?? throw new Exception("Role not found");
                var roleCustomer = Roles.FirstOrDefault(x => x.Authority == "CUSTOMER") ?? throw new Exception("Role not found");
                Accounts.Add(new Account
                {
                    Name = "Admin",
                    Mobile = "0000000000",
                    Birthday = new DateOnly(1999, 1, 1),
                    IdentityCard = "000000000",
                    LicenceNumber = "000000000",
                    LicenceDate = new DateOnly(2021, 1, 1),
                    Email = "admin@localhost.com",
                    Password = "12345678",
                    RoleId = roleAdmin.Id
                });

                Accounts.Add(new Account
                {
                    Name = "Customer",
                    Mobile = "0000000000",
                    Birthday = new DateOnly(1999, 1, 1),
                    IdentityCard = "000000000",
                    LicenceNumber = "000000000",
                    LicenceDate = new DateOnly(2021, 1, 1),
                    Email = "user1@localhost.com",
                    Password = "12345678",
                    RoleId = roleCustomer.Id
                });
            }
        }
    }
}
