using Autoszerelo.Database;
using Autoszerelo.DataClasses;
using Autoszerelo.Services;
using Autoszerelo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;

namespace AutoszereloUnitTests
{
    public class UgyfelServiceTest
    {
        [Fact]
        public async Task Get_ValidCostumer_ReturnsValidResult()
        {
            var ID = Guid.NewGuid();
            var expected = new Ugyfel()
            {
                Ugyfelszam = ID
            };

            var mockedDbSetList = new List<Ugyfel>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Ugyfel>>();

            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Ugyfelek).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Ugyfel>>();

            IUgyfelService ugyfelService = new UgyfelService(mockedDb.Object, mockedLogger.Object);

            var result = await ugyfelService.GetAsync(ID);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Get_InvalidCostumer_ReturnsNULL()
        {
            var ID = Guid.NewGuid();
            var expected = new Ugyfel()
            {
                Ugyfelszam = ID
            };

            var mockedDbSetList = new List<Ugyfel>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Ugyfel>>();

            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Ugyfelek).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Ugyfel>>();

            IUgyfelService ugyfelService = new UgyfelService(mockedDb.Object, mockedLogger.Object);

            var result = await ugyfelService.GetAsync(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAll_ValidCostumers_ReturnsListOfCostumers()
        {
            var ID = Guid.NewGuid();
            var dummy = new Ugyfel();

            var expected = new List<Ugyfel>() { dummy, dummy, dummy, dummy };
            var mockedDbSetList = expected.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Ugyfel>>();

            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Ugyfelek).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Ugyfel>>();

            IUgyfelService ugyfelService = new UgyfelService(mockedDb.Object, mockedLogger.Object);

            var result = await ugyfelService.GetAll();

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Add_ValidCostumer_GetsAddedToTheDB()
        {
            var ID = Guid.NewGuid();
            var expected = new Ugyfel()
            {
                Ugyfelszam = ID
            };

            var mockedDbSetList = new List<Ugyfel>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Ugyfel>>();

            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Ugyfelek).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Ugyfel>>();

            IUgyfelService ugyfelService = new UgyfelService(mockedDb.Object, mockedLogger.Object);

            var newCostumer = new Ugyfel()
            {
                Ugyfelszam = Guid.NewGuid()
            };
            await ugyfelService.AddAsync(newCostumer);

            mockSet.Verify(x => x.AddAsync(newCostumer, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Delete_ValidCostumer_GetsDeleted()
        {
            var ID = Guid.NewGuid();
            var expected = new Ugyfel()
            {
                Ugyfelszam = ID
            };

            var mockedDbSetList = new List<Ugyfel>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Ugyfel>>();

            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Ugyfelek).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Ugyfel>>();

            IUgyfelService ugyfelService = new UgyfelService(mockedDb.Object, mockedLogger.Object);

            await ugyfelService.DeleteAsync(ID);

            mockSet.Verify(x => x.Remove(expected), Times.Once);
        }

        [Fact]
        public async Task Delete_InvalidCostumer_DoesntGetsDeleted()
        {
            var ID = Guid.NewGuid();
            var expected = new Ugyfel()
            {
                Ugyfelszam = ID
            };

            var mockedDbSetList = new List<Ugyfel>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Ugyfel>>();

            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Ugyfelek).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Ugyfel>>();

            IUgyfelService ugyfelService = new UgyfelService(mockedDb.Object, mockedLogger.Object);

            await ugyfelService.DeleteAsync(Guid.NewGuid());

            mockSet.Verify(x => x.Remove(expected), Times.Never);
        }

        [Fact]
        public async Task Update_ValidCostumer_GetsUpdated()
        {
            var ID = Guid.NewGuid();
            var expected = new Ugyfel()
            {
                Ugyfelszam = ID
            };

            var mockedDbSetList = new List<Ugyfel>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Ugyfel>>();

            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Ugyfel>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Ugyfelek).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Ugyfel>>();

            IUgyfelService ugyfelService = new UgyfelService(mockedDb.Object, mockedLogger.Object);

            var updated = expected;
            updated.Nev = "Update";

            await ugyfelService.UpdateAsync(updated);
            var actualUpdated = await ugyfelService.GetAsync(ID);

            Assert.Equal(updated, actualUpdated);
        }
    }
}
