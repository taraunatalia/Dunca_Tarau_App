using Dunca_Tarau_App.Models;

namespace Dunca_Tarau_App;

public partial class TourCategoryPage : ContentPage
{
    TourList tl;
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
    /*protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }




    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        TourCategory p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as TourCategory;
            var lp = new TourList()
            {
               
                TourCategoryID = p.ID
            };
            await App.Database.SaveTourListAsync(lp);
            p.TourCategory = new List<TourList> { lp };
            await Navigation.PopAsync();
        }


    }*/
}