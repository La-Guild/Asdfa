﻿using System;
using System.Collections.Generic;
using System.Linq;
using TellDontAskKata.Main.UseCase;

namespace TellDontAskKata.Main.Domain
{
    public class Order
    {
        public decimal Tax => Items.Sum(i => i.Tax);
        public decimal Total => Items.Sum(i => i.TaxedAmount);
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; } = new List<OrderItem>();
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        public void Add(OrderItem item)
        {
            Items.Add(item);
        }

        public static Order With(List<OrderItem> orderItems)
        {
            if (!orderItems.Any())
                throw new ArgumentException();

            var order = new Order
            {
                Status = OrderStatus.Created,
                Currency = "EUR"
            };

            orderItems.ForEach(i => order.Add(i));

            return order;
        }

        public Order ApprovalFrom(OrderApprovalRequest request)
        {
            var newOrder = new Order
            {
                Currency = Currency,
                Id = Id,
                Status = request.Approved ? OrderStatus.Approved : OrderStatus.Rejected
            };

            Items.ToList().ForEach(i => newOrder.Add(i));

            return newOrder;
        }
    }
}