using System.Windows.Input;

namespace EJERCICIO1._3.Views;

public partial class Listado : ContentPage
{
	public Listado()
	{
		InitializeComponent();
	}


    protected override async void OnAppearing() {
        base.OnAppearing();

        viewListado.ItemsSource = await App.db.SelectAll();
    }




    public ICommand ComandoUpdate => new Command<int>(async (id) => {
        await Navigation.PushAsync(new DatosPersona(id));
    });


    public ICommand ComandoDelete => new Command<int>(async (id) => {
        try {
            await App.db.Delete(await App.db.SelectById(id));
            await DisplayAlert("Atencion", "Registro eliminado con exito", "Aceptar");
            viewListado.ItemsSource = await App.db.SelectAll();

        } catch (Exception ex) {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }

    });
}