using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]= _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
    }
  }
}
