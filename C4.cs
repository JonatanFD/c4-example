using component_diagram;
using ctn_diagram;
using ctx_diagram;
using Structurizr;
using Structurizr.Api;



namespace c4_model_template
{

  public class C4
  {

    private readonly long workspaceId = 91929; // colocar id
    private readonly string apiKey = "017dc3ac-e064-48dc-bdd0-2fcb7e21e3d7";
    private readonly string apiSecret = "35c0a5c8-b620-40fc-9f88-3417fc5ec840";

    public StructurizrClient StructurizrClient { get; set; }
    public Workspace Workspace { get; set; }
    public Model Model { get; set; }
    public ViewSet ViewSet { get; set; }


    public C4() {
      string workspaceName = "C4 Model Design - PC 2 - Jonatan Acuña";
      string workspaceDescription = "";

      StructurizrClient = new StructurizrClient(apiKey, apiSecret);
      Workspace = new Workspace(workspaceName, workspaceDescription);
      Model = Workspace.Model;
      ViewSet = Workspace.Views;
    }
    public void Generate()
    {
      ContextDiagram contextDiagram = new ContextDiagram(this);
      ContainerDiagram containerDiagram = new ContainerDiagram(this, contextDiagram);


      APIRestComponentDiagram apiRestComponentDiagram = new APIRestComponentDiagram(this, contextDiagram, containerDiagram);
      // SomeComponent someComponent = new SomeComponent(this, containerDiagram, contextDiagram);


      contextDiagram.Generate();
      containerDiagram.Generate();
      apiRestComponentDiagram.Generate();

      // someComponent.Generate();


      StructurizrClient.PutWorkspace(workspaceId, Workspace);
    }

  }
}
