using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using static Goroskop.Date;
using System.Globalization;
using System.Threading.Tasks;

namespace Goroskop
{
    internal class Rezult : ContentPage
    {
        
        //private Goroskop goroskop;
        private Label westernZodiacLabel;
        private Label chineseZodiacLabel;
        private Label infoLabel;
        private Label dopLabel;
        //private Label DateOfBirth;
        //private Label birth;

        //private string westernZodiacSign;
        //private string chineseZodiacSign;

        // Добавляем свойства для полей westernZodiacSign и chineseZodiacSign
        public string WesternZodiacSign { get; }
        public string ChineseZodiacSign { get; }
        public string DateOfBirth { get; }
        public string Brithdate { get; }
        public string ManualDateEntry { get; }
        public string Goroskop { get; }
        public string Birthdate { get; }

        //public Rezult(string westernZodiacSign, string chineseZodiacSign, string DateOfBirth)

        public Rezult(string westernZodiacSign, string chineseZodiacSign, string dateOfBirth, string birthdate) //birthdate - перенесли также строку с выведенной датой рождения
        {
            // Сохраняем значения полей в свойствах
            WesternZodiacSign = westernZodiacSign;
            ChineseZodiacSign = chineseZodiacSign;
            DateOfBirth = dateOfBirth;
            Birthdate = birthdate;

            
            infoLabel = new Label();
            infoLabel.Text = birthdate + " и это: ";
            infoLabel.FontSize = 25;
            infoLabel.TextColor = Color.DodgerBlue;
            infoLabel.HorizontalTextAlignment = TextAlignment.Center;

            westernZodiacLabel = new Label();
            chineseZodiacLabel = new Label();

            westernZodiacLabel.Text = westernZodiacSign + " и " + chineseZodiacSign;
            //chineseZodiacLabel.Text = chineseZodiacSign;

            chineseZodiacLabel.FontSize = 25;
            chineseZodiacLabel.FontAttributes = FontAttributes.Bold;
            chineseZodiacLabel.TextColor = Color.DodgerBlue;
            chineseZodiacLabel.HorizontalTextAlignment = TextAlignment.Center;

            westernZodiacLabel.FontSize = 25;
            westernZodiacLabel.FontAttributes = FontAttributes.Bold;
            westernZodiacLabel.TextColor = Color.DarkOrange;
            westernZodiacLabel.HorizontalTextAlignment = TextAlignment.Center;

            dopLabel = new Label();
            dopLabel.Text = "Прекрасное сочетание!";
            dopLabel.FontSize = 25;
            dopLabel.TextColor = Color.DodgerBlue;
            dopLabel.HorizontalTextAlignment = TextAlignment.Center;

            Button westernZodiacInfoButton = new Button
            {
                Text = westernZodiacSign, //"Зодиак",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.DarkOrange,
                BackgroundColor = Color.SpringGreen
            };
            westernZodiacInfoButton.Clicked += async (sender, args) =>
            {
                // Формирование URL-адреса в зависимости от знака Зодиака пользователя
                string url = "";

                switch (westernZodiacSign.ToLower())
                {
                    case "овен":
                        url = "https://goroskop365.ru/zodiak/aries/";
                        break;
                    case "телец":
                        url = "https://goroskop365.ru/zodiak/taurus/";
                        break;
                    case "близнецы":
                        url = "https://goroskop365.ru/zodiak/gemini/";
                        break;
                    case "рак":
                        url = "https://goroskop365.ru/zodiak/cancer/";
                        break;
                    case "лев":
                        url = "https://goroskop365.ru/zodiak/leo/";
                        break;
                    case "дева":
                        url = "https://goroskop365.ru/zodiak/virgo/";
                        break;
                    case "весы":
                        url = "https://goroskop365.ru/zodiak/libra/";
                        break;
                    case "скорпион":
                        url = "https://goroskop365.ru/zodiak/scorpio/";
                        break;
                    case "стрелец":
                        url = "https://goroskop365.ru/zodiak/sagittarius/";
                        break;
                    case "козерог":
                        url = "https://goroskop365.ru/zodiak/capricorn/";
                        break;
                    case "водолей":
                        url = "https://goroskop365.ru/zodiak/aquarius/";
                        break;
                    case "рыбы":
                        url = "https://goroskop365.ru/zodiak/pisces/";
                        break;
                    default:
                        break;
                }

                // Переход по URL-адресу в новом окне браузера
                await Launcher.OpenAsync(new Uri(url));
            };

            Button chineseZodiacInfoButton = new Button
            {
                Text = chineseZodiacSign, //"Китайский гороскоп",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.DarkOrange,
                BackgroundColor = Color.SpringGreen
            };
            chineseZodiacInfoButton.Clicked += async (sender, args) =>
            {
                string url = "";
                switch (chineseZodiacSign)
                {
                    case "Крыса":
                        url = "https://goroskop365.ru/china/krysa/";
                        break;
                    case "Бык":
                        url = "https://goroskop365.ru/china/byk/";
                        break;
                    case "Тигр":
                        url = "https://goroskop365.ru/china/tigr/";
                        break;
                    case "Кролик":
                        url = "https://goroskop365.ru/china/zayats/";
                        break;
                    case "Дракон":
                        url = "https://goroskop365.ru/china/drakon/";
                        break;
                    case "Змея":
                        url = "https://goroskop365.ru/china/zmeja/";
                        break;
                    case "Лошадь":
                        url = "https://goroskop365.ru/china/loshad/";
                        break;
                    case "Коза":
                        url = "https://goroskop365.ru/china/koza/";
                        break;
                    case "Обезьяна":
                        url = "https://goroskop365.ru/china/obezyana/";
                        break;
                    case "Петух":
                        url = "https://goroskop365.ru/china/petuh/";
                        break;
                    case "Собака":
                        url = "https://goroskop365.ru/china/sobaka/";
                        break;
                    case "Свинья":
                        url = "https://goroskop365.ru/china/svinja/";
                        break;
                    default:
                        break;
                }
                if (!string.IsNullOrEmpty(url))
                {
                    await Launcher.OpenAsync(new Uri(url));
                }
            };

            Button combinedZodiacInfoButton = new Button
            {
                Text = $"{westernZodiacSign} + {chineseZodiacSign}", //"Китай + Зодиак",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.DarkOrange,
                BackgroundColor = Color.SpringGreen
            };
            combinedZodiacInfoButton.Clicked += async (sender, args) =>
            {
                string url = "";
                switch ($"{westernZodiacSign} + {chineseZodiacSign}")
                {
                    case "Стрелец + Дракон":
                        url = "https://goroskop365.ru/goroskop-kitaj-zodiak/strelec-drakon/";
                        break;
                    case "Водолей + Крыса":
                        url = "https://goroskop365.ru/goroskop-kitaj-zodiak/vodolej-krysa/";
                        break;
                    case "Козерог + Тигр":
                        url = "https://goroskop365.ru/goroskop-kitaj-zodiak/kozerog-tigr/";
                        break;
                    case "Дева + Дракон":
                        url = "https://goroskop365.ru/goroskop-kitaj-zodiak/deva-drakon/";
                        break;
                    case "Овен + Тигр":
                        url = "https://goroskop365.ru/goroskop-kitaj-zodiak/oven-tigr/";
                        break;

                        //так как не все сочетания сюда прописаны - это очень утомительно и будет очень объёмный код,
                        //то по умолчанию будет переход на общую страницу, там есть возможность выбрать свои знаки
                    default:
                        url = "https://goroskop365.ru/goroskop-kitaj-zodiak/";
                        break;
                }
                if (!string.IsNullOrEmpty(url))
                {
                    await Launcher.OpenAsync(new Uri(url));
                }
            };

            Button goroskopMayaButton = new Button
            {
                Text = "Гороскоп Майя", //"Китай + Зодиак",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.HotPink,
                BackgroundColor = Color.SpringGreen
            };
            goroskopMayaButton.Clicked += async (sender, args) =>
            {
                var url = "https://goroskop365.ru/maya/";
                await Launcher.OpenAsync(new Uri(url));
            };

            var backgroundImage = new Image
            {
                Source = "goros.jpg", // путь к изображению
                //Aspect = Aspect.AspectFit,
                WidthRequest = 250,
                HeightRequest = 250
                //VerticalOptions = LayoutOptions.FillAndExpand,
                //HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Content = new StackLayout
            {
                //BackgroundColor = Color.Transparent, // прозрачный фон для StackLayout

                Children =
                {
                    backgroundImage,
                    infoLabel,
                    westernZodiacLabel,
                    //chineseZodiacLabel,
                    dopLabel,
                    westernZodiacInfoButton,
                    chineseZodiacInfoButton,
                    combinedZodiacInfoButton,
                    goroskopMayaButton
                }
            };
        }
    }
}
