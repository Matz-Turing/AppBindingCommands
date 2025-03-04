using AppBindingCommands.ViewModels;

namespace AppBindingCommands.Views;

public partial class UsuarioView : ContentPage
{
    private readonly UsuarioViewModel viewModel;

    // Modificando o construtor para usar a injeção de dependência
    public UsuarioView(UsuarioViewModel viewModel)
    {
        InitializeComponent();

        // Atribuindo a ViewModel recebida via DI ao BindingContext
        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }
}
