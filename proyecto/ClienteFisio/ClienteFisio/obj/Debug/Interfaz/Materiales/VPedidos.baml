   M S B A M L   `   `   `  ����  ClienteFisio/    )ClienteFisio.Interfaz.Materiales.VPedidos   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          � Icon$-  '/data/images/001_shoppingcart_empty.png��5   	    � Title$ Pedidos��5      $	��737��6   $	��775��6"    � WindowStartupLocation$ CenterOwner=�6.    � 
ResizeMode$ NoResize=�6R    � DataContext 5      ��  �� RelativeSource �� *Self+ � 	Resources 5         
BlueHeader �� Orientation �� EndPoint	 �� 
StartPoint
 � Color � Offset��%�  &	        �� 5   
   .R�5	      �� $ 
Horizontal=�6   $��-5,-5,-5,-5q�62   $	��500��6G   ��5
      �� 5      $ 0.5,1&�6*   $	 0.5,0&�6;   .��5      � $
 	#FF223B84��6'   $ 1Q�69   � 5      $
 	#FF57A0F4��6'   $	 0.5Q�69   � 5      $
 	#FF4B94EC��6'   $	 0.5Q�69   5      .+�5      �� $��10,10,10,10q�6   $��Center=�6B   
���������61   �� 6]   5      5      5      .��5      � $	��701��6   .+�5   
   �� -   5        $��	btnVolver��5   L   $��23��6   $��Right=�6   $��	0,0,11,11q�69   $��Bottom=�6]   $��75��6x   $��10��6�   .��6�   Volver6�   �� 5   
   -   5        $��listPeds��5   %   $��	25,59,0,0q�6   $��74��65   $	��Top=�6A   $
��Left=�6Y   $	��170��6t   $��1��6�   ��5      �� 5      $ 0.939,0.919&�6&   $	 0.061,0.081&�6=   .��5      � $
 	#FFFFE07E��6#   $ 0Q�65   � 5      $
 	#FFFFFAEA��6#   $ 1Q�65   5      5      �� 5    
   -   5        $��	lblPedido��5    J   $��42��6   $
��Left=�6   $��	25,15,0,0q�67   $	��Top=�6[   $	��186��6s   $��20(�6   .��6�   Pedidos registrados6�   �� 5!   
   -   5        $��	lblLinPed��5!   2   $��26��6   $��211,31,302,0q�6   $	��Top=�6C   $��13(�6[   $��Right=�6i   .��6�   Materiales pedidos6�   �� 5"   
   -   5        $��lblCant��5"   1   $��23��6   $��211,189,0,0q�6   $	��Top=�6@   $
��Left=�6X   $	��153��6s   .��6   Nº materiales adquiridos:6�   �� 5#   
   -   5        $��	lblPrecio��5#   1   $��28��6   $��211,213,0,0q�6   $	��Top=�6B   $
��Left=�6Z   $	��153��6u   .��6�   Importe total del pedido:6�   �� 5$   
   -   5        $��lblCant2��5$   M   $��23��6   $��Right=�6   $��0,189,227,0q�68   $	��Top=�6]   $	��135��6u   $��Right=�6�   6�   �� 5%   
   -	   5        $��
lblPrecio2��5%   M   $��23��6   $��Right=�6   $��0,213,227,0q�68   $	��Top=�6_   $	��135��6w   $��Right=�6�   6�   �� 5&   
   -
   5        $��btnEliminar��5&   L   $��20��6   $
��Left=�6   $��
25,136,0,0q�68   $	��Top=�6_   $��51��6w   $��2��6�   .��6�   
Eliminar6�   � 5'   
   -   5         �Name$ 
LayoutRoot��5'      $��211,59,219,0q�6#   $	��127��69   $	��Top=�6F   .+�5(      �� -   5        $��listViewLinPRegs��5(   v     CustomerTemplate#���  6D   $	��320��6�   $
��Left=�6�   ��6   �� *PedidoCollectionRegs+ �� View 5)      �� 5*      .P�5+      ��  �� Width$	 160��6)   $��Material��65    �� HeaderTemplate# [  6q    �� DisplayMemberBinding 6G   �� *
Material+6q   �� 5,      $ 80��6)   $��Cantidad(uds)��64   # [  6u    6K   �� *
Cantidad+6u   �� 5-      $ 80��6)   $��Precio(€/ud)��64   # [  6r    6J   �� *Precio+6r   �� 5.      $ 80��6)   $��
Total(€)��64   # [  6m    6F   �� *Total+6m   5/      ��51      �� 52      $ 0.939,0.919&�6*   $	 0.061,0.081&�6A   .��53      � $
 	#FFFFE07E��6'   $ 0Q�69   � 54      $
 	#FFFFFAEA��6'   $ 1Q�69   55      ��57      �� 58       �� 
TargetType" ��6   .�59      ��  �� Property � �� �� Value$ 24��63   �� 5:       � �� �	#5EF4E05767   �� 5;       � �� �	#FF4B94EC67    �� Triggers 5=      P� 5>       P� Property �@J�IsMouseOver P� Value . . �5?   "   ��  � ��
 ��  �6?   �� 5@   "    � �� 5A   &   �� 5B   *   $ 0.5,1&�6>   $	 0.5,0&�6O   .��5C   .   � $
 	#FFFFC704��6;   $ 0.986Q�6M   � 5D   .   $
 	#FFF4E057��6;   $	 0.5Q�6M   � 5E   .   $
 	#FFF4E057��6;   $
 0.51Q�6M   5F   +   5H   #   5I      5L      5N      5O      �� 5P   
   -   5        $��comboMat��5P   3   $��23��6   $��
34,0,0,269q�6   $��Bottom=�6C   $
��Left=�6^   $	��109��6y   $��3��6�   ��5Q      �� 5S      $ 0.939,0.919&�6*   $	 0.061,0.081&�6A   .��5T      � $
 	#FFFFE07E��6'   $ 0Q�69   � 5U      $
 	#FFFFFAEA��6'   $ 1Q�69   5V      5Y      �� 5Z   
   -   5        $��
lblAvisos3��5Z   %   $��20,0,358,26q�6   $��24��67   $��Bottom=�6C   6`   �� 5[   
   -   5        $��listViewLinP��5[   n   #���  6<   $��Right=�6�   $	��324��6�   $��
0,0,26,212q�6�   $	��138��6�   $��Bottom=�6�   ��6   �� *PedidoCollection+ 5\      �� 5]      .P�5^      �� $ 80��6%   $��Material��60   # [  6l    6B   �� *
Material+6l   �� 5_      $ 80��6%   $��Cantidad(uds)��60   # [  6q    6G   �� *
Cantidad+6q   �� 5`      $ 80��6%   $��Precio(€/ud)��60   # [  6n    6F   �� *Precio+6n   �� 5a      $ 80��6%   $��
Total(€)��60   # [  6i    6B   �� *Total+6i   5b      ��5d      �� 5e      $ 0.939,0.919&�6&   $	 0.061,0.081&�6=   .��5f      � $
 	#FFFFE07E��6#   $ 0Q�65   � 5g      $
 	#FFFFFAEA��6#   $ 1Q�65   5h      ��5j      �� 5k      " ��6   .�5l      ��  � ��$ 24��6/   �� 5m       � �� �	#5EF4E05763   �� 5n       � �� �	#FF4B94EC63    5p      P� 5q       �@J�IsMouseOver . . �5r      ��  � ��
 ��  �6;   �� 5s       � �� 5t   "   �� 5u   &   $ 0.5,1&�6:   $	 0.5,0&�6K   .��5v   *   � $
 	#FFFFC704��67   $ 0.986Q�6I   � 5w   *   $
 	#FFF4E057��67   $	 0.5Q�6I   � 5x   *   $
 	#FFF4E057��67   $
 0.51Q�6I   5y   '   5{      5|      5      5�      �� 5�   
   -   5        $��	txtPrecio��5�   3   $��23��6   $��182,0,0,269q�6   $��Bottom=�6D   $
��Left=�6_   $��42��6z   $��4��6�   .��6�   ��5�      �� 5�      $ 0.939,0.919&�6&   $	 0.061,0.081&�6=   .��5�      � $
 	#FFFFE07E��6#   $ 0Q�65   � 5�      $
 	#FFFFFAEA��6#   $ 1Q�65   5�      .��5�   "   5�      �� 5�   
   -   5        $��txtUds��5�   N   $��23��6   $
��Left=�6   $��258,0,0,269q�69   $��Bottom=�6\   $��35��6w   $��5��6�   .��6�   ��5�      �� 5�      $ 0.939,0.919&�6&   $	 0.061,0.081&�6=   .��5�      � $
 	#FFFFE07E��6#   $ 0Q�65   � 5�      $
 	#FFFFFAEA��6#   $ 1Q�65   5�      .��5�   "   5�      �� 5�   
   -   5        $��
btnAñadir��5�   4   $��28��6   $��327,0,367,269q�6   $��Bottom=�6E   $��6��6x   .��6�   	Añadir->6�   �� 5�   
   -   5        $��
lblPrecio3��5�   L   $��23��6   $
��Left=�6   $��222,0,0,269q�67   $��Bottom=�6^   $��35��6y   .��6�   €/ud6�   �� 5�   
   -   5        $��lblCantidad��5�   L   $��23��6   $
��Left=�6   $��291,0,0,269q�67   $��Bottom=�6_   $��32��6z   .��6�   Uds6�   �� 5�   
   -   5        $��txtComentarios��5�   &   $��
104,0,0,81q�6   $��59��6<   $��Bottom=�6H   $
��Left=�6c   $	��260��6~    �� AcceptsReturn .  �� 
AcceptsTab . .��6�   ��5�      �� 5�      $ 0.939,0.919&�6&   $	 0.061,0.081&�6=   .��5�      � $
 	#FFFFE07E��6#   $ 0Q�65   � 5�      $
 	#FFFFFAEA��6#   $ 1Q�65   5�      .��5�   "   5�      �� 5�   
   -   5        $��lblComentarios��5�   L   $��22��6   $
��Left=�6   $��104,0,0,142q�67   $��Bottom=�6b   $	��120��6}   .��6�   Comentarios6�   �� 5�   
   -   5        $��btnRegistrar��5�   9   $��27.277��6   $��104,0,0,45.139q�6!   $��Bottom=�6M   $
��Left=�6h   $��75��6�   $��9��6�   .��6�   	Registrar6�   +  %Microsoft.Windows.Controls.DatePicker  5�   
   6my-http://schemas.microsoft.com/wpf/2008/toolkit  6�   -   5        $��
datePicker��5�   \   $��27.277��6   $��Right=�6(   $��0,0,389,45.139q�6D   $��Bottom=�6n   $	��106��6�      Text$ Fecha de pedido��6�   $��8��6�   ��5�      �� 5�      $ 0.939,0.919&�6*   $	 0.061,0.081&�6A   .��5�      � $
 	#FFFFE07E��6'   $ 0Q�69   � 5�      $
 	#FFFFFAEA��6'   $ 1Q�69   5�      5�      �� 5�   
   -   5        $
��lbl1��5�   K   $��28��6   $
��Left=�6   $��
20,0,0,322q�67   $��Bottom=�6W   $	��169��6r   .��6~   !Adjunta los productos al pedido6�   �� 5�   
   -   5        $��	lblAvisos��5�   &   $��25                ��5�      $��
104,0,99,9q�5�      $��Bottom=�67   
���  ��$��13(�6c   6s   �� 5�   
   -   5        $��	btnQuitar��5�   A   $��Right=�6   $��
0,0,26,173q�6-   $��43��6R   $��30��6u   $��Bottom=�6�   $��7��6�   .��6�   Quitar6�   �� 5�   
   -   5        $��lblA2��5�   2   $��28��6   $��35,0,367,226q�6   $��Bottom=�6?   
���  ��$��13(�6k   6{   �� 5�   
   -   5        $��lblA3��5�   2   $��28��6   $��211,248,61,0q�6   $	��Top=�6?   
���  ��$��13(�6h   6x   �� 5�   
   -   5        $��
lblAvisos2��5�   1   $��28��6   $��34,0,79,175q�6   $��Bottom=�6C   
���  ��$��13(�6o   6   �� 5�   
   -   5        $��label1��5�   1   $��46��6   $��20,286,61,0q�6   $	��Top=�6?   $��20(�6W   .��6e   Registro de pedidos6z   �� 5�   
   -    5        $��image1��5�   K   $��71��6   $��Right=�6   $��	0,59,26,0q�68   $-��'/data/images/001_shoppingcart_empty.png��6Y   $
��Fill=�6�   $	��Top=�6�   $��90��6�   5�      ��5�      �� 5�   
   $ 0.939,0.919&�6   $	 0.061,0.081&�65   .��5�      � $
 	#FFFFE07E��6   $ 0Q�6-   � 5�      $
 	#FFFFFAEA��6   $ 1Q�6-   5�      5�      