﻿using FluentAssertions;
using System.Collections.Generic;
using TellDontAskKata.Main.Domain;
using Xunit;

namespace TellDontAskKata.Tests.DomainTests
{
    public class OrderTests
    {
        // TODO: tu hija de quien eres? Darsus nombres, hommeeee
        [Fact]
        public void MyTestMethod()
        {
            var sut = new Order();
            OrderItem item = new OrderItem();
            item.TaxedAmount = 10;
            item.Tax = 5;

            sut.Add(item);

            sut.Items.Should().NotBeEmpty();
            sut.Tax.Should().Be(item.Tax);
            sut.Total.Should().Be(item.TaxedAmount);
        }

        [Fact]
        public void ASsdafgsdga()
        {
            Order.With(new List<OrderItem> { new OrderItem(), new OrderItem() })
                .Items
                .Should().NotBeEmpty();
        }
    }
}