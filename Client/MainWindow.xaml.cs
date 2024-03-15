using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Client.Models;
using Client.Interfaces;
using Newtonsoft.Json;


namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        string ImagePath = "C:/Users/Илья/Documents/IdImage";
        string HostName = "https://localhost:5000/Woman";

        List<Cat> Pets = new List<Cat>();
        public MainWindow()
        {
            InitializeComponent();
            GetDataAsync();
        }
        public void Refresh_Button(object sender, RoutedEventArgs e)
        {
            GetDataAsync();
            ReadAsPet(tempContent);
            for (int i = 0; i < Pets.Count; i++)
            {
                bool unique = true;
                foreach (var item in WomenListBox.Items)
                {
                    if (Pets[i] == item)
                    {
                        unique = false; break;
                    }
                }
                if (unique == true)
                {
                    Pets[i].ImgPath = System.IO.Path.Combine(ImagePath, $"{Pets[i].Id}.jpg");
                    ImageConverter.WriteJpg(Pets[i].Image, Pets[i].ImgPath);
                    WomenListBox.Items.Add(Pets[i]);
                }
            }
        }

        private async void GetDataAsync()
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(HostName);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    // Обновляем UI в основном потоке
                    Dispatcher.Invoke(() =>
                    {
                        tempContent = "";
                        tempContent = content;

                    });
                }
                else
                {
                    MessageBox.Show("Ошибка при получении данных: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
        string tempContent;

        public void ReadAsPet(string jsonArray)
        {
            List<Cat> womenList = JsonConvert.DeserializeObject<List<Cat>>(jsonArray);
            for (int i = 0; i < womenList.Count; i++)
            {
                bool contains = Pets.Contains(womenList[i]);
                if (!contains)
                {
                    Pets.Add(womenList[i]);
                }
            }

        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            this.AddText("Suka");
        }
    }
}
