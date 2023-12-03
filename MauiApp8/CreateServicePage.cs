namespace MauiApp8;

public class CreateServicePage : ContentPage
{
    public event Action<Service> ServiceCreated;

    private Entry nameEntry;
    private Entry annotationEntry;
    private Entry typeEntry;
    private Entry versionEntry;
    private Entry authorEntry;
    private Entry usageConditionsEntry;
    private Entry registrationInfoEntry;
    private Button createButton;

    public CreateServicePage()
    {
        Title = "Створення нового сервісу";

        nameEntry = new Entry { Placeholder = "Ім'я сервісу" };
        annotationEntry = new Entry { Placeholder = "Анотація" };
        typeEntry = new Entry { Placeholder = "Тип" };
        versionEntry = new Entry { Placeholder = "Версія" };
        authorEntry = new Entry { Placeholder = "Автор" };
        usageConditionsEntry = new Entry { Placeholder = "Умови використання" };
        registrationInfoEntry = new Entry { Placeholder = "Інформація при реєстрації" };

        createButton = new Button { Text = "Створити сервіс" };
        createButton.Clicked += CreateButton_Clicked;

        Content = new StackLayout
        {
            Padding = new Thickness(20),
            Children =
            {
                nameEntry,
                annotationEntry,
                typeEntry,
                versionEntry,
                authorEntry,
                usageConditionsEntry,
                registrationInfoEntry,
                createButton
            }
        };
    }

    private void CreateButton_Clicked(object sender, EventArgs e)
    {
        // Створення нового сервісу і виклик події ServiceCreated
        var newService = new Service
        {
            Name = nameEntry.Text,
            Annotation = annotationEntry.Text,
            Type = typeEntry.Text,
            Version = versionEntry.Text,
            Author = authorEntry.Text,
            UsageConditions = usageConditionsEntry.Text,
            RegistrationInfo = registrationInfoEntry.Text
        };

        ServiceCreated?.Invoke(newService);

        // Закриття поточної сторінки
        Navigation.PopAsync();
    }
}