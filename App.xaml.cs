using System;
using Dunca_Tarau_App.Data;
using System.IO;
namespace Dunca_Tarau_App;

public partial class App : Application
{
    static TourListDatabase database;
    public static TourListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               TourListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "TourList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
