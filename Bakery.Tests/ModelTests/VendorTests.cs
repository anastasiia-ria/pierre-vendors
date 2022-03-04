using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;
using System.Collections.Generic;
using System;

namespace Bakery.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("testName", "testDescription");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Name";
      string description = "Test Description";
      Vendor newVendor = new Vendor(name, description);

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string name = "Test Name";
      string description = "Test Description";
      Vendor newVendor = new Vendor(name, description);

      //Act
      string result = newVendor.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      //Arrange
      string name = "Test Name";
      string description = "Test Description";
      Vendor newVendor = new Vendor(name, description);

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      //Arrange
      string name01 = "Suzie's Cafe";
      string name02 = "Panera Bread";
      string description01 = "Cafe";
      string description02 = "Diner";
      Vendor newVendor1 = new Vendor(name01, description01);
      Vendor newVendor2 = new Vendor(name02, description02);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      string name01 = "Suzie's Cafe";
      string name02 = "Panera Bread";
      string description01 = "Cafe";
      string description02 = "Diner";
      Vendor newVendor1 = new Vendor(name01, description01);
      Vendor newVendor2 = new Vendor(name02, description02);

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      //Arrange
      string titleO = "Order Title";
      string descriptionO = "Order Description";
      int priceO = 0;
      string dateO = "Order Date";
      Order newOrder = new Order(titleO, descriptionO, priceO, dateO);

      List<Order> newList = new List<Order> { newOrder };
      string nameV = "Vendor Name";
      string descriptionV = "Vendor Description";
      Vendor newVendor = new Vendor(nameV, descriptionV);

      //Act
      newVendor.AddOrder(newOrder);
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void RemoveOrder_RemovesOrderFromVendor_OrderList()
    {
      //Arrange
      string titleO = "Order Title";
      string descriptionO = "Order Description";
      int priceO = 0;
      string dateO = "Order Date";
      Order newOrder = new Order(titleO, descriptionO, priceO, dateO);

      List<Order> newList = new List<Order> { };
      string nameV = "Vendor Name";
      string descriptionV = "Vendor Description";
      Vendor newVendor = new Vendor(nameV, descriptionV);

      //Act
      newVendor.AddOrder(newOrder);
      newVendor.RemoveOrder(newOrder);
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void RemoveVendor_RemovesVendorFromVendor_VendorList()
    {
      //Arrange
      string name01 = "Suzie's Cafe";
      string name02 = "Panera Bread";
      string description01 = "Cafe";
      string description02 = "Diner";
      Vendor newVendor1 = new Vendor(name01, description01);
      Vendor newVendor2 = new Vendor(name02, description02);
      List<Vendor> newList = new List<Vendor> { newVendor2 };
      //Act
      newVendor1.RemoveVendor();
      List<Vendor> result = Vendor.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}