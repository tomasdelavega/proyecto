   M S B A M L   `   `   `  ����   ClienteFisio$    ClienteFisio.Interfaz.VCuentas   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Icon$  /data/images/vault.png�� � Title$ Cuentas��$	��755��$	��726�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=� � DataContext ��  �� RelativeSource �� *Self+����  �� EndPoint$ 0.939,0.919&� �� 
StartPoint$ 0.061,0.081&�.���  � Color$ 	#FFFFE07E��	 � Offset$	 0Q�� $ 	#FFFFFAEA��$	 1Q�
 � 	Resources
    
BlueHeader �� Orientation��%�   &	        �� .R��� $ 
Horizontal=�$��-5,-5,-5,-5q�$
��1000������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF223B84��$	 1Q�� $ 	#FF57A0F4��$		 0.5Q�� $ 	#FF4B94EC��$		 0.5Q�.+��� $��10,10,10,10q�$��Center=�
����������� .��� .+��� -   $��	btnVolver��$��23��$��Right=�$��0,0,15,8q�$��Bottom=�$��75��.��Volver�� -   $��listViewLinP��$	��110��  CustomerTemplate#���  $��
0,0,15,139q�$��Bottom=�$��Right=�$	��313������ *PedidosCollection+ �� View �� .P���  �� HeaderTemplate# [   �� Width$	 120�� �� DisplayMemberBinding �� *Fecha+.��Fecha�� # [  $ 73�� �� *Id+.��Id�� # [  $	 120�� �� *Total+.��
Total(€)���� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$	 0Q�� $ 	#FFFFFAEA��$	 1Q�����  �� 
TargetType" �� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� Property � �� �� Value
 ��  ���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$	 0.986Q�� $ 	#FFF4E057��$		 0.5Q�� $ 	#FFF4E057��$
	 0.51Q�.���  � ��$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC�� -   $��	listViewE��$	��110��$��Right=�#���  $��
0,236,15,0q�$	��Top=�$	��311������ *EmpCollection+ �� .P��� # [  $	 190�� �� *
Empleado+.��
Empleado�� # [  $	 123�� �� *	Salario+.��Salario(€)���� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$	 0Q�� $ 	#FFFFFAEA��$	 1Q����� " �� P�  �@J�IsMouseOver . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$	 0.986Q�� $ 	#FFF4E057��$		 0.5Q�� $ 	#FFF4E057��$
	 0.51Q�.���  � ��$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC�� -   $��	listViewS��$	��110��$
��Left=�#���  $��
12,0,0,139q�$��Bottom=�$	��313������ *SCollection+ �� .P��� # [  $	 130�� �� *
Paciente+.��
Paciente�� # [  $ 93�� �� *	Importe+.��Importe(€)�� # [  $ 90�� �� *Pagado+.��Pagado���� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$	 0Q�� $ 	#FFFFFAEA��$	 1Q����� " �� P�  �@J�IsMouseOver . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$	 0.986Q�� $ 	#FFF4E057��$		 0.5Q�� $ 	#FFF4E057��$
	 0.51Q�.���  � ��$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC�� -   $��
lblAvisosP��$��13(�
���  ��$��28��$��	0,0,15,32q�$��Bottom=�$��Right=�$	��311���� -   $��
lblAvisosE��$��13(�
���  ��$��Right=�$��
0,0,17,301q�$	��311��$��28��$��Bottom=��� -   $��
lblAvisosS��$��13(�
���  ��$��28��$
��Left=�$��9,0,0,32q�$��Bottom=�$	��313���� -	   $��label1��$��28��$��0,0,138,100q�$��Bottom=�$��Right=�$	��190��.��Nº de pedidos:�� -
   $��label2��$��28��$��
0,0,138,66q�$��Bottom=�$��Right=�$	��190��.��%#Importe total de todos los pedidos:�� -   $��lblNPedidos��$��28��$��Right=�$��Right=�$��
0,0,15,100q�$��Bottom=�$	��117���� -   $��lblImpTotPedidos��$��28��$��Right=�$��Right=�$��	0,0,15,66q�$��Bottom=�$	��117���� -   $��label3��$��Right=�$��0,360,219,0q�$	��107��$��25��$	��Top=�.��Total salarios:�� -   $��lblTotSalarios��$��Right=�$��Right=�$��
0,0,15,332q�$	��122��$��25��$��Bottom=��� -   $��label4��$��28��$
��Left=�$��	12,0,0,96q�$��Bottom=�$	��188��.��%#Importe total sesiones no cobradas:�� -   $��label5��$��28��$
��Left=�$��	12,0,0,66q�$��Bottom=�$	��188��.��" Importe total sesiones cobradas:�� -   $��lblSesCobradas��$��28��$
��Left=�$��Right=�$��
200,0,0,66q�$��Bottom=�$	��120���� -   $��lblSesNoCobradas��$��28��$
��Left=�$��Right=�$��
206,0,0,96q�$��Bottom=�$	��114���� -   $��label6��$��16(�$��34��$��0,0,102,251q�$��Bottom=�$��Right=�$	��224��.��	Pedidos�� -   $��label7��$��16(�$��34��$��Right=�$��0,197,102,0q�$	��Top=�$	��224��.��	Empleados�� -   $��label8��$��11(�$��25��$
��Left=�$��
12,245,0,0q�$	��Top=�$	��111��.��Gastos�� -   $��label9��$��28(�$��46��$��208,12,15,0q�$	��Top=�$
��Left=��� -   $��	lblGastos��$��25��$
��Left=�$��Right=�$��203,245,0,0q�$	��Top=�$	��120���� -   $��label10��$��11(�$��25��$
��Left=�$��
12,214,0,0q�$	��Top=�$��96��.��	Ingresos:�� -   $��lblIngresos��$��25��$
��Left=�$��Right=�$��203,214,0,0q�$	��Top=�$	��120���� -   $��label11��$��28��$
��Left=�$��
12,276,0,0q�$	��Top=�$	��120��.��Otros gastos:�� -   $��textBox1��$��23��$
��Left=�$��200,276,0,0q�$	��Top=�$��96���� -   $��label12��$��23��$
��Left=�$��302,276,0,0q�$	��Top=�$��24��$��Right=�.��€�� -   $��label13��$��11(�$
��Left=�$��12,340,0,352q�$��96��.��Resultados:�� -   $��	lblResult��$
��Left=�$��Right=�$��203,340,0,352q�$	��120���� -   $��label14��$��16(�$��34��$
��Left=�$��
12,0,0,251q�$��Bottom=�$	��224��.��
Sesiones�� -    $��button1��$��19��$
��Left=�$��238,305,0,0q�$	��Top=�$��58��.��
Recalcular�� -!   $��label17��$��28��$��217,64,15,0q�$	��Top=�$��Center=�$��13(�
���  ��)  #Microsoft.Windows.Controls.Calendar  6my-http://schemas.microsoft.com/wpf/2008/toolkit  -"   $��	calendar1��$	��170��$��	12,12,0,0q�$	��Top=�$
��Left=�$	��180��   DisplayMode$
 Year=�   SelectionMode$ 
SingleDate=��� -#   $��image1��$��/data/images/vault.png��$��74��$
��Left=�$��
217,98,0,0q�$
��Fill=�$	��Top=�$	��109��