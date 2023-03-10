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
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TourList.db3");

                database = new TourListDatabase(path); 
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
