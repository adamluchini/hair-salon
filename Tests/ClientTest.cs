// using Xunit;
// using System.Collections.Generic;
// using System;
// using System.Data;
// using System.Data.SqlClient;
//
// namespace HairSalon
// {
//   public class ClientTest : IDisposable
//   {
//     public ClientTest()
//     {
//       DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hairsalon_test;Integrated Security=SSPI;";
//     }
//
//     public void Dispose()
//     {
//       Client.DeleteAll();
//     }
//
//     [Fact]
//     public void Test_ClientsEmptyAtFirst()
//     {
//       int result = Client.GetAll().Count;
//       Assert.Equal(0, result);
//     }
//
//     [Fact]
//     public void Test_Equal_ReturnsTrueForSameName()
//     {
//
//       Client firstClient = new Client("Adam", 1);
//       Client secondClient = new Client("Adam", 1);
//
//       Assert.Equal(firstClient, secondClient);
//     }
//
//     [Fact]
//     public void Test_Save_SavesClientToDatabase()
//     {
//       Client testClient = new Client("Adam", 1);
//       testClient.Save();
//
//       List<Client> result = Client.GetAll();
//       List<Client> testList = new List<Client>{testClient};
//
//       Assert.Equal(testList, result);
//     }
//
//     [Fact]
//     public void Test_Save_AssignsIDToClientName()
//     {
//       Client testClient = new Client("Adam", 1);
//
//       testClient.Save();
//       Client savedClient = Client.GetAll()[0];
//
//       int result = savedClient.GetId();
//       int testId = testClient.GetId();
//
//       Assert.Equal(testId, result);
//     }
//
//     [Fact]
//     public void Test_Find_FindsClientInDatabase()
//     {
//       Client testClient = new Client("Adam", 1);
//       testClient.Save();
//
//       Client foundClient = Client.Find(testClient.GetId());
//
//       Assert.Equal(testClient, foundClient);
//     }
//
//     public void Test_Update_UpdatesClientName()
//     {
//       string name = "Adam";
//       Client testClient = new Client(name, 1);
//       testClient.Save();
//       string newName = "Adam Luchini";
//
//       testClient.Update(newName);
//
//       string result = testClient.GetName();
//
//       Assert.Equal(newName, result);
//     }
//
//     [Fact]
//     public void Test_Delete_DeletesClientFromDatabase()
//     {
//       Client testClient = new Client("Adam", 1);
//       testClient.Save();
//
//       testClient.Delete();
//       List<Client> resultClients = Client.GetAll();
//       List<Client> testClientList = new List<Client> {};
//
//       Assert.Equal(testClientList, resultClients);
//     }
//   }
// }
