using System.IO;
using System;

namespace WinDateCalc.ViewModels;

public class MainViewModel : ViewModelBase
{
    private static Opzioni o;
    public static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    public static void CaricaOpzioni()
    {
        LeggiOpzioni(path);
    }
    private static void LeggiOpzioni(String folder)
    {
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
        StreamReader file;
        try
        {
            file = new StreamReader(folder + "opzioni.json");
        }
        catch (FileNotFoundException ex)
        {
            DateTime d = DateTime.Now;
            o = new Opzioni();
            o.day = d.Day;
            o.month = d.Month;
            o.year = d.Year;
            return;
        }
        string s = file.ReadToEnd();
        file.Close();
        o = Newtonsoft.Json.JsonConvert.DeserializeObject<Opzioni>(s);
        if (o == null)
        {
            DateTime d = DateTime.Now;
            o = new Opzioni();
            o.day = d.Day;
            o.month = d.Month;
            o.year = d.Year;
        }
    }

    public static bool SalvaOpzioni(String folder, int d, int m, int y)
    {
        if (d < 0 || m < 0 || y < 0)
            return false;
        o.day = d;
        o.month = m;
        o.year = y;
        StreamWriter w = new StreamWriter(folder + "opzioni.json");
        w.Write(Newtonsoft.Json.JsonConvert.SerializeObject(o));
        w.Close();
        return true;
    }

    public static int GetGiorno() { return o.day; }
    public static int GetMese() { return o.month; }
    public static int GetAnno() { return o.year; }
    public static String calcola(DateTimeOffset? date)
    {
        String s, giorni, ore, minuti;
        int i;
        if (date == null)
            return "Data non selezionata";
        DateTimeOffset d = new DateTimeOffset(DateTime.Now);
        TimeSpan differenza = (DateTimeOffset)date - d;
        s = differenza.ToString();
        if (s.IndexOf("-") == 0)
        {
            return "La data è già passata."; ;
        }
        s = s.Substring(0, s.LastIndexOf("."));
        i = s.IndexOf(".");
        if (i == -1)
            giorni = "0";
        else
        {
            giorni = s.Substring(0, i);
            s = s.Substring(i + 1);
        }
        i = s.IndexOf(":");
        if (i == -1)
            ore = "0";
        else ore = s.Substring(0, i);
        s = s.Substring(i + 1);
        i = s.IndexOf(":");
        minuti = s.Substring(0, i);
        s.Substring(i + 1);
        return $"Mancano {giorni} giorni, {ore} ore {minuti} minuti.";
    }
}
