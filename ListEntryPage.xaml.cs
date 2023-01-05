using Dunca_Tarau_App.Models;

namespace Dunca_Tarau_App;

public partial class ListEntryPage : ContentPage
{
    private object listView;

    public ListEntryPage()
	{
		InitializeComponent();
	}

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTourListsAsync();
    }
    async void OnTourListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new TourList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as TourList
            });
        }
    }
}