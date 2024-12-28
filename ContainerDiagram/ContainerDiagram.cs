
using c4_model_template;
using ctx_diagram;
using Structurizr;


namespace ctn_diagram
{
  public class ContainerDiagram
  {

    private readonly C4 c4;
    private readonly ContextDiagram contextDiagram;

    public Container WebApp { get; private set; }
    public Container ApiRest { get; private set; }
    


    public ContainerDiagram(C4 c4, ContextDiagram contextDiagram)
    {
      this.c4 = c4;
      this.contextDiagram = contextDiagram;
    }

    public void Generate()
    {
      // Se generan los elementos del sistema como la persona y los sistemas con los que interactua
      WebApp = contextDiagram.System.AddContainer("Web App", "BackOffice", "Electron");
      ApiRest = contextDiagram.System.AddContainer("Api Rest", "Api Rest", ".Net 8");

      contextDiagram.Admin.Uses(WebApp, "Use");
      contextDiagram.PlantOperator.Uses(WebApp, "Use");

      
      ApiRest.Uses(contextDiagram.Twilio, "Use");
      ApiRest.Uses(contextDiagram.SendGrind, "Use");
      ApiRest.Uses(contextDiagram.GovernmentAPI, "Use");
      WebApp.Uses(ApiRest, "Use");
      

      ContainerView containerView = c4.ViewSet.CreateContainerView(contextDiagram.System, "Container Diagram", "Container Diagram");
      containerView.AddAllContainers();
      containerView.Add(contextDiagram.Admin);
      containerView.Add(contextDiagram.SendGrind);
      containerView.Add(contextDiagram.Twilio);
      containerView.Add(contextDiagram.GovernmentAPI);
      containerView.Add(WebApp);
      containerView.Add(ApiRest);
      containerView.Add(contextDiagram.PlantOperator);
    }



  }

}

