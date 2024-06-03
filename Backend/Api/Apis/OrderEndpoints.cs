using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Order;
using Shared.Dtos.OrderItem;
using Shared.Entities;
using Shared.Interfaces.IRepository;

namespace Api.Apis;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/orders");

        group.MapGet("/", async ([FromServices] IOrderRepository orderRepository) =>
        {
            var orders = await orderRepository.GetAllOrdersAsync();
            var orderDtos = orders.Select(o => new ReadOrderDto
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                OrderTotalAmount = o.OrderTotalAmount,
                OrderItems = o.OrderItems.Select(oi => new ReadOrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    ProductName = oi.ProductName,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            }).ToList();
            return Results.Ok(orderDtos);
        });

        group.MapGet("/{id:guid}", async (Guid id, [FromServices] IOrderRepository orderRepository) =>
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return Results.NotFound();
            }
            var orderDto = new ReadOrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                OrderTotalAmount = order.OrderTotalAmount,
                OrderItems = order.OrderItems.Select(oi => new ReadOrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    ProductName = oi.ProductName,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            };
            return Results.Ok(orderDto);
        });



        group.MapGet("/api/orders/by-customer-id/{customerId}", async (Guid customerId, [FromServices] IOrderRepository orderRepository) =>
        {
            var orders = await orderRepository.GetOrdersByCustomerIdAsync(customerId);
            return Results.Ok(orders);
        });




        group.MapPost("/", async ([FromBody] CreateOrderDto createOrderDto, [FromServices] IOrderRepository orderRepository, [FromServices] ICustomerRepository customerRepository) =>
        {
            var order = new OrderEntity
            {
                CustomerId = createOrderDto.CustomerId,
                OrderDate = createOrderDto.OrderDate,
                OrderItems = createOrderDto.OrderItems.Select(oi => new OrderItemEntity
                {
                    OrderItemId = Guid.NewGuid(),
                    ProductId = oi.ProductId,
                    ProductName = oi.ProductName,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };

            // Ensure each OrderItem has the correct OrderId
            order.OrderId = Guid.NewGuid();
            foreach (var item in order.OrderItems)
            {
                item.OrderId = order.OrderId;
            }

            var createdOrder = await orderRepository.CreateOrderAsync(order);

            // Add order reference to customer
            var customer = await customerRepository.GetCustomerByIdAsync(order.CustomerId);
            if (customer != null)
            {
                customer.OrderIds.Add(createdOrder.OrderId);
                await customerRepository.UpdateCustomerAsync(customer);
            }

            var orderDto = new ReadOrderDto
            {
                OrderId = createdOrder.OrderId,
                CustomerId = createdOrder.CustomerId,
                OrderDate = createdOrder.OrderDate,
                OrderTotalAmount = createdOrder.OrderTotalAmount,
                OrderItems = createdOrder.OrderItems.Select(oi => new ReadOrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    ProductName = oi.ProductName,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            };

            return Results.Created($"/api/orders/{orderDto.OrderId}", orderDto);
        });

        group.MapPut("/{id:guid}", async (Guid id, [FromBody] UpdateOrderDto updateOrderDto, [FromServices] IOrderRepository orderRepository) =>
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return Results.NotFound();
            }

            order.OrderDate = updateOrderDto.OrderDate;
            order.OrderItems = updateOrderDto.OrderItems.Select(oi => new OrderItemEntity
            {
                OrderItemId = oi.OrderItemId,
                OrderId = order.OrderId,
                ProductId = oi.ProductId,
                ProductName = oi.ProductName,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice
            }).ToList();

            var updatedOrder = await orderRepository.UpdateOrderAsync(order);

            var orderDto = new ReadOrderDto
            {
                OrderId = updatedOrder.OrderId,
                CustomerId = updatedOrder.CustomerId,
                OrderDate = updatedOrder.OrderDate,
                OrderTotalAmount = updatedOrder.OrderTotalAmount,
                OrderItems = updatedOrder.OrderItems.Select(oi => new ReadOrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    ProductName = oi.ProductName,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            };

            return Results.Ok(orderDto);
        });

        group.MapDelete("/{id:guid}", async (Guid id, [FromServices] IOrderRepository orderRepository) =>
        {
            var result = await orderRepository.DeleteOrderAsync(id);
            if (!result)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        });
    }
}
