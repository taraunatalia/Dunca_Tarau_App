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
        slist.Date = DateTime.UtcNow;

        Country selectedCountry = (CountryPicker.SelectedItem as Country);
        // slist.CountryID = selectedCountry.ID;


        TourCategory selectedShop = (TourCategoryPicker.SelectedItem as TourCategory);
        //slist.TourCategoryID = selectedTourCategory.ID;

        await App.Database.SaveTourListAsync(slist);
        await Navigation.PopAsync();
        
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (TourList)BindingContext;
        await App.Database.DeleteTourListAsync(slist);
        await Navigation.PopAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();


        var items = await App.Database.GetCountriesAsync();
        
        CountryPicker.ItemsSource = items;
        CountryPicker.ItemDisplayBinding = new Binding("CountryName");

        var tems = await App.Database.GetTourCategoriesAsync();
        
        TourCategoryPicker.ItemsSource = tems;
        TourCategoryPicker.ItemDisplayBinding = new Binding("TourCategoryName");

        /*var shopl = (TourList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);*/
    }

}