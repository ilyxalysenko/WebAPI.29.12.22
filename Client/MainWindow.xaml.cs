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
        string docPath = "C:/Users/Илья/Documents/IdImage";
        List<Woman> AllWomen = new List<Woman>();
        public MainWindow()
        {
            InitializeComponent();
            GetDataAsync();
        }
        public void Refresh_Button(object sender, RoutedEventArgs e)
        {
            
            GetDataAsync();
            ReadAsWoman(tempContent);
            for (int i = 0; i < AllWomen.Count; i++)
            {
                bool unique = true;
                foreach (var item in WomenListBox.Items)
                {
                    if (AllWomen[i] == item)
                    {
                        unique = false; break;
                    }
                }
                if (unique == true)
                {
                    AllWomen[i].ImgPath = System.IO.Path.Combine(docPath, $"{AllWomen[i].Id}.jpg");
                    ImageConverter.WriteJpg(AllWomen[i].Image, AllWomen[i].ImgPath);
                    WomenListBox.Items.Add(AllWomen[i]);
                }
            }
        }

        
        private async void GetDataAsync()
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7131/Woman");

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

        public void ReadAsWoman(string jsonArray)
        {
            List<Woman> womenList = JsonConvert.DeserializeObject<List<Woman>>(jsonArray);
            for (int i = 0; i < womenList.Count; i++)
            {
                bool contains = AllWomen.Contains(womenList[i]);
                if (!contains)
                {
                    AllWomen.Add(womenList[i]);
                }
            }

        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            brush.Freeze();
        }
    }
}
