using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDescription)
    {
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderTitle, string orderDescription, int orderPrice, string orderDate)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }

    [HttpPost("/vendors/delete")]
    public ActionResult DeleteAll()
    {
      Vendor.ClearAll();
      return View();
    }

    [HttpPost("/vendors/{vendorId}/delete")]
    public ActionResult Delete(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      vendor.RemoveVendor();
      return View();
    }

    [HttpPost("/vendors/{vendorId}/edit")]
    public ActionResult Edit(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpPost("/vendors/{vendorId}")]
    public ActionResult ShowEdit(int vendorId, string vendorName, string vendorDescription)
    {
      Vendor vendor = Vendor.Find(vendorId);
      vendor.Name = vendorName;
      vendor.Description = vendorDescription;
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Order> vendorOrders = vendor.Orders;
      model.Add("vendor", vendor);
      model.Add("orders", vendorOrders);
      return View("Show", model);
    }
  }
}