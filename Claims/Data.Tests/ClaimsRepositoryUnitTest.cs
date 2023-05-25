using Data.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests
{
    public class ClaimsRepositoryUnitTest
    {
        private IClaimsRepository _mockClaimsRepo;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "ClaimsDataBase")
            .Options;
            var context = new DataContext(options);
            context.Database.EnsureDeleted();
            context.Claims.Add(new Claim
            {
                Name = "Claim 1"
            });

            context.Claims.Add(new Claim
            {
                Name = "Claim 2"
            });
            context.SaveChanges();
            context.ChangeTracker.Clear();
            _mockClaimsRepo = new ClaimsRepository(context);
        }

        [Test, Order(0)]
        public void GetClaimsShouldReturnData()
        {
            Assert.That(_mockClaimsRepo.GetClaims().Count(), Is.EqualTo(2));
        }
        [Test, Order(1)]
        public void GetClaimsByIdShouldReturnData()
        {
            Claim claim = new() { Id = 1, Name = "Claim 1" };
            Assert.Multiple(() =>
            {
                Assert.That(_mockClaimsRepo.GetClaimById(1).First().Name, Is.EqualTo(claim.Name));
                Assert.That(_mockClaimsRepo.GetClaimById(1).First().Id, Is.EqualTo(claim.Id));
            });
        }

        [Test, Order(2)]
        public async Task CanInsertClaim()
        {
            Claim claim = new() { Name = "Claim 3" };
            await _mockClaimsRepo.AddClaimAsync(claim);
            Assert.That(await _mockClaimsRepo.GetClaims().CountAsync(), Is.EqualTo(3));
        }
        [Test, Order(3)]
        public async Task CanUpdateClaim()
        {
            Claim claim = new() { Id = 1, Name = "Updated Claim 1" };
            await _mockClaimsRepo.UpdateClaimAsync(claim);

            Assert.That((await _mockClaimsRepo.GetClaimById(1).FirstAsync()).Name, Is.EqualTo(claim.Name));
        }
    }
}