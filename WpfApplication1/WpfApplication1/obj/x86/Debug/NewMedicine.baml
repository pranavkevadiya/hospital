   M S B A M L   `   `   `  ����B  >NewLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5      !    WpfApplication1.NewMedicine   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      /localclr-namespace:WpfApplication1     5        � Title$  NewMedicine��5      $	��300��6   $	��300��6&   .��5      �  � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5	      $
��324* �6   .+�5   
   �� -   5        $��medicineNameLabel��5   Y   $
��Name��6   $��30��6   $
��Left=�6+   $��	37,29,0,0q�6F   $	��Top=�6r   $��1��6�   �� 5   
   -   5        $��
powerLabel��5   Z   $��Power��6   $��30��6    $
��Left=�6,   $��	37,61,0,0q�6G   $	��Top=�6l   $��1��6�   �� 5   
   -   5        $��
stateLabel��5   j   $��State��6   $��1��6    $��30��60   $
��Left=�6<   $��	37,87,0,0q�6W   $	��Top=�6|   �� 5   
   -   5         ��Name$ 	Medicine1��5      $��1��6%   $
��Left=�65   $��99,31,0,207q�6P   $	��120��6e      Borders#��[  6q   .��6�   ��5      �� 5       �� Path$ Medicine�6    �� UpdateSourceTrigger$ PropertyChanged=�6+    �� ValidationRules 5      *   $WpfApplication1.NumberValidationRule  5      5      .��5       � ToolTip 5      �� 5      .+�5      �� Medicine Name6/   5      .��5      5      �� 5   
   -   5        $��power��5   \   $��1��6   $��23��6"   $
��Left=�6.   $��	99,61,0,0q�6I   $	��Top=�6i   $	��120��6�   $	��100��6�   #��[  6�   .��6�    5       �� 5!      .+�5"      �� Power of medicine63   5#      .��5$      5%      �� 5'   
   -   5        $��stateValues��5'   ]   $��1��6   $��23��6#   $
��Left=�6/   $��	99,87,0,0q�6J   $	��Top=�6p   $	��120��6�    �� SelectedValue$ TABLET��6�   ��6�   �� 6�   �� 5)   
   -   5        $��Button1��5)   k   $	��Add��6   $��1��6   $��23��6/   $
��Left=�6;   $��191,226,0,0q�6V   $	��Top=�6z   $��75��6�   {�.  6�   �� 5,   
   -   5        $��
errorLabel��5,   f   $�� ��6   $��1��6   $��30��6+   $
��Left=�67   $��
12,219,0,0q�6R   $	��Top=�6x   ���	#FFEF28286�   5.      5/      