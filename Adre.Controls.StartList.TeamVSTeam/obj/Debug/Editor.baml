   M S B A M L   `   `   `  ����]  YAdre.Controls.StartList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Adre.Controls.StartList.TeamVSTeam"Adre.Controls.StartList.TeamVSTeam  5      /    )Adre.Controls.StartList.TeamVSTeam.Editor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:Adre.Controls.StartList.TeamVSTeam     5      a ]Telerik.Windows.Data, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Documents.Core, Version=2017.1.213.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.1.222.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 5      .��5      � $��10q�6     � ColumnDefinitions  5   
   �� 5      $	��150 �6   �� 5      �� 5      $	��150 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   .��6-   Gender65   �� 5   
   $��1��6   $��0��6   .��6-   Event64   �� 5   
   $��2��6   $��0��6   .��6-   Series65   �� 5    
   $��3��6   $��0��6   .��6-   Start Date & Time6D   �� 5!   
   $��4��6   $��0��6   .��6-   Group64   �� 5"   
   $��5��6   $��0��6   .��6-   Contingent A6;   �� 5#   
   $��6��6   $��0��6   .��6-   
Athletes67   �� 5%   
   $��0��6   $��2��6   .��6-   	Match No.68   �� 5&   
   $��1��6   $��2��6   .��6-   Venue64   �� 5'   
   $��2��6   $��2��6   .��6-   Arena64   �� 5(   
   $��3��6   $��2��6   .��6.   	Remarks67   �� 5)   
   $��5��6   $��2��6   .��6-   Contingent B6;   �� 5*   
   $��6��6   $��2��6   .��6-   
Athletes67   �� 5,   
   $��0��6   $��1��6    ��60   �� *
GenderList+ �� SelectedItem 6S   �� *SelectedGender+6}   �� 5-   
   $��1��6   $��1��6    ��60   �� *	EventList+ 6R   �� *SelectedEvent+6{   �� 5.   
   $��2��6   $��1��6    ��60   �� *	PhaseList+ 6R   �� *SelectedPhase+6{   0  *Telerik.Windows.Controls.RadDateTimePicker  5/   
   $��3��6$   $��1��61   $	��200��6i   $	��5,0q�6u   $��14(�6�   $��30��6�   $
��Left=�6�   $	��Top=�6�      SelectedValue 6A   �� *DateTimeStart+6�   �� 50   
   $��4��6   $��1��6    $��50��6W    �� SelectedIndex$ 1��6b    �� DisplayMemberPath$
 Name��6�   $��30��6�   $	��Top=�6�   $
��Left=�6�   ��60   �� *MatchGroupList+ 6t   �� *SelectedMatchGroup+6�   �� 51   
   $��5��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�52      �� ��6   �� *ContingentList+ 6>   �� *SelectedContingentA+�� 53      $��50��6a   $ 0��6l   ��6   �� *	GroupList+ 69   �� *SelectedGroupA+6l   54      �� 55   
   $��6��6   $��1��6"   $ 
Horizontal=�62   .+�56      �� -   5        $��5q�56      $	��200��6#   $��30��62   $
��Left=�6A   $��14(�6\   $	��150��6j   ��6w   �� *AthleteListA+57      �� 58      -   5        
����ح�$��5q�58   .   $	��200��69   $��30��6H   $
��Left=�6W   $	��150��6r   $��14(�6   ��6�   �� *SelectedAthleteA+6�   59      �� 5;   
   $��0��6   $��3��6   $
��Left=�6C   $	��100��6^   ��6/   �� *No+6l   �� 5<   
   $��1��6   $��3��6   $	��400��6F   $
��Left=�6R   ��6/   �� *Venue+6o   �� 5=   
   $��2��6   $��3��6   $
��Left=�6F   $	��100��6a   ��6/   �� *Arena+6o   �� 5>   
   $��3��6   $��3��6   $	��400��6/   $
��Left=�6T    �� MaxLines$ 3��5?      $��2��6&   $	��100��5@       �� TextWrapping$
 Wrap=�5A      $	��Top=�5B      	 �� AcceptsReturn	 . ��5>   ;   �� *	Remarks+5C   0   �� 5D   
   $��5��6   $��3��6"   $ 
Horizontal=�63   .+�5E      �� ��6   �� *ContingentList+ 6>   �� *SelectedContingentB+�� 5F      $��50��6a   $ 0��6l   ��6   �� *	GroupList+ 69   �� *SelectedGroupB+6l   5G      �� 5H   
   $��6��6   $��3��6"   $ 
Horizontal=�62   .+�5I      �� -   5        $��5q�5I      $	��200��6#   $��50��62   $
��Left=�6A   $��14(�6\   $	��150��6j   ��6w   �� *AthleteListB+6�   �� 5J      -   5        
����ح�$��5q�5J   /   $	��200��6:   $��50��6I   $
��Left=�6X   $��14(�6s   $	��150��6�   ��6�   �� *SelectedAthleteB+6�   5K      5L      5M      