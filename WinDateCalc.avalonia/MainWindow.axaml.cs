using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace WinDateCalc.avalonia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            data.SelectedDate = new DateTimeOffset(DateTime.Now);
        }

        private void calcola_Click(object sender, RoutedEventArgs e)
        {
            String s, giorni, ore, minuti;
            int i;
            DateTimeOffset d = new DateTimeOffset(DateTime.Now);
            if (data.SelectedDate == null) { return; }
            TimeSpan? differenza = data.SelectedDate - d;
            s = differenza.ToString();
            if (s.IndexOf("-") == 0)
            {
                risultato.Content = "La data è già passata.";
                return;
            }
            s = s.Substring(0, s.LastIndexOf("."));
            i = s.IndexOf(".");
            if (i == -1)
                giorni = "0";
            else
            {
                giorni = s.Substring(0, i);
                s = s.Substring(i+1);
            }
            i = s.IndexOf(":");
            if (i == -1)
                ore = "0";
            else ore = s.Substring(0, i);
            s = s.Substring(i+1);
            i = s.IndexOf(":");
            minuti=s.Substring(0, i);
            s.Substring(i+1);
            risultato.Content = $"Mancano {giorni} giorni, {ore} ore {minuti} minuti.";
        }
    }
}
