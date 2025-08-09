using Microsoft.AspNetCore.Components;

namespace CraftingStation.Components.Search.Data.Actions
{
    public class MultiPageNavigationAction : ISearchAction
    {
        public string Path { get; set; }
        public Type Page { get; set; }

        public MultiPageNavigationAction(string path, Type page)
        {
            Path = path;
            Page = page;
        }

        public void Execute(NavigationManager manager)
        {
            manager.NavigateTo(Path);
            //AgrisBaseMultiPage.MultiPage?.GoToPage(Page);
        }
    }
}
