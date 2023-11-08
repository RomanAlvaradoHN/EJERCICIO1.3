namespace EJERCICIO1._3.Views;
using Models;

public partial class DatosPersona : ContentPage
{
    private Boolean updateMode = false;
    private int idToUpdate;


	public DatosPersona()
	{
		InitializeComponent();
	}


    public DatosPersona(int id) {
        InitializeComponent();
        ShowDataFromId(id);
        updateMode = true;
        idToUpdate = id;
    }






    private async void ShowDataFromId(int id) {
        Personas p = await App.db.SelectById(id);
        txtNombres.Text = p.Nombres;
        txtApellidos.Text = p.Apellidos;
        txtEdad.Text = p.Edad.ToString();
        txtCorreo.Text = p.Correo;
        txtDireccion.Text = p.Direccion;
    }



    private async void OnBtnGuadarDatosClicked(object sender, EventArgs e) {
        int edad = 0;
        if (int.TryParse(txtEdad.Text, out int valor)) {
            edad = valor;
        }

        Personas persona = new Personas(    
            txtNombres.Text,
            txtApellidos.Text,
            edad,
            txtCorreo.Text,
            txtDireccion.Text
        );
            

        if (!persona.GetDatosInvalidos().Any()) {
            if (updateMode) {
                persona.Id = idToUpdate;
                await App.db.Update(persona);
                await DisplayAlert("Datos Personales", "Datos guardados", "OK");
                await Navigation.PopAsync();

            } else{
                await App.db.Insert(persona);
                await DisplayAlert("Datos Personales", "Datos guardados", "OK");
            }
            
            
            LimpiarCampos();

        } else {
            string msj = string.Join("\n", persona.GetDatosInvalidos());
            await DisplayAlert("Datos Invalidos:", msj, "acepar");
        }
    }




    private async void OnBtnListaClicked(object sender, EventArgs e) {
        await Navigation.PushAsync(new Listado());
    }




    private void LimpiarCampos() {
        txtNombres.Text = string.Empty;
        txtApellidos.Text = string.Empty;
        txtEdad.Text = string.Empty;
        txtCorreo.Text = string.Empty;
        txtDireccion.Text = string.Empty;
    }
}