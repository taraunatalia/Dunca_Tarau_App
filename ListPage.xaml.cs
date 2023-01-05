using Dunca_Tarau_App.Models;

namespace Dunca_Tarau_App;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (TourList)BindingContext;
        slist.StartingTourDate = DateTime.UtcNow;
        await App.Database.SaveTourListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (TourList)BindingContext;
        await App.Database.DeleteTourListAsync(slist);
        await Navigation.PopAsync();
    }


}