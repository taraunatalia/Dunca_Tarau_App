using Dunca_Tarau_App.Models;

namespace Dunca_Tarau_App;

public partial class TourCategoryEntryPage : ContentPage
{
	public TourCategoryEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTourCategoriesAsync();
    }
    async void OnTourCategoryAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TourCategoryPage
        {
            BindingContext = new TourCategory()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TourCategoryPage
            {
                BindingContext = e.SelectedItem as TourCategory
            });
        }
    }
}