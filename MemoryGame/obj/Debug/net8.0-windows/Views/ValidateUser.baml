   M S B A M L   `   `   `  ����E  AMemoryGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MemoryGame
MemoryGame  5   	       MemoryGame.ValidateUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MemoryGame     5   	     � Title$  Validate User��5   	   $	��400��6   $	��300��6,   .��5	      � $	��400��6   $��Center=�6   .+�5
   
   �� $��
110,82,0,0q�6   $	��140��6&   $��21��62   $
��Left=�6>   $	��Top=�6Y   ���	#FFFFA0A0��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� 
IsReadOnly 5   )   �� *
CanSetName+   InverseBooleanConverter �� 	Converter# [  �� 5   
   $��110,127,0,0q�6   $	��140��6'   $��21��63   $
��Left=�6?   $	��Top=�6Z   ���	#FFFFA0A0��5      �� *
Password+$ PropertyChanged=�6Q   �� 5   
   $��	49,85,0,0q�6   $��Name:��6'   $	��Top=�64   $
��Left=�6L   �� 5   
   $��
49,130,0,0q�6   $��	Password:��6(   $	��Top=�69   $
��Left=�6Q   �� 5   
   $
��Left=�6.   $��	56,31,0,0q�6I   $	��Top=�6\   $��18(�6t   $��Center=�6�   $��Center=�6�   ��6   �� *	TitleText+6�   �� 5   
   $
��Left=�5      $��
62,190,0,0q�6,   $	��Top=�6@   ���	#FFEB6464��5      �� *OkButtonText+��62   �� *SubmitCommand+5   X   �� 5   
   $��Cancel��6   $
��Left=�5      $��	187,0,0,0q�6,   $��Center=�6?   ���	#FFEB6464��5   "   �� *CancelCommand+5   Z   �� 5   
   $��	0,230,0,0q�6   $	��Top=�6(   $��Center=�6@   .+�5      �� $	��100��6>   $	��100��6J   $
��0,10q�6W   ��6   �� *SelectedProfilePicture+y�5      �� 5       �� Path$ 
CanSetName�6    5      *   $MemoryGame.BoolToVisibilityConverter  5       5"      5$      �� 5%       �� Orientation$ 
Horizontal=�6   $��Center=�62   $	��0,5q�6O   .+�5&      �� -   5        $	��⏴��5&      $��40��6%   y�5'      �� 5(      $ 
CanSetName�6"    5)        5*   "   5,      5.      �� 5/      -   5        $	��⏵��5/      $��40��6)   $��10,0,0,0q�6L   y�50      �� 51      $ 
CanSetName�6"    52        53   "   55      57      58      �� 59      $ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   5:      5;      5<      