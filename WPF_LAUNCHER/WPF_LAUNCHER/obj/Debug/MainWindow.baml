   M S B A M L   `   `   `  ����G  CWPF_LAUNCHER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPF_LAUNCHERWPF_LAUNCHER  5   	       WPF_LAUNCHER.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WPF_LAUNCHER     5   	   -   5          �Name$  LAUNCHER��5   	    � Title$ LAUNCHER��5   	   $	��500��6   $	��320��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I   ���	#FFAA6060 � Icon$ /Resources/launcher.ico��5	   	    � 	Resources 5
       �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius F�Name �� Stretch ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  '��       �� 5   
   " ��6   .�5      ��  � �� �#3737376+   �� 5       � ��
 �����6+   �� 5       � ��$ 15(�6)   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $
 4��6!   #��z��62   ._�5      � .+�5   "   F� $ PathIcon��6'   $��15��69   $��25��6D   $
 Fill=�6P   ���#4C87B3$
��Left=�6n   $��17,0,0,0q�6�   4�������<R���=�x�O���Tn5����<R6�   �� 5   "   $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0,0,0,0q�6�   5      5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  � �� �#E594006?   �� 5   "    � ��
 �����6?   �� 5   "   $ PathIcon��6)    � ��
 �   �6O   5       P� 5"       � �� . . �5#   "   ��  � ��
 � E��6?   �� 5$   "    � ��
 �����6?   5%      5'      5)      5*      5+      .��5,      �� $	��292��6   .+�5-   
   �� -   5         ��Name$ button_Сalc1��5-      $��Калькулятор 1��6'   $��Center=�6?   $��0,32,0,0q�6\   $��Center=�6n   $	��250��6�   $��55��6�   6�   �� 5.   
   -   5        $ button_Calc2��5.      $��Калькулятор 2��6'   $��Center=�6?   $��0,32,0,0q�6\   $��Center=�6n   $	��250��6�   $��55��6�   6�   �� 5/   
   -   5        $ 	button_15��5/      $��Пятнашки��6$   $��Center=�67   $��0,32,0,0q�6T   $��Center=�6f   $	��250��6�   $��55��6�   6�   �� 50   
   -   5        $ 
button_skd��50      $��Судоку��6%   $��Center=�66   $��0,32,0,0q�6S   $��Center=�6e   $	��250��6�   $��55��6�   6�   �� 51   
   -   5        $ 
button_sap��51      $��
Сапёр��6%   $��Center=�65   $��0,32,0,0q�6R   $��Center=�6d   $	��250��6   $��55��6�   6�   53      54      