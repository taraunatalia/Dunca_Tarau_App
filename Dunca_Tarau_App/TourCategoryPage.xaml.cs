using Dunca_Tarau_App.Models;

namespace Dunca_Tarau_App;

public partial class TourCategoryPage : ContentPage
{
	public TourCategoryPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tourCategory = (TourCategory)BindingContext;
        await App.Database.SaveTourCategoryAsync(tourCategory);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (TourCategory)BindingContext;
        await App.Database.DeleteTourCategoryAsync(slist);
        await Navigation.PopAsync();
    }

}