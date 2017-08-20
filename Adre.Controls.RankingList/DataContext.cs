using Prism.Mvvm;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Adre.Controls.RankingList
{
    class DataContext: BindableBase, IDataContext
    {

        ObservableCollection<IItemViewModel> _items;

        public ObservableCollection<IItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        ObservableCollection<IItemViewModel> IDataContext.Items { get => Items; set => Items = value; }

        public DataContext()
        {
            Items = new ObservableCollection<IItemViewModel>();
        }

        public IItemViewModel Create()
        {
            return new ItemViewModel();
        }

        public void Add(IItemViewModel item)
        {
            _items.Add((ItemViewModel)item);
        }

        public IItemViewModel CreateAndAdd()
        {
            var i = Create();
            _items.Add((ItemViewModel)i);

            Items = _items;

            return i;
        }

        public void NotifyChanged()
        {
            var items = _items.OrderByDescending(m => m.Point);
            var container = new Collection<IItemViewModel>();

            bool IsNumbered = items.Where(m => m.No > 0).Count() > 0 ? true : false;
            
            if (IsNumbered)
                items = items.OrderBy(m => m.No);
            else {
                int i = 1;
                foreach (var item in items)
                {
                    item.No = i++;
                    container.Add(item);
                }
                items = container.OrderBy(m => m.No);
            }
            
            Items = new ObservableCollection<IItemViewModel>(items.Distinct());
        }
        
        public void Sort()
        {
            Items = new ObservableCollection<IItemViewModel>(Items.OrderBy(m => m.Event.Name)
                .ThenBy(m => m.No)
                .ThenByDescending(m => m.Point));
        }

        public void Ranking()
        {
            var events = Items.Select(m => m.Event).Distinct();
            var container = new List<IItemViewModel>();

            foreach(var g in events)
            {
                if (Items.Any(m => m.Event.Id == g.Id && m.No == 0))
                    Ranking(ref container, g);
                else
                    container.AddRange(Items.Where(m => m.Event.Id == g.Id).OrderBy(m => m.No));
                
            }

            Items = new ObservableCollection<IItemViewModel>(container);
        }

        public void Ranking(ref List<IItemViewModel> container, IEvent e)
        {
            var contingents = Items.Where(m => m.Event.Id == e.Id)
                    .OrderByDescending(m => m.Point)
                    .ToList();
            var i = 1;
            foreach (var c in contingents)
            {
                c.No = i++;
                container.Add(c);
            }
        }

        public void Clear()
        {
            if (_items != null)
            {
                _items.Clear();
                Items = _items;
            }
        }

        public void Recount()
        {
            int i = 1;
            foreach (var item in Items.OrderByDescending(m => m.Point)) item.No = i++;
        }
    }
}
