using Microsoft.AspNetCore.Components;

namespace CraftingStation.Components.Search.Data.Actions
{
    public interface ISearchAction
    {
        void Execute(NavigationManager manager);
    }
}
