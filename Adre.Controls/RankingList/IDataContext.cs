using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adre.Controls.RankingList
{
    public interface IDataContext
    {
        ObservableCollection<IItemViewModel> Items { get; set; }

        IItemViewModel Create();
        void Clear();

        void Add(IItemViewModel item);

        void Sort();

        void Ranking();

        void NotifyChanged();

        void Recount();
    }
}
