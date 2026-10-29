using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Resources.Business;
using Resources.Data;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Resources.Test
{
    [TestFixture]
    public class ServiceTest
    {
        private Mock<ResourceDbContext> _context;
        private Mock<DbSet<Resource>> _resourceDbSet;
        private Mock<DbSet<ResourceUsage>> _usageDbSet;

        [SetUp]
        public void SetUp()
        {
            _context = new Mock<ResourceDbContext>();
            _resourceDbSet = new Mock<DbSet<Resource>>();
            _usageDbSet = new Mock<DbSet<ResourceUsage>>();
        }

        [Test]
        public void TestUseResourceWithData()
        {
            var testData = new List<Resource>() { new Resource() { UniqueName = "Resource1", MaximumUsages = 2 } }.AsQueryable();

            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.Provider).Returns(testData.Provider);
            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.Expression).Returns(testData.Expression);
            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.GetEnumerator()).Returns(() => testData.GetEnumerator());

            var testData2 = new List<ResourceUsage>() { }.AsQueryable();

            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.Provider).Returns(testData2.Provider);
            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.Expression).Returns(testData2.Expression);
            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.ElementType).Returns(testData2.ElementType);
            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.GetEnumerator()).Returns(() => testData2.GetEnumerator());

            _context.Setup(c => c.Resources).Returns(_resourceDbSet.Object);
            _context.Setup(c => c.ResourceUsages).Returns(_usageDbSet.Object);

            var service = new Service(_context.Object);

            var result = service.UseResource();

            (string, int) expectedResult = ("Resource1", 1);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void TestUseResourceWithoutData()
        {
            var testData = new List<Resource>() { }.AsQueryable();

            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.Provider).Returns(testData.Provider);
            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.Expression).Returns(testData.Expression);
            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            _resourceDbSet.As<IQueryable<Resource>>().Setup(m => m.GetEnumerator()).Returns(() => testData.GetEnumerator());

            var testData2 = new List<ResourceUsage>() { }.AsQueryable();

            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.Provider).Returns(testData2.Provider);
            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.Expression).Returns(testData2.Expression);
            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.ElementType).Returns(testData2.ElementType);
            _usageDbSet.As<IQueryable<ResourceUsage>>().Setup(m => m.GetEnumerator()).Returns(() => testData2.GetEnumerator());

            _context.Setup(c => c.Resources).Returns(_resourceDbSet.Object);
            _context.Setup(c => c.ResourceUsages).Returns(_usageDbSet.Object);

            var service = new Service(_context.Object);

            var result = service.UseResource();

            (string, int) expectedResult = (result.Item1, 2);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
