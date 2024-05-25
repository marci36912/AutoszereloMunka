using Autoszerelo.Database;
using Autoszerelo.DataClasses;
using Autoszerelo.Services;
using Autoszerelo.Services.Interfaces;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            IUgyfelService s = Substitute.For<IUgyfelService>();
            s.Get(Arg.Is(ID)).Returns(expected);

            var result = await s.Get(ID);

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

            IUgyfelService s = Substitute.For<IUgyfelService>();
            s.Get(Arg.Is(ID)).Returns(expected);

            var result = await s.Get(Guid.Empty);

            Assert.Equal(null, result);
        }

        [Fact]
        public async Task GetAll_ValidCostumers_ReturnsListOfCostumers()
        {
            var dummy = new Ugyfel();
            var expected = new List<Ugyfel>()
            { dummy, dummy, dummy, dummy};

            IUgyfelService s = Substitute.For<IUgyfelService>();
            s.GetAll().Returns(expected);

            var result = await s.GetAll();

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Add_ValidCostumer_GetsAddedToTheDB()
        {

        }

        [Fact]
        public async Task Delete_ValidCostumer_GetsDeleted()
        {

        }

        [Fact]
        public async Task Delete_InvalidCostumer_DoesntGetsDeleted()
        {

        }

        [Fact]
        public async Task Update_ValidCostumer_GetsUpdated()
        {

        }
    }
}
