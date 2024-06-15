using c4_model_template;
using Structurizr;


namespace ctx_diagram
{
  public class ContextDiagram
  {

    private readonly C4 c4;

    // Se coloca los person o lo que interactuan con el sistema
    public Person Admin { get; private set; }
    public Person Subscriber { get; private set; }


    // Los sistemas que interactuan
    public SoftwareSystem System { get; private set; }


    public SoftwareSystem Twilio { get; private set; }
    public SoftwareSystem SendGrind { get; private set; }
    public SoftwareSystem Fifa { get; private set; }
    public SoftwareSystem Paypal { get; private set; }

    public ContextDiagram(C4 c4)
    {
      this.c4 = c4;
    }

    public void Generate() {
      // Se generan los elementos del sistema como la persona y los sistemas con los que interactua
      // (name, description)
      Admin = c4.Model.AddPerson("Administrator", "User who manages the system.");
      Subscriber = c4.Model.AddPerson("Subscriber", "User who consumes the system.");

      System = c4.Model.AddSoftwareSystem("System", "System to manage tickets.");
      Twilio = c4.Model.AddSoftwareSystem("Twilio API", "Use to send SMS through the WhatsApp API.");
      SendGrind = c4.Model.AddSoftwareSystem("SendGrind API", "Use to send emails.");
      Paypal = c4.Model.AddSoftwareSystem("Paypal API", "Use to pay tickets.");
      Fifa = c4.Model.AddSoftwareSystem("FIFA", "Use the system to get information about the games.");

      // Se crean las relaciones entre los elementos
      Admin.Uses(System, "Manage the system and their features.");
      Subscriber.Uses(System, "Use the system to get information about the games.");

      System.Uses(Twilio, "To send SMS through the WhatsApp API.");
      System.Uses(SendGrind, "To send emails.");
      System.Uses(Paypal, "To pay tickets.");
      System.Uses(Fifa, "To get information about the games, teams, players, etc.");
      

      SystemContextView contextView = c4.ViewSet.CreateSystemContextView(System, "Context", "Diagram Context");
      contextView.AddAllPeople();
      contextView.AddAllSoftwareSystems();
    }


  }


}