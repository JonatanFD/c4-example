using c4_model_template;
using Structurizr;


namespace ctx_diagram
{
  public class ContextDiagram
  {

    private readonly C4 c4;

    // Se coloca los person o lo que interactuan con el sistema

    public Person PlantOperator { get; private set; }
    public Person Admin { get; private set; }


    // Los sistemas que interactuan
    public SoftwareSystem System { get; private set; }


    public SoftwareSystem Twilio { get; private set; }
    public SoftwareSystem SendGrind { get; private set; }
    public SoftwareSystem GovernmentAPI { get; private set; }

    public ContextDiagram(C4 c4)
    {
      this.c4 = c4;
    }

    public void ApplyStyles()
    {
      PlantOperator.AddTags("Plant Operator");
      Admin.AddTags("Admin");
      System.AddTags("GEGMS");
      Twilio.AddTags("Twilio");
      SendGrind.AddTags("SendGrind"); 
      GovernmentAPI.AddTags("GovernmentAPI");
      // Define estilos en el conjunto de vistas
      Styles styles = c4.ViewSet.Configuration.Styles;

      // Personas
      styles.Add(new ElementStyle("Plant Operator") { Background = "#084C61", Color = "#FFFFFF", Shape = Shape.Person, Icon = "https://example.com/operator-icon.png" });
      styles.Add(new ElementStyle("Admin") { Background = "#4CAF50", Color = "#FFFFFF", Shape = Shape.Person, Icon = "https://example.com/admin-icon.png" });

      // Software Systems
      styles.Add(new ElementStyle("GEGMS") { Background = "#1E88E5", Color = "#FFFFFF", Shape = Shape.RoundedBox, FontSize = 24 });
      styles.Add(new ElementStyle("Twilio") { Background = "#F22F46", Color = "#FFFFFF", Shape = Shape.RoundedBox });
      styles.Add(new ElementStyle("SendGrind") { Background = "#FFC107", Color = "#000000", Shape = Shape.RoundedBox });
      styles.Add(new ElementStyle("GovernmentAPI") { Background = "#673AB7", Color = "#FFFFFF", Shape = Shape.RoundedBox });
    }

    public void Generate()
    {
      // Se generan los elementos del sistema como la persona y los sistemas con los que interactua
      // (name, description)
      PlantOperator = c4.Model.AddPerson("Plant Operator", "User who manages the system");
      Admin = c4.Model.AddPerson("Administrator", "User who manages the system");

      System = c4.Model.AddSoftwareSystem("Global Energy Generation Management System", "System to manage tickets.");

      Twilio = c4.Model.AddSoftwareSystem("Twilio API", "Use to send SMS through the WhatsApp API");
      SendGrind = c4.Model.AddSoftwareSystem("SendGrind API", "Use to send emails");
      GovernmentAPI = c4.Model.AddSoftwareSystem("Government API", "Use to get information about the regulations and other information.");

      // Se generan las relaciones entre los elementos
      PlantOperator.Uses(System, "Manage the system and their features.");
      Admin.Uses(System, "Manage the system and their features.");

      System.Uses(Twilio, "To send SMS through the WhatsApp API.");
      System.Uses(SendGrind, "To send emails.");
      System.Uses(GovernmentAPI, "To get information about the regulations and other information.");

      ApplyStyles();

      SystemContextView contextView = c4.ViewSet.CreateSystemContextView(System, "Context", "Diagram Context");
      contextView.AddAllPeople();
      contextView.AddAllSoftwareSystems();
    }


  }


}