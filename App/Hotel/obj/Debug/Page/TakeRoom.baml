   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Hotel.Page
Hotel.Page  5          Hotel.Page.TakeRoom   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Hotel.Page     5        N� Title$  TakeRoom��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   .+�5   
   �� -   5        $��RoomList��5      $
��Left=�6#   $	��300��6>   $��4��6K   $	��Top=�6\   $	��800��6t   $��3��6�    �� View 5      �� 5       �� ColumnHeaderContextMenu 5      �� 5      .P�5      �� $��Номер комнаты��6%    �� DisplayMemberBinding 6<   ��  �� Path$ Room_Num��� 5       $!��Статус комнаты��6%    6=   �� $ Status��� 5!      $��Владелец��6%    67   �� $ Holder�5"      5$      �� 5%   
   -   5        $	��Zas��5%   #   $��Заселиться��6.   $��1��6C   $
��Left=�6S   $��266.333,0,0,0q�6n   $��4��6�   $	��Top=�6�   $	��267��6�   $��2��6�   $��75��6�   {�.  6�   5&      5'      