   M S B A M L   `   `   `  ���� ]  YAdre.Controls.StartList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Adre.Controls.StartList.TeamVSTeam"Adre.Controls.StartList.TeamVSTeam  :    4Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Blocal0clr-namespace:Adre.Controls.StartList.TeamVSTeam     a ]Telerik.Windows.Data, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2017.1.213.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 .��� $��10q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��1.5* �.+��� $��0��$��
0, 0, 0, 5q�$��Right=� �� Orientation$ 
Horizontal=�.+��� -   $��0,0,5,0q�$
��15,5q�$��Center=�.��	Refresh�� -   $��0,0,5,0q�$
��15,5q�$��Center=�.��Save�� -   $��0,0,5,0q�$
��15,5q�$��Center=�.��Add�� -   $��0,0,5,0q�$
��15,5q�.��Delete�� -   $��0,0,5,0q�$
��15,5q�{��� *ButtonDetailReportEnabled+.��Detail Report�� -   $��0,0,0,0q�$
��15,5q�{��� *ButtonDetailReportEnabled+.��Event Report*  $Telerik.Windows.Controls.RadGridView  $��1��$��14(�;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     CanUserInsertRows .     CanUserDeleteRows .  *  $Telerik.Windows.Controls.DataControl   SelectedItem �� *SelectedItem+   ItemsSource �� *Items+   Columns 1  +Telerik.Windows.Controls.GridViewDataColumn  -  'Telerik.Windows.Controls.GridViewColumn   
IsReadOnly . 6  0Telerik.Windows.Controls.GridViewBoundColumnBase	   Header$	 No��
   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
 50    TextAlignment$ Right=�   DataMemberBinding �� *No+   . $	 Event��$	
 150  �� *SelectedEvent.Name+   . $	 Series��$	
 120  �� *SelectedPhase.Name+   . $	 Group��$
 80 $ Center=� �� *SelectedMatchGroup.Name+   . $	 Arena��$
 80 $ Center=� �� *Arena+   . $	 Date Time Start��$	
 150  �� *DateTimeStart+ �� StringFormat$ {0:dd/MM/yy hh:mm tt}��   . $	 
Contingent��   MinWidth$	 150Q�$ Center=� �� *ContingentA+   . $
 50    CellTemplate �� .R��� $��Center=�$��Center=�$
��Bold"�.��VS   . $	 
Contingent��$	 150Q�$ Center=� �� *ContingentB+   .    Header$ Remarks�� �� .R��� $
��Left=�$	��Top=�$
��Wrap=�$	��300������ *	Remarks+�� 
�������$��2��$
��Auto=�y��� *
ShowEditor+.��/   )Adre.Controls.StartList.TeamVSTeam.Editor  $��0,5,0,0q� � DataContext �� *SelectedItem+