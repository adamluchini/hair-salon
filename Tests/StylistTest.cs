using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hairsalon_test;Integrated Security=SSPI;";
    }


    [Fact]
    public void Test_StylistsNameEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameStylistName()
    {

      Stylist firstStylist = new Stylist("Girlene");
      Stylist secondStylist = new Stylist("Girlene");


      Assert.Equal(firstStylist, secondStylist);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [Fact]
    public void Test_Save_SavesStylistNameToDataBase()
    {
      Stylist testStylist = new Stylist("Girlene");
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIDToStylistName()
    {
      Stylist testStylist = new Stylist("Girlene");

      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Girlene");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }
  }
}
