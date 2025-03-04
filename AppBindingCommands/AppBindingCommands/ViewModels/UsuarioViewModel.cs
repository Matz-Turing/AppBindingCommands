using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppBindingCommands.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }

        public string DisplayName => $"Olá, {Name}";

        private string _displayMessage = string.Empty;
        public string DisplayMessage
        {
            get => _displayMessage;
            set
            {
                if (_displayMessage != value)
                {
                    _displayMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowMessageCommand { get; }
        public ICommand CountCommand { get; }
        public ICommand CleanCommand { get; }
        public ICommand OptionCommand { get; }

        public UsuarioViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
            CountCommand = new Command(CountCharacters);
            CleanCommand = new Command(async () => await CleanFields()); // Correção para async Task
            OptionCommand = new Command(async () => await ShowOptions()); // Correção para async Task
        }

        private void ShowMessage()
        {
            DisplayMessage = $"Mensagem exibida em: {DateTime.Now}";
        }

        private void CountCharacters()
        {
            DisplayMessage = $"Número de caracteres: {Name.Length}";
        }

        private async Task CleanFields()
        {
            if (Application.Current?.MainPage == null)
                return;

            bool result = await Application.Current.MainPage.DisplayAlert(
                "Confirmação",
                "Deseja limpar os campos?",
                "Sim",
                "Não");

            if (result)
            {
                Name = string.Empty;
                DisplayMessage = string.Empty;
            }
        }

        private async Task ShowOptions()
        {
            if (Application.Current?.MainPage == null)
                return;

            string action = await Application.Current.MainPage.DisplayActionSheet(
                "Escolha uma opção",
                "Cancelar",
                null,
                "Opção 1",
                "Opção 2",
                "Opção 3");

            DisplayMessage = $"Você escolheu: {action}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
