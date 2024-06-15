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
        private readonly string componentTag = "Component";
        // 
        // componentes de la api rest (los contextos)
        public Component League { get; private set; }
        public Component Club_Players { get; private set; }
        public Component Signings_and_Hiring { get; private set; }
        public Component Stadium { get; private set; }
        public Component FanClub { get; private set; }
        public Component GamesSchedule { get; private set; }
        public Component Statistics { get; private set; }
        public Component Security { get; private set; }
        public Component Subscriptions { get; private set; }
        public Component Notifications { get; private set; }


        // contextos
        public APIRestComponentDiagram(C4 c4, ContextDiagram contextDiagram, ContainerDiagram containerDiagram)
        {
            this.c4 = c4;
            this.contextDiagram = contextDiagram;
            this.containerDiagram = containerDiagram;
        }

        public void Generate()
        {
            // se crean los componentes
            League = containerDiagram.ApiRest.AddComponent("League", "League", "League");
            Club_Players = containerDiagram.ApiRest.AddComponent("Club Players", "Club Players", "Club Players");
            Signings_and_Hiring = containerDiagram.ApiRest.AddComponent("Signings and Hiring", "Signings and Hiring", "Signings and Hiring");
            Stadium = containerDiagram.ApiRest.AddComponent("Stadium", "Stadium", "Stadium");
            FanClub = containerDiagram.ApiRest.AddComponent("Fan Club", "Fan Club", "Fan Club");
            GamesSchedule = containerDiagram.ApiRest.AddComponent("Games Schedule", "Games Schedule", "Games Schedule");
            Statistics = containerDiagram.ApiRest.AddComponent("Statistics", "Statistics", "Statistics");
            Security = containerDiagram.ApiRest.AddComponent("Security", "Security", "Security");
            Subscriptions = containerDiagram.ApiRest.AddComponent("Subscriptions", "Subscriptions", "Subscriptions");
            Notifications = containerDiagram.ApiRest.AddComponent("Notifications", "Notifications", "Notifications");

            // se crean las relaciones

            League.Uses(containerDiagram.MySQL, "Use");
            League.Uses(contextDiagram.Fifa, "Use", "HTTPS JSON");

            Club_Players.Uses(contextDiagram.Fifa, "Use", "HTTPS JSON");

            Notifications.Uses(contextDiagram.Twilio, "Use", "HTTPS JSON");
            Notifications.Uses(contextDiagram.SendGrind, "Use", "HTTPS JSON");

            Signings_and_Hiring.Uses(contextDiagram.Fifa, "Use", "HTTPS JSON");

            GamesSchedule.Uses(contextDiagram.Twilio, "Use", "HTTPS JSON");
            GamesSchedule.Uses(contextDiagram.Fifa, "Use", "HTTPS JSON");
            GamesSchedule.Uses(contextDiagram.SendGrind, "Use", "HTTPS JSON");

            Subscriptions.Uses(contextDiagram.Paypal, "Use", "HTTPS JSON");
            Subscriptions.Uses(containerDiagram.MySQL, "Use", "HTTPS JSON");

            Statistics.Uses(contextDiagram.Fifa, "Use", "HTTPS JSON");
            Statistics.Uses(containerDiagram.MySQL, "Use");

            FanClub.Uses(contextDiagram.Fifa, "Use", "HTTPS JSON");



            // publish, se agregan los contextos 
            string title = "API Rest Component Diagram";
            ComponentView componentView = c4.ViewSet.CreateComponentView(containerDiagram.ApiRest, title, title);
            componentView.Title = title;

            componentView.AddAllComponents();
            componentView.Add(contextDiagram.Twilio);
            componentView.Add(contextDiagram.Paypal);
            componentView.Add(contextDiagram.SendGrind);
            componentView.Add(contextDiagram.Fifa);
            componentView.Add(containerDiagram.MySQL);

        }

    }
}
