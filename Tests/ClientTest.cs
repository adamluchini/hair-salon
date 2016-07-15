using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hairsalon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_ClientsEmptyAtFirst()
    {
      int result = Client.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {

      Client firstClient = new Client("Adam", 1);
      Client secondClient = new Client("Adam", 1);


      Assert.Equal(firstClient, secondClient);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
