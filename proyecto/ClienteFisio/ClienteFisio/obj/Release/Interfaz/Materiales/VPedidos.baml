   M S B A M L   `   `   `  ����   ClienteFisio/    )ClienteFisio.Interfaz.Materiales.VPedidos   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Icon$-  '/data/images/001_shoppingcart_empty.png�� � Title$ Pedidos��$	��737��$	��775�� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=� � DataContext ��  �� RelativeSource �� *Self+ � 	Resources    
BlueHeader �� Orientation �� EndPoint	 �� 
StartPoint
 � Color � Offset��%�   &	        �� .R��� $ 
Horizontal=�$��-5,-5,-5,-5q�$	��500������ $ 0.5,1&�$	 0.5,0&�.��� $
 	#FF223B84��$ 1Q�� $
 	#FF57A0F4��$	 0.5Q�� $
 	#FF4B94EC��$	 0.5Q�.+��� $��10,10,10,10q�$��Center=�
����������� .��� $	��701�� � ColumnDefinitions �� $
��216* ��� $
��537* �.+��� -   $��	btnVolver��$��23��$��Right=�$��	0,0,11,11q�$��Bottom=�$��75��$��10��$��1��.��Volver�� -   $��listPeds��$��
25,59,21,0q�$��74��$	��Top=�$��1������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q��� -   $��	lblPedido��$��42��$��	25,15,5,0q�$	��Top=�$��20(�.��Pedidos registrados�� -   $��	lblLinPed��$��26��$��211,31,302,0q�$	��Top=�$��13(�$��Right=�$��2��.��Materiales pedidos�� -   $��lblCant��$��23��$��211,189,0,0q�$	��Top=�$
��Left=�$	��153��$��2��.��Nº materiales adquiridos:�� -   $��	lblPrecio��$��28��$��211,213,0,0q�$	��Top=�$
��Left=�$	��153��$��2��.��Importe total del pedido:�� -   $��lblCant2��$��23��$��175,189,227,0q�$	��Top=�$��Right=�$��1���� -	   $��
lblPrecio2��$��23��$��175,213,227,0q�$	��Top=�$��Right=�$��1���� -
   $��btnEliminar��$��20��$
��Left=�$��
25,248,0,0q�$	��Top=�$��51��$��2��.��
Eliminar� -    �Name$ 
LayoutRoot��$��211,59,219,0q�$	��127��$	��Top=�$��2��.+��� -   $��listViewLinPRegs��  CustomerTemplate#���  $	��320��$
��Left=����� *PedidoCollectionRegs+ �� View �� .P���  �� Width$	 160��$��Material�� �� HeaderTemplate# [   �� DisplayMemberBinding �� *
Material+�� $ 80��$��Cantidad(uds)��# [   �� *
Cantidad+�� $ 80��$��Precio(€/ud)��# [   �� *Precio+�� $ 80��$��
Total(€)��# [   �� *Total+���� $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFFFC704��$ 0.986Q�� $
 	#FFF4E057��$	 0.5Q�� $
 	#FFF4E057��$
 0.51Q��� -   $��comboMat��$��23��$��34,0,73,269q�$��Bottom=�$��3������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q��� -   $��
lblAvisos3��$��20,0,358,26q�$��24��$��Bottom=�$��2���� -   $��listViewLinP��#���  $��187,0,26,212q�$	��138��$��Bottom=�$��1������ *PedidoCollection+ �� .P��� $ 80��$��Material��# [   �� *
Material+�� $ 80��$��Cantidad(uds)��# [   �� *
Cantidad+�� $ 80��$��Precio(€/ud)��# [   �� *Precio+�� $ 80��$��
Total(€)��# [   �� *Total+���� $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q����� " ��.���  � ��$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC P�  �@J�IsMouseOver . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFFFC704��$ 0.986Q�� $
 	#FFF4E057��$	 0.5Q�� $
 	#FFF4E057��$
 0.51Q��� -   $��	txtPrecio��$��23��$��182,0,0,269q�$��Bottom=�$
��Left=�$��42��$��4��$��2��.������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�.���� -   $��txtUds��$��23��$
��Left=�$��
42,0,0,269q�$��Bottom=�$��35��$��5��$��1��.������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�.���� -   $��
btnAñadir��$��28��$��111,0,0,269q�$��Bottom=�$��6��$��1��$
��Left=�$��59��.��	Añadir->�� -   $��
lblPrecio3��$��23��$
��Left=�$��	6,0,0,269q�$��Bottom=�$��35��$��1��.��€/ud�� -   $��lblCantidad��$��23��$
��Left=�$��
75,0,0,269q�$��Bottom=�$��32��$��1��.��Uds�� -   $��txtComentarios��$��
104,0,0,81q�$��59��$��Bottom=�$
��Left=�$	��260�� �� AcceptsReturn .  �� 
AcceptsTab . $��2��.������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�.���� -   $��lblComentarios��$��22��$
��Left=�$��104,0,0,142q�$��Bottom=�$	��120��$��2��.��Comentarios�� -   $��btnRegistrar��$��27.277��$��104,0,37,45.139q�$��Bottom=�$��9��.��	Registrar+  %Microsoft.Windows.Controls.DatePicker  6my-http://schemas.microsoft.com/wpf/2008/toolkit  -   $��
datePicker��$��27.277��$
��Left=�$��42,0,0,45.139q�$��Bottom=�$	��106��   Text$ Fecha de pedido��$��8��$��1������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q��� -   $
��lbl1��$��28��$��20,0,27,322q�$��Bottom=�.��!Adjunta los productos al pedido�� -   $��	lblAvisos��$��25                ��$��
104,0,99,9q�$��Bottom=�
���  ��$��13(�$��2���� -   $��	btnQuitar��$��Right=�$��
0,0,26,173q�$��43��$��30��$��Bottom=�$��7��$��1��.��Quitar�� -   $��lblA2��$��28��$��35,0,367,226q�$��Bottom=�
���  ��$��13(�$��2���� -   $��lblA3��$��28��$��211,248,61,0q�$	��Top=�
���  ��$��13(�$��2���� -   $��
lblAvisos2��$��28��$��34,0,79,175q�$��Bottom=�
���  ��$��13(�$��2���� -   $��label1��$��46��$��20,286,61,0q�$	��Top=�$��20(�$��2��.��Registro de pedidos�� -    $��image1��$��56��$��Right=�$��	0,96,26,0q�$-��'/data/images/001_shoppingcart_empty.png��$
��Fill=�$	��Top=�$��75��$��1���� -!   $��txtComs�� .  . $��86��$ �� HorizontalScrollBarVisibility$
 Auto=�{�.  �� 
IsReadOnly . $��25,150,21,0q� �� TextWrapping$
 Wrap=�$	��Top=�" �� VerticalScrollBarVisibility$
 Auto=�.������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�.���� -"   $��image2��$��56��$��Right=�$��
0,96,125,0q�$��/data/images/mats.png��$
��Fill=�$	��Top=�$��75��$��1������ $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�