   M S B A M L   `   `   `  ����N  JООО_Посуда, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ООО_ПосудаООО_Посуда  5   	   $    ООО_Посуда.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ООО_Посуда     5   	     � Title$  Авторизация��5   	   $	��250��6   $	��500��6*   $	��225��66   $	��475��6F   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Авторизация��6   $��2��6&   $��24(�6:   $��Center=�6H   $	��Top=�6e   �� 5   
   $��1��6   $��2��6   $��/Images/logo.png��61   $��50��6K   $��50��6W   $	��Top=�6b   �� 5   
   $��
Логин��6   $��2��6    �� 5   
   -   5         ��Name$ LoginTextBox��5      $��2��6(   $��1��65   $��0��6E   �� 5   
   $��Пароль��6   $��3��6!   G� 5   
   -   5         G�Name$ Password_PasswordBox��5      $��3��64   $��1��6A   $��1��6Q   � 5    
   $��4��6   $��2��6    5!      �� 5"      �� 5#      .+�5&      �� -   5         ��Name$ EnterButton��5&   %   $��
Войти��6   $��2��6:   6G   �� 5'      -   5        $ EnterAsGuest��5'   ?   $��1��6   $"��Войти как гость��6%   $��3��6U   6b   5(      5)      5*      