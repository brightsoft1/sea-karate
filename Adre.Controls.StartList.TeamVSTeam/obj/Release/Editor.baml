   M S B A M L   `   `   `  ���� ]  YAdre.Controls.StartList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Adre.Controls.StartList.TeamVSTeam"Adre.Controls.StartList.TeamVSTeam  /    )Adre.Controls.StartList.TeamVSTeam.Editor   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:Adre.Controls.StartList.TeamVSTeam     a ]Telerik.Windows.Data, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2017.1.213.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 .��� $��10q�  � ColumnDefinitions  �� $	��150 ��� �� $	��150 ���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��.��Event�� $��1��$��0��.��Series�� $��2��$��0��.��Start Date & Time�� $��3��$��0��.��Group�� $��4��$��0��.��Contingent A�� $��5��$��0��.��
Athletes�� $��0��$��2��.��	Match No.�� $��1��$��2��.��Venue�� $��2��$��2��.��Arena�� $��3��$��2��.��	Remarks�� $��4��$��2��.��Contingent B�� $��5��$��2��.��
Athletes�� $��0��$��1������ *	EventList+ �� SelectedItem �� *SelectedEvent+�� $��1��$��1������ *	PhaseList+ �� *SelectedPhase+0  *Telerik.Windows.Controls.RadDateTimePicker  $��2��$��1��$	��200��$
��Left=�$	��5,0q�$��14(�   SelectedValue �� *DateTimeStart+�� $��3��$��1��$��50�� �� SelectedIndex$ 1�� �� DisplayMemberPath$
 Name��$��35��$	��Top=����� *MatchGroupList+ �� *SelectedMatchGroup+�� $��4��$��1�� �� Orientation$ 
Horizontal=�.+��� ���� *ContingentList+ �� *SelectedContingentA+�� $��50��$ 0������ *	GroupList+ �� *SelectedGroupA+�� $��5��$��1��$ 
Horizontal=�.+��� -   $��5q�$	��200��$��30��$
��Left=�$��14(�$	��150������ *AthleteListA+�� -   
����ح�$��5q�$	��200��$��30��$
��Left=�$	��150��$��14(����� *SelectedAthleteA+�� $��0��$��3��$
��Left=�$	��100������ *No+�� $��1��$��3��$	��400��$
��Left=����� *Venue+�� $��2��$��3��$
��Left=�$	��100������ *Arena+�� $��3��$��3��$	��400��$
��Left=� �� MaxLines$ 3��$	��100�� �� TextWrapping$
 Wrap=�$	��Top=�	 �� AcceptsReturn	 . ���� *	Remarks+�� $��4��$��3��$ 
Horizontal=�.+��� ���� *ContingentList+ �� *SelectedContingentB+�� $��50��$ 0������ *	GroupList+ �� *SelectedGroupB+�� $��5��$��3��$ 
Horizontal=�.+��� -   $��5q�$	��200��$��50��$
��Left=�$��14(�$	��150������ *AthleteListB+�� -   
����ح�$��5q�$	��200��$��50��$
��Left=�$��14(�$	��150������ *SelectedAthleteB+