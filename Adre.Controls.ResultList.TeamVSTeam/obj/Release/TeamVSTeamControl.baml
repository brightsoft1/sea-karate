   M S B A M L   `   `   `  ���� ^  ZAdre.Controls.ResultList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Adre.Controls.ResultList.TeamVSTeam#Adre.Controls.ResultList.TeamVSTeam  ;    5Adre.Controls.ResultList.TeamVSTeam.TeamVSTeamControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Clocal1clr-namespace:Adre.Controls.ResultList.TeamVSTeam     a ]Telerik.Windows.Data, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2017.1.213.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 .��� $��10q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��1.5* �.+��� $��0��$��
0, 0, 0, 5q�$��Right=� �� Orientation$ 
Horizontal=�.+��� -   $��Refresh��$��28��$��0,0,5,0q�$
��15,5q�$��Bottom=��� -   $
��Save��$��28��$��0,0,5,0q�$
��15,5q�$��Bottom=��� -   $��Chart Editor��$��28��$��0,0,5,0q�$
��15,5q�$��Bottom=�{��� *ButtonDetailReportEnabled+�� -   $��Chart Report��$��28��$��0,0,5,0q�$
��15,5q�$��Bottom=�{��� *ButtonDetailReportEnabled+�� -   $��Detail Report��$��28��$��0,0,5,0q�$
��15,5q�$��Bottom=�{��� *ButtonDetailReportEnabled+�� -   $��Event Report��$��28��$��0,0,0,0q�$
��15,5q�$��Bottom=�{��� *ButtonDetailReportEnabled+*  $Telerik.Windows.Controls.RadGridView  -   $��1��$��14(�;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .  *  $Telerik.Windows.Controls.DataControl   SelectedItem �� *SelectedItem+   ItemsSource �� *Items+   Columns 1  +Telerik.Windows.Controls.GridViewDataColumn  -  'Telerik.Windows.Controls.GridViewColumn   
IsReadOnly . 6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ No��   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 50 	   TextAlignment$	 Right=�
   DataMemberBinding
 �� *StartListItem.No+   . $ Event��$	 150 
 �� *" StartListItem.SelectedEvent.Name+   . $ Series��$	 120 
 �� *" StartListItem.SelectedPhase.Name+   . $ Group��$ 80 $	 Center=�
 �� *'%StartListItem.SelectedMatchGroup.Name+   . $ Arena��$ 80 $	 Center=�
 �� *StartListItem.Arena+   . $ Date Time Start��$	 150 
 �� *StartListItem.DateTimeStart+ �� StringFormat$ {0:dd/MM/yy hh:mm tt}��   . $ Date Time End��$	 150 
 �� *StartListItem.DateTimeEnd+$ {0:dd/MM/yy hh:mm tt}��   . $ Duration��$ 90    DataFormatString$ {0:hh\:mm\:ss}��$	 Center=�
 �� *
Duration+   . $ 
Contingent��   MinWidth$	 150Q�$	 Center=�
 �� *StartListItem.ContingentA+   . $ Score��$ 70 $	 Center=�
 �� *PointA+   . $ 50    CellTemplate �� .R��� $��Center=�$��Center=�$
��Bold"�.��VS   . $ Score��$ 70 $	 Center=�
 �� *PointB+   . $ 
Contingent��$	 150Q�$	 Center=�
 �� *StartListItem.ContingentB+�� 
�������$��2��.��0   *Adre.Controls.ResultList.TeamVSTeam.Editor  $��0,5,0,0q�
�������$��2�� � DataContext �� *SelectedItem+