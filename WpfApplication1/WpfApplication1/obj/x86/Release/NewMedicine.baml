   M S B A M L   `   `   `  ���� B  >NewLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  !    WpfApplication1.NewMedicine   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /localclr-namespace:WpfApplication1       � Title$  NewMedicine��$	��300��$	��300��.���  � ColumnDefinitions �� $��0* ��� $
��324* �.+��� -   $��medicineNameLabel��$
��Name��$��30��$
��Left=�$��	37,29,0,0q�$	��Top=�$��1���� -   $��
powerLabel��$��Power��$��30��$
��Left=�$��	37,61,0,0q�$	��Top=�$��1���� -   $��
stateLabel��$��State��$��1��$��30��$
��Left=�$��	37,87,0,0q�$	��Top=��� -    ��Name$ 	Medicine1��$��1��$
��Left=�$��99,31,0,207q�$	��120��   Borders#��[  .������  �� Path$ Medicine� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidationRules *   $WpfApplication1.NumberValidationRule  .�� � ToolTip �� .+��� Medicine Name.���� -   $��power��$��1��$��23��$
��Left=�$��	99,61,0,0q�$	��Top=�$	��120��$	��100��#��[  .�� �� .+��� Power of medicine.���� -   $��stateValues��$��1��$��23��$
��Left=�$��	99,87,0,0q�$	��Top=�$	��120�� �� SelectedValue$ TABLET������ �� -   $��Button1��$	��Add��$��1��$��23��$
��Left=�$��191,226,0,0q�$	��Top=�$��75��{�.  �� -   $��
errorLabel��$�� ��$��1��$��30��$
��Left=�$��
12,219,0,0q�$	��Top=����	#FFEF2828