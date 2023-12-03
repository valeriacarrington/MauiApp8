using MauiApp8;

namespace MauiApp8;

public class ServiceListPage : ContentPage
{
    ListView listView;

    public ServiceListPage(List<Service> services)
    {
        Title = "Список сервісів";

        listView = new ListView
        {
            ItemsSource = services,
            ItemTemplate = new DataTemplate(() =>
            {
            // Створення нового ViewCell.
            var viewCell = new ViewCell();

            // Створення Grid для відображення даних.
            var grid = new Grid();
            for (int i = 0; i < 9; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            // Додавання даних у Grid.
            var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
            var annotationLabel = new Label();
            var typeLabel = new Label();
            var versionLabel = new Label();
            var authorLabel = new Label();
            var usageConditionsLabel = new Label();
            var registrationInfoLabel = new Label();

            grid.Children.Add(nameLabel);
            grid.Children.Add(annotationLabel);
            grid.Children.Add(typeLabel);
            grid.Children.Add(versionLabel);
            grid.Children.Add(authorLabel);
            grid.Children.Add(usageConditionsLabel);
            grid.Children.Add(registrationInfoLabel);

            nameLabel.SetBinding(Label.TextProperty, "Name");
            annotationLabel.SetBinding(Label.TextProperty, "Annotation");
            typeLabel.SetBinding(Label.TextProperty, "Type");
            versionLabel.SetBinding(Label.TextProperty, "Version");
            authorLabel.SetBinding(Label.TextProperty, "Author");
            usageConditionsLabel.SetBinding(Label.TextProperty, "UsageConditions");
            registrationInfoLabel.SetBinding(Label.TextProperty, "RegistrationInfo");

            // Додавання елементів до рядка Grid.
            Grid.SetColumn(nameLabel, 0);
            Grid.SetColumn(annotationLabel, 1);
            Grid.SetColumn(typeLabel, 2);
            Grid.SetColumn(versionLabel, 3);
            Grid.SetColumn(authorLabel, 4);
            Grid.SetColumn(usageConditionsLabel, 5);
            Grid.SetColumn(registrationInfoLabel, 6);
            var editButton = new Button { Text = "Редагувати" };
            editButton.Clicked += async (sender, e) =>
            {
                // Логіка редагування
                var service = (Service)((Button)sender).BindingContext;
                // Виклик методу для редагування сервісу (наприклад, відкриття нової сторінки для редагування)
                var editServicePage = new EditServicePage(service); // Припустимо, у вас є сторінка для редагування
                await Navigation.PushAsync(editServicePage);
                listView.ItemsSource = null;
                listView.ItemsSource = services;
            };
            var deleteButton = new Button { Text = "Видалити" };
            deleteButton.Clicked += (sender, e) =>
            {
                // Логіка видалення
                var service = (Service)((Button)sender).BindingContext;
                services.Remove(service);
                listView.ItemsSource = null;
                listView.ItemsSource = services;
            };
            var buttonStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { editButton, deleteButton }
            };
            grid.Children.Add(deleteButton);
            grid.Children.Add(editButton);
            //grid.Children.Add(buttonStackLayout);
            grid.SetColumn(deleteButton, 7);
            grid.SetColumn(editButton, 8);
            viewCell.View = grid;
            return viewCell;
            })
        };
        var addButton = new Button { Text = "Додати новий сервіс" };
        addButton.Clicked += async (sender, e) =>
        {
            // Виклик нової сторінки для створення сервісу
            var createServicePage = new CreateServicePage();
            createServicePage.ServiceCreated += (service) =>
            {
                // Додаємо новий сервіс до списку
                services.Add(service);
                Device.BeginInvokeOnMainThread(() =>
                {
                    listView.ItemsSource = null;
                    listView.ItemsSource = services;
                });
            };

            await Navigation.PushAsync(createServicePage);

        };
        // Додавання ListView до сторінки.
        Content = new StackLayout
        {
            Children = { listView, addButton }
        };
    }

}