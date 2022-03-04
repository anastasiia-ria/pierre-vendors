using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;
using System.Collections.Generic;

namespace Bakery.Tests
{
  [TestClass]
  public class OrderTests
  {
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("title", "description", 0, "date");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      //Arrange
      string title = "Test Title";
      string description = "Test Description";
      int price = 0;
      string date = "Test Date";

      //Act
      Order newOrder = new Order(title, description, price, date);
      string result = newOrder.Title;

      //Assert
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      //Arrange
      string title = "Test Title";
      string description = "Test Description";
      int price = 0;
      string date = "Test Date";
      Order newOrder = new Order(title, description, price, date);

      //Act
      string updatedTitle = "Updated Title";
      newOrder.Title = updatedTitle;
      string result = newOrder.Title;

      //Assert
      Assert.AreEqual(updatedTitle, result);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string title = "Test Title";
      string description = "Test Description";
      int price = 0;
      string date = "Test Date";

      //Act
      Order newOrder = new Order(title, description, price, date);
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string title = "Test Title";
      string description = "Test Description";
      int price = 0;
      string date = "Test Date";
      Order newOrder = new Order(title, description, price, date);

      //Act
      string updatedDescription = "Updated Description";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetPrice_ReturnsPrice_String()
    {
      //Arrange
      string title = "Test Title";
      string description = "Test Description";
      int price = 35;
      string date = "Test Date";

      //Act
      Order newOrder = new Order(title, description, price, date);
      int result = newOrder.Price;

      //Assert
      Assert.AreEqual(price, result);
    }

    [TestMethod]
    public void GetDate_ReturnsDate_String()
    {
      //Arrange
      string title = "Test Title";
      string description = "Test Description";
      int price = 0;
      string date = "Test Date";

      //Act
      Order newOrder = new Order(title, description, price, date);
      string result = newOrder.Date;

      //Assert
      Assert.AreEqual(date, result);
    }
  }
}