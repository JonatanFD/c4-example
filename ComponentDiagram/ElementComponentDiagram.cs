using c4_model_template;
using ctn_diagram;
using ctx_diagram;

using Structurizr;


namespace component_diagram
{
  public class PaymentGatewayBCComponentDiagram {

    // default properties
    private readonly C4 c4;
    private readonly ContextDiagram contextDiagram;
    private readonly ContainerDiagram containerDiagram;
    private readonly string componentTag = "Component";
    // 

    public Component DomainLayer { get; private set; }
    public Component InterfaceLayer { get; private set; }
    public Component ApplicationLayer { get; private set; }
    public Component InfrastructureLayer { get; private set; }



    public PaymentGatewayBCComponentDiagram(C4 c4, ContainerDiagram containerDiagram, ContextDiagram contextDiagram)
    {
      this.c4 = c4;
      this.contextDiagram = contextDiagram;
      this.containerDiagram = containerDiagram;
    }


    public void Generate()
    {
      DomainLayer = containerDiagram.ApiRest.AddComponent("Domain Layer Payment Gateway", "", "NodeJS (NestJS)");
      InterfaceLayer = containerDiagram.ApiRest.AddComponent("Interface Layer Payment Gateway", "", "NodeJS (NestJS)");
      InfrastructureLayer = containerDiagram.ApiRest.AddComponent("Infrastructure Layer Payment Gateway", "", "NodeJS (NestJS)");
      ApplicationLayer = containerDiagram.ApiRest.AddComponent("Application Layer Payment Gateway", "", "NodeJS (NestJS)");

      InterfaceLayer.Uses(ApplicationLayer, "", "");
      ApplicationLayer.Uses(DomainLayer, "", "");
      ApplicationLayer.Uses(InfrastructureLayer, "", "");
      InfrastructureLayer.Uses(DomainLayer, "", "");
      InfrastructureLayer.Uses(contextDiagram.Paypal, "Use", "JSON HTTPS");

      //
      string title = "Payment Gateway BC Component Diagram";
      ComponentView componentView = c4.ViewSet.CreateComponentView(containerDiagram.ApiRest, title, title);
      componentView.Title = title;
      // contenedores asociados
      componentView.Add(contextDiagram.Paypal);

      // elementos propios
      componentView.Add(DomainLayer);
      componentView.Add(InterfaceLayer);
      componentView.Add(ApplicationLayer);
      componentView.Add(InfrastructureLayer);
    }
  }


}