namespace AppBindingCommands
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.UsuarioView), typeof(Views.UsuarioView));
        }
    }
}
