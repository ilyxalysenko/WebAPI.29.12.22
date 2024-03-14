using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using WomenView.Models;
using System.Net;
using System.IO;
using System.Net.Http.Json;

namespace WomenView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Woman> Women = new List<Woman>();

        
        public async void Get()
        {
            HttpClient httpClient = new HttpClient();
            Women = await httpClient.ReadFromJsonAsync<List<Woman>>("https://localhost:7094/api/users");
            if (Women != null)
            {
                foreach (var person in Women)
                {
                    Console.WriteLine(person.Name);
                }
            }
        }


        public MainWindow()
        {

            InitializeComponent();
        }
    }
}
