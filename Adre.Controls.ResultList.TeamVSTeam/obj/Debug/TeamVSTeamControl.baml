   M S B A M L   `   `   `  ����^  ZAdre.Controls.ResultList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Adre.Controls.ResultList.TeamVSTeam#Adre.Controls.ResultList.TeamVSTeam  5      ;    5Adre.Controls.ResultList.TeamVSTeam.TeamVSTeamControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:Adre.Controls.ResultList.TeamVSTeam     5      a ]Telerik.Windows.Data, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2017.1.213.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 5      .��5
      � $��10q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��5      $��
0, 0, 0, 5q�5      $��Right=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� -   5        $��Refresh��5      $��28��6'   $��0,0,5,0q�5      $
��15,5q�5      $��Bottom=�5      5      �� 5      -   5        $
��Save��5      $��28��6$   $��0,0,5,0q�5      $
��15,5q�5      $��Bottom=�5      5      �� 5      -   5        $��Chart Editor��5      $��28��6,   $��0,0,5,0q�5       $
��15,5q�5!      $��Bottom=�5"      {�6J   �� *ButtonDetailReportEnabled+�� 5#      -   5        $��Chart Report��5#      $��28��6,   $��0,0,5,0q�5$      $
��15,5q�5%      $��Bottom=�5&      {�6J   �� *ButtonDetailReportEnabled+�� 5'      -   5        $��Detail Report��5'      $��28��6-   $��0,0,5,0q�5(      $
��15,5q�5)      $��Bottom=�5*      {�6K   �� *ButtonDetailReportEnabled+�� 5+      -   5        $��Event Report��5+      $��28��6,   $��0,0,0,0q�5,      $
��15,5q�5-      $��Bottom=�5.      {�6J   �� *ButtonDetailReportEnabled+5/      *  $Telerik.Windows.Controls.RadGridView  50   
   -   5        $��1��50      $��14(�6+   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .  *  $Telerik.Windows.Controls.DataControl   SelectedItem 51      �� *SelectedItem+   ItemsSource 6D   �� *Items+   Columns 52      1  +Telerik.Windows.Controls.GridViewDataColumn  53      -  'Telerik.Windows.Controls.GridViewColumn   
IsReadOnly . 6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ No��6?      Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 50 6K   	   TextAlignment$	 Right=�6�   
   DataMemberBinding
 6V   �� *StartListItem.No+6�     54       . $ Event��6?   $	 150 6N   
 6Z   �� *" StartListItem.SelectedEvent.Name+  55       . $ Gender��6?   $	 150 6O   
 6[   �� *$"StartListItem.SelectedEvent.Gender+  56       . $ Series��6?   $	 120 6O   
 6[   �� *" StartListItem.SelectedPhase.Name+  57       . $ Group��6?   $ 80 6N      HeaderTextAlignment$ Center=�6Y   $	 Center=�6�   
 6v   �� *'%StartListItem.SelectedMatchGroup.Name+6�     58       . $ Arena��6?   $ 80 6N   $	 Center=�6�   
 6Y   �� *StartListItem.Arena+6�     59       . $ Date Time Start��6?   $	 150 6X   
 6d   �� *StartListItem.DateTimeStart+ �� StringFormat$ {0:dd/MM/yy hh:mm tt}��  5:       . $ Date Time End��6?   $	 150 6V   
 6b   �� *StartListItem.DateTimeEnd+$ {0:dd/MM/yy hh:mm tt}��  5;       . $ Duration��6?   $ 90 6Q      DataFormatString$ {0:hh\:mm\:ss}��6�   $	 Center=�6�   
 6\   �� *
Duration+6�     5<       . $	 Red��6?   $ Center=�6L      MinWidth$	 150Q�6i   $	 Center=�6�   
 6x   �� *StartListItem.ContingentA+6�     5=       . $ 50 6?      CellTemplate 5>      �� 5?      .R�5@      �� $��Center=�6$   $��Center=�6A   $
��Bold"�6\   .��6n   VS6r   5A      5C        5D       . $
 Blue��6?   $ Center=�6N   $	 150Q�6k   $	 Center=�6�   
 6z   �� *StartListItem.ContingentB+6�     5E       . $ Remarks��6?   $	 150Q�6P   $	 Center=�6�   
 6_   �� *	Remarks+6�   5G      �� 5H   
   
�������$��2��6/   .��5I      0   *Adre.Controls.ResultList.TeamVSTeam.Editor  $��0,5,0,0q�6   
�������$��2��6D    � DataContext 6Q   �� *SelectedItem+5J      5K      5L      