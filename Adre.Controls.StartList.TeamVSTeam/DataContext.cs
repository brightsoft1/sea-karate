using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using System.Windows;

namespace Adre.Controls.StartList.TeamVSTeam
{
    class DataContext: BindableBase, IDataContext
    {
        ICollection<IItemViewModel> _items;

        IItemViewModel _selectedItem;

        string _showEditor;

        private bool _buttonDetailReportEnabled = false;

        public DataContext()
        {
            _items = new ObservableCollection<IItemViewModel>();
            ShowEditor = Visibility.Collapsed.ToString();
        }

        public ItemViewModel NewItem()
        {
            var item = new ItemViewModel();
            item.Id = Guid.NewGuid();
            return item;
        }

        public ItemViewModel CreateAndAdd()
        {
            var item = NewItem();
            item.No = _items.Count + 1;
            Add(item);
            SelectedItem = item;
            return item;
        }

        public void Add(ItemViewModel item)
        {
            _items.Add(item);            
        }

        public void Remove(ItemViewModel item)
        {
            _items.Remove(item);
        }

        public ItemViewModel RemoveSelected()
        {
            if (_selectedItem != null)
            {
                var d = _selectedItem;
                Remove((ItemViewModel)_selectedItem);
                return (ItemViewModel)d;
            }

            return null;
        }

        IItemViewModel IDataContext.NewItem()
        {
            return this.NewItem();
        }

        public void Clear()
        {
            _items.Clear();
            Items = _items;
        }

        public ICollection<IItemViewModel> Items
        {
            get => _items;
            set { SetProperty(ref _items, value); }
        }

        public IItemViewModel SelectedItem
        {
            get => _selectedItem;
            set {
                ShowEditor = (value != null) ?  Visibility.Visible.ToString() : Visibility.Collapsed.ToString();
                ButtonDetailReportEnabled = value != null;
                SetProperty(ref _selectedItem, value);
            }
        }

        public string ShowEditor
        {
            get => _showEditor;
            set { SetProperty(ref _showEditor, value);  }
        }

        public bool ButtonDetailReportEnabled
        {
            get => _buttonDetailReportEnabled;
            set => SetProperty(ref _buttonDetailReportEnabled, value);
        }
    }
}
