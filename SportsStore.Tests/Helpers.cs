using AutoFixture;
using Moq;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Tests
{
    public class Helpers
    {
        public IProductRepository GenerateProductRepository(int total = 7)
        {
            var mock = new Mock<IProductRepository>();
            var fixture = new Fixture();
            var data = new Product[total];

            for (int i = 0; i < total; i++)
            {
                data[i] = fixture.Create<Product>();
            }

            mock.Setup(m => m.Products).Returns(data.AsQueryable());

            return mock.Object;
        }
    }
}
