using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Views.InputMethods;
using AndroidX.AppCompat.Widget;
using SearchBarApp.Components;
using SearchBarApp.Droid;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace SearchBarApp.Droid
{

    public class SearchPageRenderer : PageRenderer
    {
        public SearchPageRenderer(Context context) : base(context) { }


        public void OnSearchPlaceholder(string text)
        {
            if (GetToolbar() is Toolbar toolBar)
            { 
                if (toolBar.Menu?.FindItem(Resource.Id.ActionSearch)?.ActionView?.JavaCast<SearchView>() is SearchView searchView)
                {
                    searchView.QueryHint = text;
                }
            }
        }

        // Add the Searchbar once Xamarin.Forms creates the Page
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is ISearchPage && e.NewElement is Page page && page.Parent is NavigationPage navigationPage && navigationPage.CurrentPage is ISearchPage)
                AddSearchToToolbar((ISearchPage)navigationPage.CurrentPage, navigationPage.CurrentPage.Title);

            if (e.NewElement != null)
            {
                var searchPage = (SearchPage)e.NewElement;
                searchPage.OnPlaceHolderChanged += OnSearchPlaceholder;
            }

            if (e.OldElement != null)
            {
                var searchPage = (SearchPage)e.OldElement;
                searchPage.OnPlaceHolderChanged -= OnSearchPlaceholder;
            }
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            if (Element is ISearchPage && Element is Page page && page.Parent is NavigationPage navigationPage)
            {
                //Workaround to re-add the SearchView when navigating back to an ISearchPage, because Xamarin.Forms automatically removes it
                navigationPage.Popped += HandleNavigationPagePopped;
                navigationPage.PoppedToRoot += HandleNavigationPagePopped;
            }
        }

        // Adding the SearchBar in OnSizeChanged ensures the SearchBar is re-added after the device is rotated, because Xamarin.Forms automatically removes it
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            if (Element is ISearchPage && Element is Page page && page.Parent is NavigationPage navigationPage && navigationPage.CurrentPage is ISearchPage)
            {
                AddSearchToToolbar((ISearchPage)navigationPage.CurrentPage, navigationPage.CurrentPage.Title);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (GetToolbar() is Toolbar toolBar)
                toolBar.Menu?.RemoveItem(Resource.Menu.MainMenu);

            base.Dispose(disposing);
        }

        // Workaround to re-add the SearchView when navigating back to an ISearchPage, because Xamarin.Forms automatically removes it
        void HandleNavigationPagePopped(object sender, NavigationEventArgs e)
        {
            if (sender is NavigationPage navigationPage && navigationPage.CurrentPage is ISearchPage)
            {
                AddSearchToToolbar((ISearchPage)navigationPage.CurrentPage, navigationPage.CurrentPage.Title);
            }
        }

        void AddSearchToToolbar(ISearchPage page, string pageTitle)
        {
            if (GetToolbar() is Toolbar toolBar && toolBar.Menu?.FindItem(Resource.Id.ActionSearch)?.ActionView?.JavaCast<SearchView>().GetType() != typeof(SearchView))
            {
                toolBar.Title = pageTitle;
                toolBar.InflateMenu(Resource.Menu.MainMenu);

                if (toolBar.Menu?.FindItem(Resource.Id.ActionSearch)?.ActionView?.JavaCast<SearchView>() is SearchView searchView)
                {
                    var adapter = new Android.Widget.ArrayAdapter<String>(Context, Resource.Layout.list_item, page.Suggestions);

                    searchView.SubmitButtonEnabled = true;
                    searchView.SetIconifiedByDefault(false);

                    searchView.QueryTextSubmit += HandleQueryTextSubmit;
                    searchView.SuggestionClick += HandleSuggestionClick;

                    searchView.QueryHint = page.PlaceHolder;
                    searchView.ImeOptions = (int)ImeAction.Search;
                    searchView.InputType = (int)InputTypes.TextVariationFilter;
                    searchView.MaxWidth = int.MaxValue; //Set to full width - http://stackoverflow.com/questions/31456102/searchview-doesnt-expand-full-width

                    // https://android.googlesource.com/platform/frameworks/base/+/refs/heads/master/core/java/android/widget/SearchView.java
                    //var mSearchEditFrame = searchView.FindViewById(Resource.Id.search_edit_frame);
                    //var mSearchPlate = searchView.FindViewById(Resource.Id.search_plate);
                    //var mSubmitArea = searchView.FindViewById(Resource.Id.submit_area);
                    //var mSearchButton = (Android.Widget.ImageView)searchView.FindViewById(Resource.Id.search_button);
                    //var mGoButton = (Android.Widget.ImageView)searchView.FindViewById(Resource.Id.search_go_btn);
                    //var mCloseButton = (Android.Widget.ImageView)searchView.FindViewById (Resource.Id.search_close_btn);
                    //var mCollapsedIcon = (Android.Widget.ImageView)searchView.FindViewById(Resource.Id.search_mag_icon);

                    var mAutoCompleteText = (AppCompatAutoCompleteTextView)searchView.FindViewById(Resource.Id.search_src_text);
                    mAutoCompleteText.Adapter = adapter;
                    mAutoCompleteText.Threshold = 1; //will start working from first character
                }
            }
        }

        private void HandleSuggestionClick(object sender, SearchView.SuggestionClickEventArgs e)
        {
            if (Element is ISearchPage searchPage)
            {

                SearchView searchView = (sender as SearchView);
                AppCompatAutoCompleteTextView autoComplete = (AppCompatAutoCompleteTextView)searchView.FindViewById(Resource.Id.search_src_text);

                var selectedItem = autoComplete.Adapter.GetItem(e.Position);
                searchPage.SearchTextEvent((string)selectedItem);
            }
        }

        void HandleQueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            if (Element is ISearchPage searchPage)
                searchPage.SearchTextEvent(e.NewText);
        }

        Toolbar GetToolbar() => Xamarin.Essentials.Platform.CurrentActivity.FindViewById<Toolbar>(Resource.Id.toolbar);
    }
}