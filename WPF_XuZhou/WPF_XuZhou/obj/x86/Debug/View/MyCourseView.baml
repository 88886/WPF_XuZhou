   M S B A M L   `   `   `  ����E  AWPF_XuZhou, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_XuZhou.ViewWPF_XuZhou.View  5      ;"clr-namespace:WPF_XuZhou.ViewModelWPF_XuZhou.ViewModel  5
      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      "    WPF_XuZhou.View.MyCourseView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPF_XuZhou.View     5      G CHandyControl, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null0hc'https://handyorg.github.io/handycontrol  5	      2	ViewModel"clr-namespace:WPF_XuZhou.ViewModel  5
      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5        N� Title$  我的课程��5       � DataContext 5      ,   &WPF_XuZhou.ViewModel.MyCourseViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��7* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 	10 10 0 0��6   ���#0E64F4._�5      �� $��我的课程��6   $��30(�6$   $��Center=�62   $��Center=�6O   
�������6j   5      �� 5   
   $��1��6   $ 	0 0 10 10��6   
�������._�5      �� .+�5      �� -   5         ��Name$ listboxclass��5   '   $	��400��6   $	��800��6�   $��Center=�6�      WrapPanelHorizontalListBox#��[  6�   $��0q�6�   
������ y�6=   �� *
ShowCourse+��6`   �� *MyCourseList+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *OpenCourseCommond+	   CommandParameter	 6Z   �� 
 �� ElementName$
 listboxclass�� �� Path$ SelectedItem�5      ��5       �� 5!      .R�5"      �  K� IsItemsHost . 6(   5#      ��5%      �� 5&      .R�5'      �� $��20q�6%   $ 10��61   
�������  EffectShadow5 J� Effect# [ 6V   $	��200��6~   $	��280��6�   ._�5(   "   �  5)   &   �� 5*   *   $��3* �68   �� 5+   *   .+�5-   &   �� $��0��6-   $ 	10 10 0 0��6:   ��5.   *   �� 5/   .    j� Stretch$
 Fill=�6\    �� ImageSource 69   �� *
IndexPhoto+6\   51   '   �� 52   &   $��1��6-   $ 	0 0 10 10��6:   ._�53   *   � $��5q�6/    54   .   �� 55   2   �� 56   2   $��20 �6@   .+�58   .   �� $��0��68   $
��Wrap=�6a   ��6E   �� *
CourseName+6a   � 59   .   $��1��6:   $��0q�6b   $��11��6m    � Value 6G   �� *
Progress+6m   5:   +   5;   '   5<   #   5=      5>      5@      �� 5B      -   5        $ listboxclassinfo��5B   �   
������ $	��400��65   $	��780��6B   $��Center=�6N   #��[  6�   $��0q�6  y�6k   �� *ShowCourseInfo+��6�   �� *
CourseInfo+ 5C        5D      $ SelectionChanged��6)   . 5E         64   �� *OpenCourseCommond+	 6Z   �� $
 listboxclassinfo��$ SelectedItem�5F      ��5H      �� 5I      .R�5J      �  . 6(   5K      ��5M      �� 5N      .R�5O      �� $	�� 10q�6%   $ 10��62   
�������# [ 6W   $	��240��6   $	��280��6�   ._�5P   "   �  5Q   &   �� 5R   *   $��4* �69   �� 5S   *   �� 5T   *   $��25 �68   .+�5V   &   �� $��0��6-   $ 	10 10 0 0��6:   ��5W   *   �� 5X   .   $
 Fill=�6X    69   �� *imgurl+6X   5Z   '   �� 5[   &   $��1��6-   $ 	0 0 10 10��6:   ._�5\   *   �� $��10q�64   $
��Wrap=�6X   ��6A   �� *title+6X   5]   '   � 5^   &   $��2��62   $��5q�6g   $��12��6r    6?   �� *	DProgress+ �� Mode$ OneWay=�6r   5_   #   5`      5a      5c      5d      5e      �� 5f   
   $	��600��6   $��65��6   $��	0 400 0 0q�6*   y�6=   �� *ShowProgress+.+�5g      7  1HandyControl.Controls.TransitioningContentControl  .��5h      �� $ 10��6   
�������$	��600��6?   $��45��6K    J� Opacity$	 0.8Q�6W   # [ 6f   ._�5i      �  5j      �� 5k      �� 5l      .+�5n      �� $��0��6=   $��Center=�6J   $��Center=�6g   
���  ����6$   �� *	Message+6�   � 5o      $��1��6&     ProgressBarWarning#��[ 63   $��5q�6�   $��12��6�    6_   �� *NowVideoProgress+6�   5p      5q      5r      5s      �� 5t   
   $��40��6   $��40��6   $��730 340 0 0q�6(   y�6=   �� *ShowCourseInfo+.+�5u      �� $��40��6   $��40��6!   $ 40��6-   ���#ff5837# [ 6T   ._�5v      �� 
�������  IconFont#��[ 6L   $��20(�6s   $��Center=�6�   $��Center=�6�   ��6   �� *
BorderText+6�    5w        5x      $ MouseLeftButtonDown��6%   . 5y         60   �� *LearnOrStopCommond+5z      5|      5}      �� 5~   
   $��40��6   $��40��6   $��730 395 0 0q�6(   .+�5      �� $��40��6   $��40��6!   $ 40��6-   ���#0E64F4# [ 6T   ._�5�      �� $	����6   
�������#��[ 6?   $��20(�6f   $��Center=�6t   $��Center=�6�    5�        5�      $ MouseLeftButtonDown��6%   . 5�         60   �� *ShowPageHome+5�      5�      5�      5�      5�      