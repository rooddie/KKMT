   M S B A M L   `   `   `  ����@  <Diary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DiaryDiary  5	          Diary.UserControlCreate   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      localclr-namespace:Diary  5	         ControlsBackgroundStyle#���   5        ForegroundColor#���  5      $
��Auto��5      $
��Auto��6   .��5      � -   5          �Name$  
CreateGrid��5   %   $
��1210��6   $	��660��6    � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      .+�5   
   �� $��2��6   .+�5      �� -   5         ��Name$ titleBox��5       �� TextWrapping$
 Wrap=�5      " �� VerticalScrollBarVisibility$
 Auto=�5      $	��Top=�5        NameNote)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�5         FloatingScale$
 0.50Q�5       % !MaterialDesignFloatingHintTextBox#��[ 5        BorderColor#���  5      $��24(�5      $��80,50,80,50q�6   $��54��64   $	��Top=�6@   �� 5       -   5        $ descriptionBox��5!      $
 Wrap=�5"       �� 	MaxLength$	 400��5#      $	��Top=�5$      $
 Auto=�5%        DescriptionNote# �  5&      $ 1 0 1 0q�5'      $
 0.50Q�5(      #��[ 5)      #���  5*      $��24(�5+      $��
80,0,80,50q�6   $	��251��63   $	��Top=�6@   �� 5-      	 �� Orientation$	 
Horizontal=�6   $��Center=�62   $��0q�6M   $��Center=�6X   .+�5.      (  "System.Windows.Controls.DatePicker  -   5        
  Name$
 
datepicker��5/        DateNote# �  50      $ 2 0 2 0q�51      $
 0.50Q�52       ( $MaterialDesignFloatingHintDatePicker#��[ 53      $��	0,0,80,50q�6S   $��24(�6f   #���  54      $��55��55      $	��Top=�6!   $
��Left=�69   $	��300��6T   6b   )  #MaterialDesignThemes.Wpf.TimePicker  57      -   5          Name$ 
timepicker��58       ( $MaterialDesignFloatingHintTimePicker#��[ 59      #���  5:       	 TimeNote# � 	 5;      $ 2 0 2 0q�5<      $
 0.50Q�5=      $��24(�5>      $	��Top=�6#   $��40��6;   $	��300��6G   $��Right=�6S   $��0,15,0,0q�6o   5?      �� 5@      -   5         ��Name$ button��5@       
 CreateNoteButton#��� 
 6%   $	��400��6R   $��	80,0,80,0q�6^   $��50��6q   $��22(�6}   $��Bottom=�6�   5A      5E      5F      