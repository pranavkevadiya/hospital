   M S B A M L   `   `   `  ���� p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls   NewLife    WpfApplication1.MainWindow   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  ccontrolsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � Title$  First landing page��.��� $	��818��$	��Top=�
�������$��Center=�$	��968��.+�� -   $��Grid1��$��74��$��Center=�$��
209,12,0,0q�$	��Top=�$	��550��
������� � ColumnDefinitions �� $	��37* ��� $
��513* �.+��� -   $��Label1��$��Patient��$��28��$
��Left=�$��6,22,0,0q�$	��Top=����	#FFA9C7A9$��2���� -   $��Button1��$��Go��$��23��$
��Left=�$��
148,27,0,0q�$	��Top=�$��40��$��1��   MetroButton#��[  �� -   $��Button2��$��New Patient��$��23��$
��Left=�$��
194,27,0,0q�$	��Top=�$��88��$��1��#��[  �� -   $��Button3��$��New Medicine��$��23��$
��Left=�$��
288,27,0,0q�$	��Top=�$��88��$��1��#��[  -   'System.Windows.Controls.AutoCompleteBox  -     Name$ autotextbox��$��1��   MaxDropDownHeight$	 300Q�   
FilterMode$ Contains=�   IsTextCompletionEnabled .  $��22,27,371,24q�   ValueMemberPath$ patientName��   Text ��  �� Path$ 	patientId�	   ItemTemplate	 �� .R��� .+��� ���� $ patientName�� -   $��Grid2��$	��621��$��Center=�$��	12,92,2,0q�$	��Top=�$	��954���� -   $��TabControl1��$	��621��$
��Left=�$��	12,92,0,0q�$	��Top=�$	��951��
�������.@��� -	   $��TabItem1��$��Details���� -
   $��TabItem2��$��Last Visits���� -   $��TabItem3��$��Prescription��
 � 	Resources
   TabItemBackground �� Color  TabItemSelectedBackground �� 
StartPoint �� EndPoint � Color � Offset # TabControl_BackgroundColor_Base # TabControl_BackgroundBrush_Base   TabPage_InnerBorderBrushDark " TabPage_InnerBorderBrushBright $  TabItem_BackgroundBrush_Disabled $  TabItem_BackgroundBrush_Selected &	 "TabItem_BackgroundBrush_Unselected  
 TabItem_HoverBackgroundBrush   TabItem_TextBrush_Unselected  TabItem_TextBrush_Disabled  TabItem_TextBrush_Hover  TabItem_TextBrush_Selected  TabItem_DisabledBorderBrush   TabItem_BorderBrush_Selected  TabItem_Border_Unselected  TabItem_HoverBorderBrush  TabItemMargin_Base  TabItemMargin_Selected  TabItemMargin_Hover  TabItemPanel_Padding  BorderColor_Base��%�  &	       &	      &	 �     &	 �     7  &	 �     &	 �     &	     &	 +    7  7  &		 �    &	
 >    &	 �    &	 �    &	 �    &	 �    &	     &	     &	 (    &	 8    &	 N    &	 `    &	 s    &	 �    &	 �    �� $
 Gray���� $	 0,0&�$	 0,1&�.��� $ White��$ 0Q�� $
 Gray��$	 0.3Q�� $ Black��$	 0.7Q�� $
 Gray��$ 1Q���#EEF7FF���� 8   �� $ 	#FF8DB2E3���� $	 0,0&�$	 1,1&���� $ 0Q�$ Transparent��� $ 1Q�$ 	#FFC0F9FF���� $
 #EEE���� $	 0,0&�$	 0,1&���� $ 	#FFFFC14A��$	 0.1Q�� 8   $
 0.15Q�� $ #C5DBF6��$	 0.8Q�� 8  $	 1.0Q��� $	 0,0&�$	 0,1&���� $ #E8F2FF��$	 0.0Q�� $ #DFE9F6��$	 0.3Q�� $ #C7D8EE��$	 0.7Q�� $ #B9CADE��$	 1.0Q��� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFD5A0��$	 0.3Q�� $ 	#FFFFA335��$
 0.51Q�� $ 	#FFFFC14A��$
 0.98Q��� $ #4971A3���� $
 #888���� $ Indigo���� $ DarkBlue���� $
 #CCC���� $ Black ���� $
 #AAA���� $ 
DarkOrange��u�0,8,-4,0q�u�	-4,0,-4,0q�u�0,4,-4,0q�u�4,0,0,0q���#888��