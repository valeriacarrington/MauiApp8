using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp8
{
    public class EditServicePage : ContentPage
    {
        private Service service;
        private Entry nameEntry;
        private Entry annotationEntry;
        private Entry typeEntry;
        private Entry versionEntry;
        private Entry authorEntry;
        private Entry usageConditionsEntry;
        private Entry registrationInfoEntry;
        private Button saveButton;

        public EditServicePage(Service service)
        {
            Title = "Редагування сервісу";
            this.service = service;

            nameEntry = new Entry { Placeholder = "Ім'я сервісу", Text = service.Name };
            annotationEntry = new Entry { Placeholder = "Анотація", Text = service.Annotation };
            typeEntry = new Entry { Placeholder = "Тип", Text = service.Type };
            versionEntry = new Entry { Placeholder = "Версія", Text = service.Version };
            authorEntry = new Entry { Placeholder = "Автор", Text = service.Author };
            usageConditionsEntry = new Entry { Placeholder = "Умови використання", Text = service.UsageConditions };
            registrationInfoEntry = new Entry { Placeholder = "Інформація при реєстрації", Text = service.RegistrationInfo };

            saveButton = new Button { Text = "Зберегти зміни" };
            saveButton.Clicked += SaveButton_Clicked;

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
                saveButton
            }
            };
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Збереження змін до об'єкта Service
            service.Name = nameEntry.Text;
            service.Annotation = annotationEntry.Text;
            service.Type = typeEntry.Text;
            service.Version = versionEntry.Text;
            service.Author = authorEntry.Text;
            service.UsageConditions = usageConditionsEntry.Text;
            service.RegistrationInfo = registrationInfoEntry.Text;

            // Оповіщення про закінчення редагування та повернення на попередню сторінку
            Navigation.PopAsync();
        }
    }
}
