using System;
using System.ComponentModel;

namespace SearchBarApp
{
    public interface ISearchPage
    {
        string PlaceHolder { get; set; }
        string[] Suggestions { get; set; }
        void SearchTextEvent(string text);

        event EventHandler<string> OnSearchText;
    }
}
