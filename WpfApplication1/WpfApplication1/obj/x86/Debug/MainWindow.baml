   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5       NewLife    WpfApplication1.MainWindow   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  5      ccontrolsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5      :d2http://schemas.microsoft.com/expression/blend/2008  5   1   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6n     � Title$  First landing page��6   .��5      � $	��818��6   $	��Top=�6   
�������$��Center=�6G   $	��968��6d   .+�5   
   � -   5        $��Grid1��5   M   $��74��6   $��Center=�6   $��
209,12,0,0q�69   $	��Top=�6Z   $	��550��6r   
������� � ColumnDefinitions 5	      �� 5
      $	��37* �6#   �� 5      $
��513* �6#   .+�5      �� -   5        $��Label1��5   _   $��Patient��6   $��28��6&   $
��Left=�62   $��6,22,0,0q�6M   $	��Top=�6m   ���	#FFA9C7A9$��2��6�   �� 5      -   5        $��Button1��5   ]   $��Go��6   $��23��6"   $
��Left=�6.   $��
148,27,0,0q�6I   $	��Top=�6l   $��40��6�   $��1��6�      MetroButton#��[  6�   �� 5      -   5        $��Button2��5   f   $��New Patient��6   $��23��6+   $
��Left=�67   $��
194,27,0,0q�6R   $	��Top=�6u   $��88��6�   $��1��6�   #��[  6�   �� 5      -   5        $��Button3��5   g   $��New Medicine��6   $��23��6,   $
��Left=�68   $��
288,27,0,0q�6S   $	��Top=�6v   $��88��6�   $��1��6�   #��[  6�   -   'System.Windows.Controls.AutoCompleteBox  5      -   5          Name$ autotextbox��5   '   $��1��6<      MaxDropDownHeight$	 300Q�6L      
FilterMode$ Contains=�5   "      IsTextCompletionEnabled .  $��22,27,371,24q�6Y      ValueMemberPath$ patientName��6o      Text 6�   ��  �� Path$ 	patientId�	   ItemTemplate	 5      �� 5      .R�5      �� .+�5      �� ��6(   �� $ patientName�5      5      5      5      � 5   
   -   5        $��Grid2��5   L   $	��621��6   $��Center=�6   $��	12,92,2,0q�69   $	��Top=�6Y   $	��954��6q   6   �� 5!   
   -   5        $��TabControl1��5!   P   $	��621��6   $
��Left=�6"   $��	12,92,0,0q�6=   $	��Top=�6c   $	��951��6{   
�������.@�5"      �� -	   5        $��TabItem1��5"   '   $��Details��6   69   �� 5#      -
   5        $��TabItem2��5#   +   $��Last Visits��6   6=   �� 5$      -   5        $��TabItem3��5$   ,   $��Prescription��6   6>   5%      5'      
 � 	Resources
 5(        TabItemBackground �� Color  TabItemSelectedBackground �� 
StartPoint �� EndPoint � Color � Offset # TabControl_BackgroundColor_Base # TabControl_BackgroundBrush_Base   TabPage_InnerBorderBrushDark " TabPage_InnerBorderBrushBright $  TabItem_BackgroundBrush_Disabled $  TabItem_BackgroundBrush_Selected &	 "TabItem_BackgroundBrush_Unselected  
 TabItem_HoverBackgroundBrush   TabItem_TextBrush_Unselected  TabItem_TextBrush_Disabled  TabItem_TextBrush_Hover  TabItem_TextBrush_Selected  TabItem_DisabledBorderBrush   TabItem_BorderBrush_Selected  TabItem_Border_Unselected  TabItem_HoverBorderBrush  TabItemMargin_Base  TabItemMargin_Selected  TabItemMargin_Hover  TabItemPanel_Padding  BorderColor_Base��%�  &	       &	      &	     &	 '    7  &	 C    &	 j    &	 	    &	 +    7  7  &		     &	
     &	 �    &	     &	 +    &	 K    &	 m    &	 �    &	 �    &	 �    &	 �    &	     &	 :    &	 Z    &	 y    �� 5)   
   $
 Gray��64   �� 5+   
   $	 0,0&�6@   $	 0,1&�6Q   .��5,      � $ White��6   $ 0Q�6)   � 5-      $
 Gray��6   $	 0.3Q�6(   � 5.      $ Black��6   $	 0.7Q�6)   � 5/      $
 Gray��6   $ 1Q�6(   50      ��51   
   #EEF7FF��6A   �� 54   
   8   55      �� 58   
   $ 	#FF8DB2E3��59      �� 5:   
   $	 0,0&�5;      $	 1,1&�6-   ��5=      � $ 0Q�6   $ Transparent��6*   � 5>      $ 1Q�6   $ 	#FFC0F9FF��6*   5@      �� 5C   
   $
 #EEE��5D      �� 5E   
   $	 0,0&�5F      $	 0,1&�6-   ��5H      � $ 	#FFFFC14A��6   $	 0.1Q�61   � 5I      8   $
 0.15Q�5J      � 5K      $ #C5DBF6��6   $	 0.8Q�6/   � 5L      8  $	 1.0Q�5M      5O      �� 5P   
   $	 0,0&�5Q      $	 0,1&�6-   ��5S      � $ #E8F2FF��6   $	 0.0Q�6/   � 5T      $ #DFE9F6��6   $	 0.3Q�6/   � 5U      $ #C7D8EE��6   $	 0.7Q�6/   � 5V      $ #B9CADE��6   $	 1.0Q�6/   5X      �� 5Y   
   $ 0.5,1&�5Z      $ 0.5,0&�6-   .��5[      � $ 	#FFFFD5A0��6   $	 0.3Q�6-   � 5\      $ 	#FFFFA335��6   $
 0.51Q�6-   � 5]      $ 	#FFFFC14A��6   $
 0.98Q�6-   5^      �� 5a   
   $ #4971A3��6?   �� 5b   
   $
 #888��6=   �� 5c   
   $ Indigo��6:   �� 5d   
   $ DarkBlue��6=   �� 5g   
   $
 #CCC��6>   �� 5h   
   $ Black ��5i      �� 5j   
   $
 #AAA��5k      �� 5l   
   $ 
DarkOrange��5m      u�5r   
   0,8,-4,0q�69   u�5s   
   	-4,0,-4,0q�6>   u�5t   
   0,4,-4,0q�6:   u�5u   
   4,0,0,0q�6:   ��5w   
   #888��6/   5�      5�      