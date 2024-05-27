using Autoszerelo.Database;
using Autoszerelo.DataClasses;
using Autoszerelo.Services.Interfaces;
using Autoszerelo.Services;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutoszereloUnitTests
{
    public class MunkaServiceTest
    {
        [Fact]
        public async Task Get_ValidJob_ReturnsValidResult()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            var result = await munkaService.GetAsync(ID);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Get_InvalidJob_ReturnsNULL()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            var result = await munkaService.GetAsync(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAll_ValidJobs_ReturnsListOfJobs()
        {
            var ID = Guid.NewGuid();
            var dummy = new Munka();

            var expected = new List<Munka>() { dummy, dummy, dummy, dummy };
            var mockedDbSetList = expected.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            var result = await munkaService.GetAll();

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Add_ValidJob_GetsAddedToTheDB()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            var newCostumer = new Munka()
            {
                MunkaAzonosito = Guid.NewGuid()
            };
            await munkaService.AddAsync(newCostumer);

            mockSet.Verify(x => x.AddAsync(newCostumer, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Delete_ValidJob_GetsDeleted()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            await munkaService.DeleteAsync(ID);

            mockSet.Verify(x => x.Remove(expected), Times.Once);
        }

        [Fact]
        public async Task Delete_InvalidJob_DoesntInvokeDelete()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            await munkaService.DeleteAsync(Guid.NewGuid());

            mockSet.Verify(x => x.Remove(expected), Times.Never);
        }

        [Fact]
        public async Task Update_ValidJob_GetsUpdated()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            var updated = expected;
            updated.Rendszam = "AAA-001";

            await munkaService.UpdateAsync(updated);
            var actualUpdated = await munkaService.GetAsync(ID);

            Assert.Equal(updated, actualUpdated);
        }

        [Fact]
        public async Task NextWorkingState_ValidJob_GetsUpdated()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            var originalMunkaAllapot = expected.MunkaAllapot;

            await munkaService.NextWorkingStateAsync(ID);
            var updatedMunkaAllapot = await munkaService.GetAsync(ID);

            Assert.NotEqual(originalMunkaAllapot, updatedMunkaAllapot.MunkaAllapot);
        }

        [Fact]
        public async Task NextWorkingState_BefejezettJob_DoesntGetsUpdated()
        {
            var ID = Guid.NewGuid();
            var expected = new Munka()
            {
                MunkaAzonosito = ID,
                MunkaAllapot = MunkaAllapot.Befejezett
            };

            var mockedDbSetList = new List<Munka>() { expected }.AsQueryable().BuildMock();
            var mockSet = new Mock<DbSet<Munka>>();

            mockSet.As<IQueryable<Munka>>().Setup(x => x.Provider).Returns(mockedDbSetList.Provider);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.ElementType).Returns(mockedDbSetList.ElementType);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.Expression).Returns(mockedDbSetList.Expression);
            mockSet.As<IQueryable<Munka>>().Setup(x => x.GetEnumerator()).Returns(() => mockedDbSetList.GetEnumerator());

            var mockedDb = new Mock<AutoszereloDbContext>();
            mockedDb.Setup(x => x.Munkak).Returns(mockSet.Object);
            var mockedLogger = new Mock<ILogger<Munka>>();

            IMunkaService munkaService = new MunkaService(mockedDb.Object, mockedLogger.Object);

            await munkaService.NextWorkingStateAsync(ID);

            Assert.Equal(expected.MunkaAllapot, MunkaAllapot.Befejezett);
        }
    }
}
