
using c4_model_template;
using ctx_diagram;
using Structurizr;


namespace ctn_diagram
{
  public class ContainerDiagram
  {

    private readonly C4 c4;
    private readonly ContextDiagram contextDiagram;

    public Container MySQL { get; private set; }
    public Container LandingPage { get; private set; }
    public Container WebApplication { get; private set; }
    public Container MobileApplication { get; private set; }
    public Container ApiRest { get; private set; }
    


    public ContainerDiagram(C4 c4, ContextDiagram contextDiagram)
    {
      this.c4 = c4;
      this.contextDiagram = contextDiagram;
    }

    public void Generate()
    {
      // Se generan los elementos del sistema como la persona y los sistemas con los que interactua
      MySQL = contextDiagram.System.AddContainer("MySQL", "Database", "MySQL");
      LandingPage = contextDiagram.System.AddContainer("Landing Page", "Web Page", "Angular 17");
      WebApplication = contextDiagram.System.AddContainer("Web Application", "Web Application", "Angular 17");
      MobileApplication = contextDiagram.System.AddContainer("Mobile Application", "Mobile Application", "Flutter");
      ApiRest = contextDiagram.System.AddContainer("Api Rest", "Api Rest", ".Net 8");


      contextDiagram.Admin.Uses(LandingPage, "Use");
      contextDiagram.Admin.Uses(WebApplication, "Use");
      contextDiagram.Admin.Uses(MobileApplication, "Use");

      contextDiagram.Subscriber.Uses(LandingPage, "Use");
      contextDiagram.Subscriber.Uses(WebApplication, "Use");
      contextDiagram.Subscriber.Uses(MobileApplication, "Use");
      
      WebApplication.Uses(ApiRest, "Use");
      MobileApplication.Uses(ApiRest, "Use");
      ApiRest.Uses(MySQL, "Use");

      ApiRest.Uses(contextDiagram.Paypal, "Use", "HTTPS JSON");
      ApiRest.Uses(contextDiagram.Twilio, "Use", "HTTPS JSON");
      ApiRest.Uses(contextDiagram.Fifa, "Use", "HTTPS JSON");
      ApiRest.Uses(contextDiagram.SendGrind, "Use", "HTTPS JSON");

      ContainerView containerView = c4.ViewSet.CreateContainerView(contextDiagram.System, "Container Diagram", "Container Diagram");
      containerView.AddAllContainers();
      containerView.Add(contextDiagram.Admin);
      containerView.Add(contextDiagram.Subscriber);
      containerView.Add(contextDiagram.Paypal);
      containerView.Add(contextDiagram.Twilio);
      containerView.Add(contextDiagram.Fifa);
      containerView.Add(contextDiagram.SendGrind);
    }



  }

}

