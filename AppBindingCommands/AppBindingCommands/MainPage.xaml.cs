namespace AppBindingCommands
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRetrievePreferencesClicked(object sender, EventArgs e)
        {
            var startupTime = Preferences.Default.Get("StartupTime", "Não disponível");
            lblInfo.Text = $"App iniciado em: {startupTime}";
        }
    }
}