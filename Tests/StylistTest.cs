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
    public void Test_StylistsEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {

      Stylist firstStylist = new Stylist("Girlene");
      Stylist secondStylist = new Stylist("Girlene");


      Assert.Equal(firstStylist, secondStylist);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
