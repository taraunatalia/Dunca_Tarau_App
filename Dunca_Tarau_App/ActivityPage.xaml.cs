using Dunca_Tarau_App.Models;
using Dunca_Tarau_App.Data;

namespace Dunca_Tarau_App;

public partial class ActivityPage : ContentPage
{
    TourList tl;
    public ActivityPage(TourList tlist)
    {
        InitializeComponent();
        tl = tlist;
    }
    //Save
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var activity = (Activity)BindingContext;
        await App.Database.SaveActivityAsync(activity);
        listView.ItemsSource = await App.Database.GetActivitiesAsync();
    }
    //Delete
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var activity = (Activity)BindingContext;
        await App.Database.DeleteActivityAsync(activity);
        listView.ItemsSource = await App.Database.GetActivitiesAsync();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetActivitiesAsync();
    }


    //Add
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Activity a;
        if (listView.SelectedItem != null)
        {
            a = listView.SelectedItem as Activity;
            var la = new ListActivity()
            {
                TourListID = tl.ID,
                ActivityID = a.ID
            };
            await App.Database.SaveListActivityAsync(la);
            a.ListActivities = new List<ListActivity> { la };
            await Navigation.PopAsync();
        }


    }
}