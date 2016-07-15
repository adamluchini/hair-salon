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
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["clients.cshtml", SelectedStylist];
      };

      Post["/clients/delete"] = parameters => {
        Client.DeleteAll();
        return View["clients.cshtml"];
      };
    }
  }
}
