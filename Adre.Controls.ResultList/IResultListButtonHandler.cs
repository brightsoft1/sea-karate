using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Adre.Controls.ResultList
{
    public interface IResultListButtonHandler
    {
        void BtnReport_Click(object sender, RoutedEventArgs e);

        void LstAllMatchesReport_OnPreviewMouseDown(object sender, RoutedEventArgs e);

        void LstMatchReport_OnPreviewMouseDown(object sender, MouseButtonEventArgs e);
    }
}
