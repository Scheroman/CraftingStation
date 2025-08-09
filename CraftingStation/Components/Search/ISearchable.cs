

using CraftingStation.Components.Search.Data.Actions;

namespace CraftingStation.Components.Search.Data
{
    public interface ISearchable
    {
        static abstract List<SearchContext> SearchContext();

    }

    public class SearchContext
    {
        public string Name { get; set; }
        public ISearchAction Action { get; set; }

        public SearchContext(string name, ISearchAction action)
        {
            Name = name;
            Action = action;
        }
    }

}
