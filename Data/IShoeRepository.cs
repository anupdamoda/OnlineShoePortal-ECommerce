using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoePortal_ECommerce.Data.Entities;
using System.Collections.Generic;

namespace OnlineShoePortal_ECommerce.Data
{
    public interface IShoeRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}