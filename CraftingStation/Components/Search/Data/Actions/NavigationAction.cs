using Microsoft.AspNetCore.Components;

namespace CraftingStation.Components.Search.Data.Actions
{
    public class NavigationAction : ISearchAction
    {

        public string Path { get; set; }


        public NavigationAction(string path) { Path = path; }


        public void Execute(NavigationManager manager)
        {
            manager.NavigateTo(Path);
        }
    }
}
