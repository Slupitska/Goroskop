using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Globalization;



namespace Goroskop
{
    public class Date : ContentPage
    {

        public class Goroskop
        {
            private DateTime _dateOfBirth;

            public Goroskop(DateTime dateOfBirth)
            {
                _dateOfBirth = dateOfBirth;
            }

            public int Age
            {
                get
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - _dateOfBirth.Year;
                    if (today.Month < _dateOfBirth.Month || (today.Month == _dateOfBirth.Month && today.Day < _dateOfBirth.Day))
                    {
                        age--;
                    }
                    return age;
                }
            }

            public string ChineseZodiacSign
            {
                get
                {
                    string[] zodiacSigns = { "Обезьяна", "Петух", "Собака", "Свинья", "Крыса", "Бык", "Тигр", "Кролик", "Дракон", "Змея", "Лошадь", "Коза" };
                    return zodiacSigns[_dateOfBirth.Year % 12];
                }
            }

            public string WesternZodiacSign
            {
                get
                {
                    int month = _dateOfBirth.Month;
                    int day = _dateOfBirth.Day;
                    switch (month)
                    {
                        case 1:
                            return day < 20 ? "Козерог" : "Водолей";
                        case 2:
                            return day < 19 ? "Водолей" : "Рыбы";
                        case 3:
                            return day < 21 ? "Рыбы" : "Овен";
                        case 4:
                            return day < 20 ? "Овен" : "Телец";
                        case 5:
                            return day < 21 ? "Телец" : "Близнецы";
                        case 6:
                            return day < 21 ? "Близнецы" : "Рак";
                        case 7:
                            return day < 23 ? "Рак" : "Лев";
                        case 8:
                            return day < 23 ? "Лев" : "Дева";
                        case 9:
                            return day < 23 ? "Дева" : "Весы";
                        case 10:
                            return day < 23 ? "Весы" : "Скорпион";
                        case 11:
                            return day < 22 ? "Скорпион" : "Стрелец";
                        default:
                            return day < 22 ? "Стрелец" : "Козерог";
                    }
                }
            }

            public string DateOfBirth { get; internal set; }
            public string Birth { get; internal set; }

        }

        private DatePicker datePicker;
        private Entry manualDateEntry;
        private Button calculateButton;
        private Button infoButton;
        private Label birth;
        private Label ageLabel;
        private Label chineseZodiacLabel;
        private Label westernZodiacLabel;
        private Label DateOfBirth;
        private DateTime date;

        public Date()
        {
            // Создание DatePicker для ввода даты рождения
            datePicker = new DatePicker()
            {
                Format = "dd.MM.yyyy"
            };
            datePicker.FontSize = 23;
            datePicker.TextColor = Color.HotPink;

            manualDateEntry = new Entry()
            {
                Placeholder = "Введите дату в формате dd.MM.yyyy",
                PlaceholderColor = Color.LightSkyBlue
            };
            manualDateEntry.FontSize = 23;
            manualDateEntry.TextColor = Color.Blue;

            // Создание кнопки для вычисления гороскопа
            calculateButton = new Button()
            {
                Text = "Рассчитать",
                FontAttributes = FontAttributes.Bold
            };
            calculateButton.FontSize = 25;
            calculateButton.TextColor = Color.White;
            calculateButton.BackgroundColor = Color.DodgerBlue;

            calculateButton.Clicked += OnCalculateClicked;

            // Создание меток для вывода результатов гороскопа
            
            birth = new Label();
            ageLabel = new Label();
            chineseZodiacLabel = new Label();
            westernZodiacLabel = new Label();

            birth.FontSize = 25;
            birth.TextColor = Color.DarkBlue;

            ageLabel.FontSize = 25;
            ageLabel.TextColor = Color.DarkBlue;

            chineseZodiacLabel.FontSize = 25;
            chineseZodiacLabel.TextColor = Color.DarkBlue;

            westernZodiacLabel.FontSize = 25;
            westernZodiacLabel.TextColor = Color.DarkBlue;

            Button infoButton = new Button
            {
                Text = "Далее ->",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.DarkOrange,
                BackgroundColor = Color.SpringGreen
            };

            infoButton.Clicked += async (sender, args) =>
            {
                DateTime dateOfBirth;
                Goroskop goroskop = new Goroskop(datePicker.Date);

                if (DateTime.TryParse(manualDateEntry.Text, out dateOfBirth))
                {
                    goroskop = new Goroskop(dateOfBirth);
                }
                else
                {
                    goroskop = new Goroskop(datePicker.Date);
                }

                    await Navigation.PushAsync(new Rezult(goroskop.WesternZodiacSign, goroskop.ChineseZodiacSign, goroskop.DateOfBirth, birth.Text)); //перейти на новую страницу
            };

            var inImage = new Image
            {
                Source = "inyan.jpg", // путь к изображению
                //Aspect = Aspect.AspectFit,
                WidthRequest = 150,
                HeightRequest = 150
            };

            // Создание StackLayout для компоновки элементов на странице
            var stackLayout = new StackLayout()
            {
                //настройка размера и цвета шрифта
                Children =
                {
                    new Label { Text = "Выберите дату рождения из календаря:", FontSize = 20, TextColor = Color.DarkGray },
                    datePicker,
                    new Label { Text = "или", FontSize = 20, TextColor = Color.DarkGray },
                    new Label { Text = "Введите дату рождения вручную:", FontSize = 20, TextColor = Color.DarkGray },
                    manualDateEntry,
                    calculateButton,
                    birth,
                    ageLabel,
                    westernZodiacLabel,
                    chineseZodiacLabel,
                    infoButton,
                    inImage
                }
            };

            Content = stackLayout;
        }

        private async void OnCalculateClicked(object sender, EventArgs e)
        {
            // Получение выбранной пользователем даты рождения
            DateTime dateOfBirth;

            

            if (!string.IsNullOrEmpty(manualDateEntry.Text))
            {
                DateTime date;

                if (!DateTime.TryParseExact(manualDateEntry.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    await DisplayAlert("Ошибка", "Пожалуйста, введите дату рождения корректно", "OK");

                    birth.Text = "Пожалуйста, введите дату рождения в формате дд.ММ.гггг";
                    ageLabel.Text = "";
                    westernZodiacLabel.Text = "";
                    chineseZodiacLabel.Text = "";
                    return;
                }
                dateOfBirth = date;
            }
            else if (datePicker.Date != null)
            {
                dateOfBirth = datePicker.Date;
            }
            else
            {
                birth.Text = "Пожалуйста, введите дату рождения";
                ageLabel.Text = "";
                westernZodiacLabel.Text = "";
                chineseZodiacLabel.Text = "";
                return;
            }

            // Создание экземпляра класса Goroskop для вычисления результатов гороскопа
            var goroskop = new Goroskop(dateOfBirth);

            // Отображение результатов гороскопа на метках на странице
            birth.Text = "Дата рождения: " + dateOfBirth.ToString("dd.MM.yyyy");
            ageLabel.Text = "Ваш возраст: " + goroskop.Age;
            westernZodiacLabel.Text = "Ваш знак Зодиака: " + goroskop.WesternZodiacSign;
            chineseZodiacLabel.Text = "А в Китае Вы: " + goroskop.ChineseZodiacSign;

            // Очистить поле ввода даты рождения, не подходит, иначе тогда не передаются данные на вторую страницу 
            //manualDateEntry.Text = string.Empty;

        }

    }

}
