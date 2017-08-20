using System.Windows;
using System.Windows.Input;

namespace Adre.Controls.StartList
{
    public interface IStartListButtonHandler
    {
        void OnAddClick(object sender, RoutedEventArgs e);

        void ButtonDeleteClick(object sender, RoutedEventArgs e);

        void BtnReport_Click(object sender, RoutedEventArgs e);

        void LstAllMatchesReport_OnPreviewMouseDown(object sender, RoutedEventArgs e);

        void LstMatchReport_OnPreviewMouseDown(object sender, MouseButtonEventArgs e);
    }
}
