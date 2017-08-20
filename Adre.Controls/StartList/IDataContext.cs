using System;
using System.Collections.Generic;

namespace Adre.Controls.StartList
{
    public interface IDataContext
    {
        ICollection<IItemViewModel> Items { get; }

        IItemViewModel NewItem();

        void Clear();

        IItemViewModel SelectedItem { get; set; }
    }
}
