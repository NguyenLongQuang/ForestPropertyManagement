   M S B A M L   `   `   `  ����S  OForestPropertyManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:ForestPropertyManagement.Views.Facility'ForestPropertyManagement.Views.Facility  5   	   9    3ForestPropertyManagement.Views.Facility.AddFacility   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:ForestPropertyManagement.Views.Facility     5   	     � Title$*  $Điền thông tin cơ sở mới��5   	   $	��450��6-   $	��450��6:   .��5	      � .+�5
   
   �� .+�5      �� $��0q�6    �� Orientation$ 
Horizontal=�6$   .+�5      �� $��0q�6   $��Tên cơ sở: ��6'   $
��Bold"�6;   �� 5      -   5         ��Name$ InputFormerName��5   5   $��0q�6   $
��60 5q�6%   6N   5      �� 5      $��0q�6   $ 
Horizontal=�6$   .+�5      �� $��0q�6   $��Địa chỉ: ��6'   $
��Bold"�6:   �� 5      -   5         ��Name$ DistrictComboBox��5   &   $��0q�6   $
��Left=�6@   $	��Top=�6[   5      5      �� 5      $��0q�6   $ 
Horizontal=�6$   .+�5      �� $��0q�6   $&�� Hình thức hoạt động: ��6'   $
��Bold"�6H   �� 5      -   5        $ BusinessStructureComboBox��5   &   $��0q�6   $
��Left=�6I   $	��Top=�6d   5      5      �� 5      $��0q�6   $ 
Horizontal=�6$   .+�5      �� $��0q�6   $��Ngày thành lập: ��6'   $
��Bold"�6B   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ EstablishedDatePicker��5   (   $��0q�6   $
��Left=�6G   $	��Top=�6b   5      �� 5!      -   5         ��Name$ productStackPanel��5!      $
��Left=�64   $	��Top=�6O   $��10q�6g   �� 5#      -   5        $��Thêm sản phẩm��5#      $
��Left=�6H   $	��Top=�6c   � 5%      -   5         �Name$ productPopup��5%      .��5&      �� $��0q�6!   $ 
Horizontal=�6,   5)      5*      �� 5,      -   5        $��Lưu thông tin��5,      $
��Left=�6G   $	��Top=�6b   5-      5.      5/      