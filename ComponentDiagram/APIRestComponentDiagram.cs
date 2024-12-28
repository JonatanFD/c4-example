using c4_model_template;
using ctn_diagram;
using ctx_diagram;

using Structurizr;


namespace component_diagram
{

    public class APIRestComponentDiagram
    {
        // default properties
        private readonly C4 c4;
        private readonly ContextDiagram contextDiagram;
        private readonly ContainerDiagram containerDiagram;
        // 
        // componentes de la api rest (los contextos)
        public Component PlantOperations { get; private set; }
        public Component RegulatoryCompliance { get; private set; }
        public Component ResourceOptimization { get; private set; }
        public Component IncidentManagement { get; private set; }
        public Component Notifications { get; private set; }
        public Component IdentityAccessManagement { get; private set; }


        // contextos
        public APIRestComponentDiagram(C4 c4, ContextDiagram contextDiagram, ContainerDiagram containerDiagram)
        {
            this.c4 = c4;
            this.contextDiagram = contextDiagram;
            this.containerDiagram = containerDiagram;
        }   


        public void ApplyStyles() {
            PlantOperations.AddTags(PlantOperations.Name);
            RegulatoryCompliance.AddTags(RegulatoryCompliance.Name);
            ResourceOptimization.AddTags(ResourceOptimization.Name);
            IncidentManagement.AddTags(IncidentManagement.Name);
            Notifications.AddTags(Notifications.Name);
            IdentityAccessManagement.AddTags(IdentityAccessManagement.Name);




        }

        public void Generate()
        {
            // se crean los componentes
            PlantOperations = containerDiagram.ApiRest.AddComponent("Plant Operations", "Plant Operations", "Plant Operations");
            RegulatoryCompliance = containerDiagram.ApiRest.AddComponent("Regulatory Compliance", "Regulatory Compliance", "Regulatory Compliance");
            ResourceOptimization = containerDiagram.ApiRest.AddComponent("Resource Optimization", "Resource Optimization", "Resource Optimization");
            IncidentManagement = containerDiagram.ApiRest.AddComponent("Incident Management", "Incident Management", "Incident Management");
            Notifications = containerDiagram.ApiRest.AddComponent("Notifications", "Notifications", "Notifications");
            IdentityAccessManagement = containerDiagram.ApiRest.AddComponent("Identity Access Management", "Identity Access Management", "Identity Access Management");

            // se crean las relaciones

            RegulatoryCompliance.Uses(contextDiagram.GovernmentAPI, "Use", "HTTPS JSON");

            Notifications.Uses(contextDiagram.Twilio, "Use", "HTTPS JSON");
            Notifications.Uses(contextDiagram.SendGrind, "Use", "HTTPS JSON");

            // publish, se agregan los contextos 
            string title = "API Rest Component Diagram";
            ComponentView componentView = c4.ViewSet.CreateComponentView(containerDiagram.ApiRest, title, title);
            componentView.Title = title;

            componentView.AddAllComponents();
            componentView.Add(contextDiagram.Twilio);
            componentView.Add(contextDiagram.SendGrind);
            componentView.Add(contextDiagram.GovernmentAPI);

        }

    }
}
