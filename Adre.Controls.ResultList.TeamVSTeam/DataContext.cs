
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace Adre.Controls.ResultList.TeamVSTeam
{
    class DataContext : BindableBase, IDataContext
    {
        public event SelectedItemChangedHandler SelectedItemChanged;

        ICollection<IItemViewModel> _items;

        IItemViewModel _selectedItem;

        private bool _buttonDetailReportEnabled = false;

        public ICollection<IItemViewModel> Items { get => _items; set => SetProperty(ref _items, value); }

        public IItemViewModel SelectedItem {
            get => _selectedItem;
            set {
                SetProperty(ref _selectedItem, value);
                ButtonDetailReportEnabled = value != null;
                SelectedItemChanged?.Invoke(value);
            }
        }

        public bool ButtonDetailReportEnabled
        {
            get => _buttonDetailReportEnabled;
            set => SetProperty(ref _buttonDetailReportEnabled, value);
        }

        public DataContext() { _items = new ObservableCollection<IItemViewModel>(); }

        public ItemViewModel NewItem()
        {
            var item = new ItemViewModel();
            return item;
        }

        public ItemViewModel NewItem(StartList.IItemViewModel startListItem)
        {
            var item = NewItem();
            item.StartListItem = startListItem;
            return item;
        }

        public IItemViewModel CreateAndAdd()
        {
            var item = NewItem();
            _items.Add(item);
            return item;
        }

        public IItemViewModel CreateAndAdd(StartList.IItemViewModel startListItem)
        {
            var item = NewItem(startListItem);
            _items.Add(item);
            return item;
        }

        public void Remove(StartList.IItemViewModel startListItem)
        {
            var item = _items.Where(m => m.StartListItem == startListItem).First();
            _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
            Items = _items;
        }
    }
}
