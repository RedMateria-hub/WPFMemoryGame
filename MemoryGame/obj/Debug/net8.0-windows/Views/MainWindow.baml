   M S B A M L   `   `   `  ����E  AMemoryGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MemoryGame
MemoryGame  5   	   =#clr-namespace:MemoryGame.ViewModelsMemoryGame.ViewModels  5   	       MemoryGame.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MemoryGame     5   	   2vm#clr-namespace:MemoryGame.ViewModels     5   	     � Title$  Memory Game��5	   	   $	��450��6   $	��800��6*   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FFB63F3F��6    � Offset$ 1Q�61   5      .+�5   
   �� -   5        $��UsersListbox��5      $
��Left=�5      $	��266��6-   $��
33,144,0,0q�6:   $	��Top=�6N   $	��384��6f   ���	#FF161616���	#FFF1F1F1��5      �� *Users+��5   @   Z� ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   $��5q�6:   .+�5      �� $
��Bold"�6:   ��6$   �� *Name+6:   5      5      5      �� 5    
   $
��Left=�6   $��
232,52,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��61��5!      $	��348��6    
������� �� TextAlignment$ Center=�6?   $��48(�6V   $
��Bold"�6d   �� 5"      $�Memory Game��6   5#      �� 5%   
   $��Add new player��6   $
��Left=�5&      $��463,219,0,0q�6,   $	��Top=�6A   $��43��6Y   $	��106��6e   ���	#FF161616���	#FFF1F1F1��5%   *   �� *AddUserCommand+��5'   ?   Z� �� 5)   
   $��Remove player��6   $
��Left=�5*      $��463,278,0,0q�6,   $	��Top=�6A   $��43��6Y   $	��106��6e   ���	#FF161616���	#FFF1F1F1��5)   )   �� *RemoveUserCommand+��5+   ?   Z� �� 5-   
   $
��Play��6   $
��Left=�5.      $��463,158,0,0q�6,   $	��Top=�6A   $��43��6Y   $	��106��6e   ���	#FF161616���	#FFF1F1F1��5-       �� *StartGameCommand+��5/   ?   Z� �� 51   
   $
��Exit��6   $
��Left=�52      $��463,339,0,0q�6,   $	��Top=�6A   $��43��6Y   $	��106��6e   ���	#FF161616���	#FFF1F1F1��51       �� *ExitCommand+��53   ?   Z� �� 55   
   ${�False��68   $��Center=�56      $��629,300,0,0q�6/    �� TextWrapping$
 Wrap=�6D   $	��Top=�57      $	��152��6*   $��22��66   
�������$
��Bold"�58   R   ��55      �� *	LogText+ �� Mode$ OneWay=���58      Z� ��6;   Z� 6R   �� 59   
   $
��Left=�69   $��98��6T   $��638,180,0,0q�6`   $	��Top=�6u   $	��100��6�   ��6   �� *CurrentProfilePicture+6�   �� 5:   
   ${�False��6?   $��Center=�5;   
   $��629,330,0,0q�6'   $
 Wrap=�6<   $	��Top=�5<   
   $	��161��6"   $��22��6.   
�������$
��Bold"�5=   J   ��5:      �� *NumGamesPlayed+$ OneWay=���5=   
   Z� ��63   Z� 6J   �� 5>   
   ${�False��6<   $��Center=�5?   
   $��629,360,0,0q�6'   $
 Wrap=�6<   $	��Top=�5@   
   $	��152��6"   $��22��6.   
�������$
��Bold"�5A   J   ��5>      �� *NumGamesWon+$ OneWay=���5A   
   Z� ��63   Z� 6J   5B      5C      