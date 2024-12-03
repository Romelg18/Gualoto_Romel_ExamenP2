namespace Gualoto_Romel_ExamenP2;

public partial class RecargaPage : ContentPage
{
    public string UltimaRecarga { get; set; }

    public RecargaPage()
    {
        InitializeComponent();
        BindingContext = this;
        CargarUltimaRecarga();
    }

    private async void OnRecargaClicked(object sender, EventArgs e)
    {
        string nombre = rgualoto_entry1.Text;
        string telefono = rgualoto_entry2.Text;

        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
        {
            await DisplayAlert("Error", "Debe completar todos los campos", "OK");
            return;
        }

        string recargaInfo = $"Nombre: {nombre}, Teléfono: {telefono}";
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "RomelGualoto.txt");

        File.WriteAllText(filePath, recargaInfo);

        UltimaRecarga = recargaInfo;
        OnPropertyChanged(nameof(UltimaRecarga));

        await DisplayAlert("Éxito", "Recarga realizada correctamente", "OK");
    }

    private void CargarUltimaRecarga()
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "RomelGualoto.txt");
        if (File.Exists(filePath))
        {
            UltimaRecarga = File.ReadAllText(filePath);
        }
    }
}