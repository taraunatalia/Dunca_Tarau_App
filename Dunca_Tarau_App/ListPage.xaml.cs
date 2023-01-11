using Dunca_Tarau_App.Models;
using Dunca_Tarau_App.Data;


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



    async void OnEditButtonClicked(object sender, EventArgs e)
    {
        var slist = (TourList)BindingContext;
        slist.Date = DateTime.UtcNow;

        Country selectedCountry = (CountryPicker.SelectedItem as Country);


        TourCategory selectedShop = (TourCategoryPicker.SelectedItem as TourCategory);

        await App.Database.SaveTourListAsync(slist);
        await Navigation.PopAsync();
    }



    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ActivityPage((TourList)
       this.BindingContext)
        {
            BindingContext = new Activity()
        });

    }


    async void OnDeleteIteamButtonClicked(object sender, EventArgs e)
    {
        Activity activity;
        var tourList = (TourList)BindingContext;
        if (listView.SelectedItem != null)
        {
            activity = listView.SelectedItem as Activity;
            var listActivityAll = await App.Database.GetListActivities();
            var ListActivity = listActivityAll.FindAll(x => x.ActivityID == activity.ID & x.TourListID == tourList.ID);
            await App.Database.DeleteListActivityAsync(ListActivity.FirstOrDefault());
            await Navigation.PopAsync();
        }
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

        var tourl = (TourList)BindingContext;

        listView.ItemsSource = await App.Database.GetListActivitiesAsync(tourl.ID);
    }

}