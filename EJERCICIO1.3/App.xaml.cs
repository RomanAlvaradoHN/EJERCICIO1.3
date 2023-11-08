using EJERCICIO1._3.Controllers;
using EJERCICIO1._3.Views;

namespace EJERCICIO1._3 {
    public partial class App : Application {
        public static readonly DBController db = new DBController();

        public App() {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new DatosPersona());
        }
    }
}