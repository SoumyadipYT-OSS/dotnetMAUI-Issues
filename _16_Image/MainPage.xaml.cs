using System.IO;
using System.Reflection;

namespace _16_Image
{
    public partial class MainPage : ContentPage
    {
        public Microsoft.Maui.Controls.ImageSource? MyImageSource { get; set; }

        public MainPage() {
            InitializeComponent();
            LoadImageFromStream();
            BindingContext = this;
        }


        private async void LoadImageFromStream() {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "Resources/Images/dotnet_bot.png");

            if (File.Exists(filePath)) {
                Stream imageStream = await GetImageStream(filePath);
                MyImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => imageStream);
                OnPropertyChanged(nameof(MyImageSource));
                Console.WriteLine("Image stream loaded successfully");
            } else {
                Console.WriteLine("Image file not found: " + filePath);
            }
        }

        private static async Task<Stream> GetImageStream(string filePath) {
            return await Task.Run(() => File.OpenRead(filePath));
        }
    }

}
