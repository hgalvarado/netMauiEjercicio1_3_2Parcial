namespace netMauiEjercicio1_3
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            var person = new Models.ClassPerson
            {
                name = txtName.Text,
                lastName = txtLastName.Text,
                age = Convert.ToInt32(txtAge.Text),
                email = txtEmail.Text,
                address = txtAddress.Text

            };

            if (await App.Instancia.addPersons(person)>0)
            {
                await DisplayAlert("Aviso", "Persona Agregada", "Ok");
            }
            else 
            {
                await DisplayAlert("Alerta", "Ocurrio un Error, la persona no Agregada", "Ok");
            }

        }
    }
}