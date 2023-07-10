using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using WinDateCalc.ViewModels;

namespace WinDateCalc.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        MainViewModel.CaricaOpzioni();
        background.Stretch=Avalonia.Media.Stretch.Fill;
        data.SelectedDate = new DateTime(MainViewModel.GetAnno(), MainViewModel.GetMese(), MainViewModel.GetGiorno());
    }

    private void calcola_Click(object sender, RoutedEventArgs e)
    {
        risultato.Content = "";
        risultato.Content = MainViewModel.calcola(data.SelectedDate);
        if (!MainViewModel.SalvaOpzioni(MainViewModel.path, data.SelectedDate.Value.Day, data.SelectedDate.Value.Month, data.SelectedDate.Value.Year))
            risultato.Content = "Impossibile salvare le opzioni";
    }
}
