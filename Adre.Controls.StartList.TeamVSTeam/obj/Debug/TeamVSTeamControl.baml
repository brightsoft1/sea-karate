   M S B A M L   `   `   `  ����]  YAdre.Controls.StartList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Adre.Controls.StartList.TeamVSTeam"Adre.Controls.StartList.TeamVSTeam  5      :    4Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Blocal0clr-namespace:Adre.Controls.StartList.TeamVSTeam     5      a ]Telerik.Windows.Data, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2017.1.213.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 5      .��5      � $��10q�5   	     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��5      $��
0, 0, 0, 5q�5      $��Right=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� -   5        $��0,0,5,0q�5      $
��15,5q�5      $��Center=�5      .��5   #   	Refresh5       �� 5!      -   5        $��0,0,5,0q�5"      $
��15,5q�5#      $��Center=�5$      .��5%   %   Save5'      �� 5(      -   5        $��0,0,5,0q�5)      $
��15,5q�5*      $��Center=�5+      .��5,   $   Add5.      �� 5/      -   5        $��0,0,5,0q�50      $
��15,5q�51      .��52   ,   Delete54      �� 55      -   5        $��0,0,5,0q�56      $
��15,5q�57      {�58   ,   �� *ButtonDetailReportEnabled+.��6\   Detail Report5:      �� 5;      -   5        $��0,0,0,0q�5<      $
��15,5q�5=      {�5>   +   �� *ButtonDetailReportEnabled+.��6[   Event Report5@      5A      *  $Telerik.Windows.Controls.RadGridView  5C   
   $��1��6   $��14(�6+   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     CanUserInsertRows .     CanUserDeleteRows .  *  $Telerik.Windows.Controls.DataControl   SelectedItem 5D      �� *SelectedItem+   ItemsSource 6D   �� *Items+   Columns 5F      1  +Telerik.Windows.Controls.GridViewDataColumn  5G      -  'Telerik.Windows.Controls.GridViewColumn   
IsReadOnly . 6  0Telerik.Windows.Controls.GridViewBoundColumnBase	   Header$	 No��6?   
   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
 50 6K      TextAlignment$ Right=�6w      DataMemberBinding 6V   �� *No+6w     5H       . $	 Event��6?   $	
 150 6N    6Z   �� *SelectedEvent.Name+  5I       . $	 Gender��6?   $	
 150 6O    6[   �� *SelectedEvent.Gender+  5J       . $	 Series��6?   $	
 120 6O    6[   �� *SelectedPhase.Name+  5K       . $	 Group��6?      HeaderTextAlignment$ Center=�6N   $
 80 6k   $ Center=�6�    6v   �� *SelectedMatchGroup.Name+6�     5L       . $	 Arena��6?   $
 80 6N   $ Center=�6}    6Y   �� *Arena+6}     5M       . $	 Date Time Start��6?   $	
 150 6X    6d   �� *DateTimeStart+ �� StringFormat$ {0:dd/MM/yy hh:mm tt}��  5N       . $		 Red��6?   $ Center=�6L      MinWidth$	 150Q�6j   $ Center=�6�    6y   �� *ContingentA+6�     5O       . $
 50 6;      CellTemplate 5P      �� 5Q      .R�5R      �� $��Center=�6$   $��Center=�6A   $
��Bold"�6\   .��6n   VS6r   5S      5U        5V       . $
	 Blue��6?   $ Center=�6M   $	 150Q�6j   $ Center=�6�    6y   �� *ContingentB+6�     5W       .    Header$ Remarks��6;    5X      �� 5Y      .R�5Z      �� $
��Left=�6(   $	��Top=�6C   $
��Wrap=�6[   $	��300��6o   ��6{   �� *	Remarks+5[      5]      5_      �� 5`   
   
�������$��2��6/   $
��Auto=�6^   y�6<   �� *
ShowEditor+.��5a      /   )Adre.Controls.StartList.TeamVSTeam.Editor  $��0,5,0,0q�6    � DataContext 6,   �� *SelectedItem+5b      5c      5d      