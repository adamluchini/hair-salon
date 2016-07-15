using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["stylists.cshtml", AllStylists];
      };

      Post["/addStylist"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["stylists.cshtml", AllStylists];
      };

      Post["/stylists/delete"] = _ => {
        Stylist.DeleteAll();
        return View["stylists.cshtml"];
      };

      Get["/stylist/{id}"] = parameters =>{
        Stylist ActiveStylist = Stylist.Find(parameters.id);
        return View["clients.cshtml", ActiveStylist];
      };

      Post["/stylist/{id}/addClient"] = parameters => {
        Client newClient = new Client(Request.Form["client-name"], parameters.id);
        newClient.Save();
        Stylist ActiveStylist = Stylist.Find(parameters.id);
        return View["clients.cshtml", ActiveStylist];
      };

      Delete["/client/{id}/delete"] = parameters => {
        Client ActiveClient = Client.Find(parameters.id);
        Stylist ActiveStylist = Stylist.Find(ActiveClient.GetStylistId());
        ActiveClient.Delete();
        return View["clients.cshtml", ActiveStylist];
      };

      Get["/client/{id}/edit"] = parameters => {
        Client ActiveClient = Client.Find(parameters.id);
        return View["edit_client.cshtml", ActiveClient];
      };
      // Delete["/stylist/{id}/delete"] = parameters => {
      //   Stylist ActiveStylist = Stylist.Find(ActiveStylist.GetStylistId());
      //   ActiveStylist.Delete();
      //   return View["stylists.cshtml", AllStylists];
      // };
    }
  }
}
