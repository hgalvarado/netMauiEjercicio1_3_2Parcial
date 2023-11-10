using System.Xml.Linq;

namespace netMauiEjercicio1_3.Views;

public partial class PageUpdatePerson : ContentPage
{

    int idUpdate;
	public PageUpdatePerson()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        idUpdate = PageListPerson.idUpdate;
        txtUpdName.Text = PageListPerson.nameUpdate;
        txtUpdLastName.Text = PageListPerson.LastNameUpdate;
        txtUpdAge.Text = PageListPerson.ageUpdate.ToString();
        txtUpdEmail.Text = PageListPerson.emailUpdate;
        txtUpdAddress.Text = PageListPerson.adrressUpdate;
    }
    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {

        var persons = new Models.ClassPerson
        {
            idClass = PageListPerson.idUpdate,
            name = txtUpdName.Text,
            lastName = txtUpdLastName.Text,
            age = Convert.ToInt32(txtUpdAge.Text),
            email = txtUpdEmail.Text,
            address = txtUpdAddress.Text


        };
        await DisplayAlert("Actualizar Persona","Persona Actualizada:  "+ persons.name, "Ok");
             await App.Instancia.addPersons(persons);
             await Navigation.PopAsync();
    }
}