using Dunca_Tarau_App.Models;

namespace Dunca_Tarau_App;

public partial class CountryEntryPage : ContentPage
{
	public CountryEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCountriesAsync();
    }
    async void OnCountryAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CountryPage
        {
            BindingContext = new Country()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CountryPage
            {
                BindingContext = e.SelectedItem as Country
            });
        }
    }

}