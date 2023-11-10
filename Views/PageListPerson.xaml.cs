using netMauiEjercicio1_3.Models;

namespace netMauiEjercicio1_3.Views;

public partial class PageListPerson : ContentPage
{

    ClassPerson itemSeleccionado=null;
    public static int idUpdate;
    public static String nameUpdate;
    public static String LastNameUpdate;
    public static int ageUpdate;
    public static String emailUpdate;
    public static String adrressUpdate;



    public PageListPerson()
	{
		InitializeComponent();


	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        list.ItemsSource = await App.Instancia.listPersons();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            itemSeleccionado = e.CurrentSelection.FirstOrDefault() as ClassPerson;

            string accion = await DisplayActionSheet("Accion: ", "Cancelar", null, "Ver Informacion","Actualizar Informacion", "Eliminar Persona");

            if (accion.Equals("Eliminar Persona"))
            {
                bool respuesta = await DisplayAlert("Accion", "Desea Elminarlo?", "Si", "No");
                if (respuesta)
                {
                    await App.Instancia.DeletePersons(itemSeleccionado);
                    list.ItemsSource = await App.Instancia.listPersons();
                    itemSeleccionado = null;
                }
            }
            if (accion.Equals("Ver Informacion"))
            {
                await DisplayAlert("Informacion Usuario", "Nombre: \n" + itemSeleccionado.name + "\n\n" +
                    "Apellido: \n" + itemSeleccionado.lastName + "\n\n" +
                    "Edad: \n" + itemSeleccionado.age + "\n\n" +
                    "Correo Electronico: \n" + itemSeleccionado.email + "\n\n" +
                    "Dirección: \n" + itemSeleccionado.address,"Ok");
            }
            
            if(accion.Equals("Actualizar Informacion"))
            {
                nameUpdate = itemSeleccionado.name;
                LastNameUpdate = itemSeleccionado.lastName;
                ageUpdate = itemSeleccionado.age;
                emailUpdate = itemSeleccionado.email;
                adrressUpdate = itemSeleccionado.address;
                idUpdate = itemSeleccionado.idClass;

                await Navigation.PushAsync(new Views.PageUpdatePerson());
            }

            list.SelectedItem = null;
        }

    }
}