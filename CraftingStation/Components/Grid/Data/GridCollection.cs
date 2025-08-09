using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CraftingStation.Components.Grid.Data
{
    public class GridCollection<T> : ObservableCollection<T>
    {
        private Func<T, object> selector;
        private bool _suppressNotification;

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

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification)
            {
                base.OnCollectionChanged(e);
            }
        }

        public void Update(IEnumerable<T> newItems)
        {
            _suppressNotification = true;

            foreach (var item in newItems)
            {
                if (!this.Contains(item))
                {
                    this.Add(item);
                }
            }

            _suppressNotification = false;

            // Notify that the collection has changed after all items have been added
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItems.ToList()));
        }

    }
}
