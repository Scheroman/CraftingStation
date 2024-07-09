using System.Collections.ObjectModel;

namespace CraftingStation.Components.Grid.Data
{
    public class GridCollection<T> : ObservableCollection<T>
    {
        private Func<T, object> selector;

        public GridCollection(Func<T, object> selector)
        {
            this.selector = selector;
        }


        public void UpdateElement(T element)
        {
            
           var found = this.FirstOrDefault(e => selector(e).Equals(selector(element)));
            if (found != null)
            {
                int i = this.IndexOf(found);
                this[i] = element;
                
            }
        }

    }
}
