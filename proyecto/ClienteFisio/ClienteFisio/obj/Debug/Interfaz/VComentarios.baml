   M S B A M L   `   `   `  ����  ClienteFisio(    "ClienteFisio.Interfaz.VComentarios   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          � Icon$  /data/images/Chat.png��5   	    � Title$ Comentarios��5      $	��475��6   $	��623��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterOwner=�6x    � DataContext 5   	   ��  �� RelativeSource �� *Self+��5      �� 5	   
    �� EndPoint$ 0.939,0.919&�6    �� 
StartPoint$ 0.061,0.081&�65   .��5
      �  � Color$ 	#FFFFE07E��6   	 � Offset$	 0Q�6-   � 5      $ 	#FFFFFAEA��6   $	 1Q�6-   5      
 � 	Resources
 5         
BlueHeader �� Orientation��%�  &	        �� 5   
   .R�5      �� $ 
Horizontal=�6   $��-5,-5,-5,-5q�62   $
��1000��6G   ��5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5      � $ 	#FF223B84��6'   $	 1Q�69   � 5      $ 	#FF57A0F4��6'   $		 0.5Q�69   � 5      $ 	#FF4B94EC��6'   $		 0.5Q�69   5      .+�5      �� $��10,10,10,10q�6   $��Center=�6B   
���������61   �� 6]   5      5      5      .��5      � .+�5   
   �� -   5        $��listViewComs��5   l     CustomerTemplate#���  6:   $��52,54,243,0q�6�   $	��162��6�   $	��Top=�6�   ��6   �� *ComsCollection+ �� View 5      �� 5       .P�5!      ��  �� Width$	 180��6%   $��Paciente��61    �� HeaderTemplate# [  6m    �� DisplayMemberBinding 6C   �� *
Paciente+6m   �� 5"      $	 150��6%   $��Fecha��61   # [  6g    6@   �� *Fecha+6g   5$      ��5&      �� 5'      $ 0.939,0.919&�6&   $ 0.061,0.081&�6=   .��5(      � $ 	#FFFFE07E��6#   $	 0Q�65   � 5)      $ 	#FFFFFAEA��6#   $	 1Q�65   5*      ��5,      �� 5-       �� 
TargetType" ��6   .�5.      ��  �� Property � �� �� Value$ 24��6/   �� 5/       � �� �	#5EF4E05763   �� 50       � �� �	#FF4B94EC63    �� Triggers 52      P� 53       P� Property �@J�IsMouseOver P� Value . . �54      ��  � ��
 ��  �6;   �� 55       � �� 56   "   �� 57   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��58   *   � $ 	#FFFFC704��67   $	 0.986Q�6I   � 59   *   $ 	#FFF4E057��67   $		 0.5Q�6I   � 5:   *   $ 	#FFF4E057��67   $
	 0.51Q�6I   5;   '   5=      5>      5A      5C      �� 5D   
   -   5        $��textBox1��5D   3   $	��110��6   $��
52,0,55,78q�6   $��Bottom=�6C    �� AcceptsReturn .  �� 
AcceptsTab . $ �� HorizontalScrollBarVisibility$
 Auto=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�    �� TextWrapping$
 Wrap=�6�   �� 5E   
   -   5        $��	btnVolver��5E   L   $��23��6   $��Right=�6   $��	0,0,55,15q�69   $��Bottom=�6]   $��75��6x   .��6�   Volver6�   )  #Microsoft.Windows.Controls.Calendar  5F   
   6my-http://schemas.microsoft.com/wpf/2008/toolkit  6d   -   5        $��	calendar1��5F   G   $��Right=�6   $��0,54,55,181q�62   $	��180��6X   6d   �� 5G   
   -   5        $��btnEliminar��5G   N   $��19��6   $��Right=�6   $��0,0,243,197q�69   $��Bottom=�6a   $��51��6|   .��6�   
Eliminar6�   �� 5H   
   -   5        $��	lblAvisos��5H   0   $��27��6   $��
52,0,55,46q�6   $��Bottom=�6A   
���  ��$��13(�6m   $��Center=�6{   6�   5I      5J      