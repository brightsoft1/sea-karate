   M S B A M L   `   `   `  ����^  ZAdre.Controls.ResultList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Adre.Controls.ResultList.TeamVSTeam#Adre.Controls.ResultList.TeamVSTeam  5      0    *Adre.Controls.ResultList.TeamVSTeam.Editor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:Adre.Controls.ResultList.TeamVSTeam     5      a ]Telerik.Windows.Data, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2017.1.213.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $	��150 �6   �� 5      $	��300 �6   �� 5      $	��150 �6   �� 5      $	��200 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   .��6-   Event64   �� 5   
   $��1��6   $��0��6   .��6-   Series65   �� 5   
   $��2��6   $��0��6   .��6-   Date & Time Start6D   �� 5   
   $��3��6   $��0��6   .��6-   Date & Time End6B   �� 5   
   $��4��6   $��0��6   .��6-   RED62   �� 5    
   $��5��6   $��0��6   .��6-   	Athlete66   �� 5"   
   $��0��6   $��2��6   .��6-   	Match No.68   �� 5#   
   $��1��6   $��2��6   .��6-   Venue64   �� 5$   
   $��2��6   $��2��6   .��6-   Arena64   �� 5%   
   $��3��6   $��2��6   .��6-   	Remarks66   �� 5&   
   $��4��6   $��2��6   .��6-   BLUE63   �� 5'   
   $��5��6   $��2��6   .��6-   	Athlete66   �� 5)   
   $��0��6   $��1��6!   $��5q�61   $
��Left=�6<   $��14(�6W   $��Center=�6e   ��6�   �� *" StartListItem.SelectedEvent.Name+6�   �� 5*   
   $��1��6   $��1��6!   $��5q�61   $
��Left=�6<   $��14(�6W   $��Center=�6e   ��6�   �� *" StartListItem.SelectedPhase.Name+6�   �� 5+   
   $��2��6   $��1��6!   $��5q�61   $
��Left=�6<   $��Center=�6W   $��14(�6r   ��6�   �� *StartListItem.DateTimeStart+ �� StringFormat$ {0:dd/MM/yy hh:mm tt}��6�   0  *Telerik.Windows.Controls.RadDateTimePicker  5,   
   $��3��6$   $��1��61   $	��200��6�   $	��Top=�6�   $��14(�6�   $��5q�6�   $
��Left=�6�      SelectedValue 6A   �� *StartListItem.DateTimeEnd+   DisplayDateStart 6u   �� *StartListItem.DateTimeStart+6�   �� 5-   
   $��4��6   $��1��6!   $��5q�61   $
��Left=�6<   $��14(�6W   $��Center=�6e   ��6�   �� *ContingentA+6�   �� 5.   
   $��5��6   $��1��6!   $��5q�61   $
��Left=�6<   $��14(�6W   $	��Top=�6e   ��6}   �� *	AthletesA+6�   �� 50   
   $��0��6   $��3��6!   $��5q�61   $	��200��6<   $
��Left=�6H   $��Center=�6c   $��14(�6~   ��6�   �� *StartListItem.No+6�   �� 51   
   $��1��6   $��3��6!   $��5q�61   $	��200��6<   $
��Left=�6H   $��Center=�6c   $��14(�6~   ��6�   �� *StartListItem.Venue+6�   �� 52   
   $��2��6   $��3��6!   $��5q�61   $	��200��6<   $
��Left=�6H   $��14(�6c   $��Center=�6q   ��6�   �� *StartListItem.Arena+6�   �� 53   
   $��3��6   $��3��6!   $��5q�61   $	��400��6<   $
��Wrap=�6H   $
��Left=�6\   $��14(�6w   $	��Top=�6�   ��6�   �� *StartListItem.Remarks+6�   �� 54   
   $��4��6   $��3��6!   $��5q�61   $	��200��6<   $
��Left=�6H   $��14(�6c   $��Center=�6r   ��6�   �� *ContingentB+6�   �� 55   
   $��5��6   $��3��6!   $��5q�61   $	��200��6<   $
��Wrap=�6H   $
��Left=�6\   $��14(�6w   $��Center=�6�   ��6�   �� *	AthletesB+6�   �� 56   
   $��0��6   $��4��6   .��6-   Results Table6<   *  $Telerik.Windows.Controls.RadGridView  57   
   $��1��6   $��5��6+   $��4��6=   $��0,10,0,0q�6M   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   ShowGroupPanel .     AutoGenerateColumns .  8  2Telerik.Windows.Controls.GridView.BaseItemsControl   GroupRenderMode$
 Flat=�5:      $	��Top=�66      CanUserInsertRows .  	   CanUserDeleteRows	 . *  $Telerik.Windows.Controls.DataControl
   ItemsSource
 58      �� *Items+   Columns 5;      1  +Telerik.Windows.Controls.GridViewDataColumn  5<      6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$	 RED��6-   -  'Telerik.Windows.Controls.GridViewColumn   Width?	  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$	 150	 6:      HeaderTextAlignment$ Center=�6G      TextAlignment$ Center=�6d      DataMemberBinding 6{   �� *ScoreA+  5=      $ 50	 6-      CellTemplate 5>      �� 5?      .R�5@      �� .��6$   VS6(   5A      5C        5D      $
 BLUE��6-   $	 150	 6;   $ Center=�6G   $ Center=�6d    6{   �� *ScoreB+  5E      $ Remarks��6-   $	 300	 6>    6J   �� *	Remarks+5G      5H      5I      