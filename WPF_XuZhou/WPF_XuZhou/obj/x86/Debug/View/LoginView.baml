   M S B A M L   `   `   `  ����E  AWPF_XuZhou, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_XuZhou.ViewWPF_XuZhou.View  5      ;"clr-namespace:WPF_XuZhou.ViewModelWPF_XuZhou.ViewModel  5
          WPF_XuZhou.View.LoginView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPF_XuZhou.View     5      G CHandyControl, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null0hc'https://handyorg.github.io/handycontrol  5	      2	ViewModel"clr-namespace:WPF_XuZhou.ViewModel  5
        N� Title$  登录页面��5       � DataContext 5      )   #WPF_XuZhou.ViewModel.LoginViewModel  5   
   .��5   
   �  � RowDefinitions 5      �� 5      �� 5      $
��3.5* �6    .+�5   
   �� ���#0E64F4$��0��6'    �� CornerRadius$ 	10 10 0 0��64   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   $��80��6S   $��Center=�6_   .+�5      �� $Q��Khttp://plat.xzjxjy.com/upload/admin/image/20200118/20200118120428112811.jpg��6   $��60��6q   $��80��6|   �� 5      $0��*徐州市专业技术人员继续教育网��6    $��30(�66   $��	10 20 0 0q�6D   
�������6W   5      5      �� 5      $��1��6   
�������$ 	0 0 10 10��65   ._�5      �  � ColumnDefinitions 5      �� 5      �� 5      .+�5!      �� $��0��6   $
 10  ��6(   
�������   EffectShadow5 J� Effect# [  6O   $��50 20q�6w   ._�5"      �  5#      �� 5$      �� 5%      $��3* �6,   �� 5&      �� 5'      .+�5)      �� $��0��6$   $��用户登录��61   
�������$��Center=�6O   $��30(�6l   $��Center=�6z   �� 5*      $��1��6%   $��30 20q�62   .+�5+      #  HandyControl.Controls.TextBox  '  !HandyControl.Controls.InfoElement   Placeholder$ 	用户名��6?   $��50��6`   )  #HandyControl.Controls.BorderElement   CornerRadius$ 0��6l   $��25(�6�   $��0 0 0 1q�6�   ��6)   �� *Name+6�     5,      $ 密码��6C   $��50��6c   $��0 10 0 0q�6o   $ 0��6�   $��25(�6�   $��0 0 0 1q�6�   ��6)   �� *
Password+6�   5-      �� 5.      $��2��6B   $ 10��6O   $��登录��6r   $	��250��6�   ���#5494FF
�������$��30(�6�   $��50��6�   ��6!   �� *LoginCommond+6�   5/      50      �� 51      $��1��6   $��20 50q�6)   ._�52      �� .+�53      �� $��/Upload/Image/login1.png��6    $	��180��6C   �� 54      $��免责声明��6$   
�������$��Center=�6B   $��20(�6_   $��0 0 0 10q�6m   �� 55      $\��V程序仅供参考学习,请勿违规学习,违规学习造成的责任请自行承担��6$   
�������6J   �� 56      $?��9使用本程序或源码即表示您已同意上述规定��6$   $��Center=�6?   
�������6\   57      58      59      5:      5;      5>      