   M S B A M L   `   `   `  ����]  YAdre.Controls.StartList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�\clr-namespace:Adre.Controls.StartList.TeamVSTeam;assembly=Adre.Controls.StartList.TeamVSTeam"Adre.Controls.StartList.TeamVSTeam  5   	   ^ ZAdre.Controls.ResultList.TeamVSTeam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:Adre.Controls.ResultList.TeamVSTeam;assembly=Adre.Controls.ResultList.TeamVSTeam#Adre.Controls.ResultList.TeamVSTeam 5   	   J FAdre.SEA.Karate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Adre.SEA.KarateAdre.SEA.Karate 5   	   T PAdre.Controls.RankingList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullhJclr-namespace:Adre.Controls.RankingList;assembly=Adre.Controls.RankingListAdre.Controls.RankingList 5	   	   L HAdre.SEA.Importer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Adre.SEA.Importer;assembly=Adre.SEA.ImporterAdre.SEA.Importer 5
   	   P LAdre.Controls.Bracket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:Adre.Controls.Bracket;assembly=Adre.Controls.BracketAdre.Controls.Bracket 5   	       Adre.SEA.Karate.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 5   	   @d2http://schemas.microsoft.com/expression/blend/2008    	 5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	 5   	   ksl\clr-namespace:Adre.Controls.StartList.TeamVSTeam;assembly=Adre.Controls.StartList.TeamVSTeam    	 5   	   mrl^clr-namespace:Adre.Controls.ResultList.TeamVSTeam;assembly=Adre.Controls.ResultList.TeamVSTeam    	 5   	   /localclr-namespace:Adre.SEA.Karate    	 5   	   _rankListJclr-namespace:Adre.Controls.RankingList;assembly=Adre.Controls.RankingList    	 5	   	   Oimporter:clr-namespace:Adre.SEA.Importer;assembly=Adre.SEA.Importer    	 5
   	   VbracketBclr-namespace:Adre.Controls.Bracket;assembly=Adre.Controls.Bracket    	 5   	     � WindowState$  	Maximized=�5   	    � WindowStartupLocation$ CenterOwner=�6!    � Title$ Karate��5   	   $	��720��6   $
��1280��6%    J� InputBindings 5      �� 5   
    �� Gesture$ Ctrl+R��6    �� Command 6&   �� *RefreshCommand+�� 5   
   
 �� Key$ F5��6    6   �� *RefreshCommand+ � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%H  '��       '�� �     '�� �    �� 5   
   " ��6   .�5      �� 	 � ��$
 14(�6)   �� 5      	 � ��$
 5q�6'   �� 5      	 � ��$

 Bold"�6+   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 5q�6'   �� 5      	 � ��$	
 200��6&   �� 5      	 � ��$
 Normal"�6+   �� 5      	 � ��$

 Left=�64   �� 5      	 � ��$
 Center=�69   �� 5      	 � ��$
 14(�6)   5       �� 5!   
   " ��6   .�5"      �� 	 � ��$
 5q�6'   �� 5#      	 � ��$
 14(�6)   �� 5$      	 � ��$
 Center=�69   5%      5&      .��5'      � 
����d�.+�5(   
   ��  �� TabStripPlacement$
 Left=�6   .@�5)      �� $��	Startlist��6   $	��100��6)   $��40��65   $��0,-2,0,2q�6A   .��5*      :   4Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl  -   5        5*   �   5+      �� 5,      $��Results��6   $	��100��6(   $��40��64   $��0,-2,0,2q�6@   .��5-      ;  5Adre.Controls.ResultList.TeamVSTeam.TeamVSTeamControl  -   5        5-   �   5.      �� 5/      $��Ranking��6   $	��100��6(   $��40��64   $��0,-2,0,2q�6@   .��50      2  ,Adre.Controls.RankingList.RankingListControl  -   5        50   _   51      �� 52      $��Import��6   $	��100��6&   $��40��62   $��0,-2,0,2q�6>   .��53      #  Adre.SEA.Importer.MainControl  -   5        53   Q   54      55      �� 56   
   $��1��6   .@�57      �� $��Right=�6   .��58      ��  �� Orientation$ 
Horizontal=�6   .+�59      �� $��5,0,5,0q�68   ��6    �� *Status+68   � 5:      $	��250��6"   $��10��6.   $��5,0,5,0q�6t    � Value 6:   �� *Value+y�6R   �� *
Visibility+6t   �� 5;      �� 5<      $��5,0,5,0q�66   ��6    �� *Time+66   5=      5>      5?      5@      5A      