namespace netMauiEjercicio1_3
{
    public partial class App : Application
    {


        static Controllers.DBProc dbProc;
        public static Controllers.DBProc Instancia
        {
            get
            {
                if (dbProc == null)
                {
                    string dbname = "netMauipersonDB.db3";
                    string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbfull = Path.Combine(dbpath, dbname);
                    dbProc = new Controllers.DBProc(dbfull);
                }
                return dbProc;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
           MainPage = new NavigationPage(new Views.PageListPerson());
        }
    }
}