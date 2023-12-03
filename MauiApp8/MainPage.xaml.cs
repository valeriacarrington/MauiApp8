
using Microsoft.Maui.Storage;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Newtonsoft.Json;
using System.Text;
namespace MauiApp8
{
    public partial class MainPage : ContentPage
    {
        private Button jsonFileButton;
        private Button exitButton;
        private Button aboutButton;
        private Button deserializeButton;
        private Button visualizationButton;
        private Button serializeButton;
        private Button saveButton;
        private Button saveSearchButton;
        private List<Service> services;
        private Picker attributePicker;
        private Entry searchEntry;
        private string selectedAttribute = "";
        private string keywords = "";
        private Button SearchButton;

        string jsonString = string.Empty;
        public MainPage()
        {
            jsonFileButton = new Button
            {
                Text = "Вибрати файл JSON"
            };
            jsonFileButton.Clicked += OnJsonFileButtonClicked;
            deserializeButton = new Button
            {
                Text = "Десереалізувати файл JSON"
            };
            deserializeButton.Clicked += OnDeserializeButtonClicked;
            visualizationButton = new Button
            {
                Text = "Візуалізувати список"
            };
            visualizationButton.Clicked += OnVisualizationButtonClicked;
            exitButton = new Button
            {
                Text = "Вихід"
            };
            exitButton.Clicked += OnExitButtonClicked;
            aboutButton = new Button
            {
                Text = "Про програму"
            };
            aboutButton.Clicked += OnAboutButtonClicked;
            serializeButton = new Button
            {
                Text = "Серіалізувати"
            };
            serializeButton.Clicked += OnSerializeButtonClicked;
            saveButton = new Button
            {
                Text = "Зберегти json До"
            };
            attributePicker = new Picker
            {
                Title = "Виберіть атрибут для пошуку"
            };
            attributePicker.Items.Add("Name");
            attributePicker.Items.Add("Type");
            attributePicker.Items.Add("Author");
            searchEntry = new Entry
            {
                Placeholder = "Введіть ключове слово"
            };
            var saveSearchButton = new Button
            {
                Text = "Зберегти"
            };
            SearchButton = new Button
            {
                Text = "Пошук по ключовим словам"
            };
            SearchButton.Clicked += OnSearchButtonClicked;
            saveSearchButton.Clicked += OnSaveSearchButtonClicked;
            saveButton.Clicked += OnSaveButtonClicked;
            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(jsonFileButton);
            stackLayout.Children.Add(deserializeButton);
            stackLayout.Children.Add(attributePicker);
            stackLayout.Children.Add(searchEntry);
            stackLayout.Children.Add(saveSearchButton);
            stackLayout.Children.Add(SearchButton);
            stackLayout.Children.Add(visualizationButton);
            stackLayout.Children.Add(serializeButton);
            stackLayout.Children.Add(saveButton);
            stackLayout.Children.Add(aboutButton);
            stackLayout.Children.Add(exitButton);
            Content = stackLayout;
        }
        private void OnSearchButtonClicked(object sender, EventArgs e)
        {

var filteredServices = services.Where(service =>
{
    switch (selectedAttribute)
    {
        case "Name":
            return service.Name.Contains(keywords);
        case "Type":
            return service.Type.Contains(keywords);
        case "Author":
            return service.Author.Contains(keywords);
        default:
            return false;
    }
}).ToList();
            if (filteredServices != null)
            {
                var result = "Count elements that contain a keyword:" + filteredServices.Count() + "\n";
                foreach (var item in filteredServices)
                {
                    result += item.Print() + "\n\n";
                }
                DisplayAlert("Result", result, "OK");
            }
        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            using var stream = new MemoryStream(Encoding.Default.GetBytes(jsonString));
            await FileSaver.SaveAsync("result.json", stream);
        }
        private void OnSaveSearchButtonClicked(object sender, EventArgs e)
        {
            selectedAttribute = attributePicker.SelectedItem.ToString();
            keywords = searchEntry.Text;
            DisplayAlert("Збережено", $"Атрибут: {selectedAttribute}, Ключові слова: {keywords}", "OK");
        }

        private void OnSerializeButtonClicked(object sender, EventArgs e)
        {
            jsonString = JsonConvert.SerializeObject(services);
        }

        private async void OnVisualizationButtonClicked(object sender, EventArgs e)
        {

            var serviceListPage = new ServiceListPage(services);
            await Navigation.PushAsync(serviceListPage);
        }

        private void OnDeserializeButtonClicked(object sender, EventArgs e)
        {
            services = JsonConvert.DeserializeObject<List<Service>>(jsonString);
        }

        private async void OnJsonFileButtonClicked(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync();

            if (file != null)
            {
                string filePath = file.FullPath;
                jsonString = File.ReadAllText(filePath);
            }
        }

        private void OnAboutButtonClicked(object sender, EventArgs e)
        {
            var aboutText = "";
            DisplayAlert("Про програму", aboutText, "OK");
        }

        private async void OnExitButtonClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Підтвердження", "Чи дійсно ви хочете завершити роботу з програмою?", "Так", "Ні");
            if (result)
            {
                Environment.Exit(0);
            }
        }
    }

}