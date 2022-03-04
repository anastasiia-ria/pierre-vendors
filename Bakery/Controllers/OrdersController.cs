using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System;

namespace Bakery.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/delete")]
    public ActionResult DeleteAll(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      vendor.Orders = new List<Order> { };
      return View(vendor);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}/delete")]
    public ActionResult Delete(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      vendor.RemoveOrder(order);
      return View(vendor);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}/edit")]
    public ActionResult Edit(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult ShowEdit(int vendorId, int orderId, string orderTitle, string orderDescription, int orderPrice, string orderDate)
    {
      Order order = Order.Find(orderId);
      order.Title = orderTitle;
      order.Description = orderDescription;
      order.Date = orderDate;
      order.Price = orderPrice;
      Vendor foundVendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }
  }
}