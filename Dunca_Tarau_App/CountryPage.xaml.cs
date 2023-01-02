using Dunca_Tarau_App.Models;
using Microsoft.Maui.Devices.Sensors;

namespace Dunca_Tarau_App;

public partial class CountryPage : ContentPage
{
	public CountryPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var country = (Country)BindingContext;
        await App.Database.SaveCountryAsync(country);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var country = (Country)BindingContext;
        var address = country.CountryName;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Tour-ul meu preferat" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }


    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Country)BindingContext;
        await App.Database.DeleteCountryAsync(slist);
        await Navigation.PopAsync();
    }

}