   M S B A M L   `   `   `  ����   ClienteFisio-    'ClienteFisio.Interfaz.Empleados.VFisios   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Icon$)  #/data/images/Medical  Student 2.png�� � Title$ Plantilla de empleados��$	��688��$	��548�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � DataContext ��  �� RelativeSource �� *Self+ � 	Resources    
BlueHeader �� Orientation �� EndPoint	 �� 
StartPoint
 � Color � Offset��%�   &	        �� .R��� $ 
Horizontal=�$��-5,-5,-5,-5q�$	��500������ $ 0.5,1&�$	 0.5,0&�.��� $
 	#FF223B84��$ 1Q�� $
 	#FF57A0F4��$	 0.5Q�� $
 	#FF4B94EC��$	 0.5Q�.+��� $��10,10,10,10q�$��Center=�
����������� .��� $	��685��.+��� -   $��	txtNombre��$��24��$��153,232,44,0q�$	��Top=�$��2���� -   $��	lblNombre��$��24��$��
42,232,0,0q�$	��Top=�$
��Left=�$	��105��.��	Nombre(*)�� -   $��lblApellidos��$��24��$��
42,260,0,0q�$	��Top=�$
��Left=�$	��105��.��Apellidos(*)�� -   $��txtApellidos��$��24��$��153,260,44,0q�$	��Top=�$��3���� -   $��lblDni��$��
42,204,0,0q�$��24��$
��Left=�$	��Top=�$	��105��.��DNI(*)�� -   $��txtDni��$��153,204,162,0q�$��24��$	��Top=�$��1���� -   $��lblTfno1��$��24��$
��Left=�$��
42,288,0,0q�$	��Top=�$	��105��.��	Teléfono�� -	   $��txtTfno��$��24��$��153,288,0,0q�$	��Top=�$��4��$
��Left=�$	��120���� -
   $��lblMovil��$��24��$��0,288,171,0q�$	��Top=�$��Right=�$��51��.��Movil�� -   $��txtMovil��$��24                  ��$��
0,288,44,0q�$	��Top=�$��Right=�$	��123��$��5���� -   $��txtEmail��$��24��$��153,0,44,317q�$��Bottom=�$��7���� -   $��lblEmail��$��24��$��
42,0,0,317q�$��Bottom=�$
��Left=�$	��105��.��eMail�� -   $��
btnGuardar��$��30��$��153,0,0,115q�$��Bottom=�$
��Left=�$��82��$��15��.��	Registrar�� -   $��	btnVolver��$��23��$��Right=�$��	0,0,12,45q�$��Bottom=�$��81��$��17��.��Volver�� -   $��	lblAvisos��$��26��$��
42,0,44,81q�$��Bottom=�$��13(�
���  ���� -   $��
lblSalario��$��24��$
��Left=�$��
42,0,0,289q�$��Bottom=�$	��105��.��
Salario(*)�� -   $��
txtSalario��$��24��$��153,0,253,289q�$��Bottom=�$��8���� -   $��
lblUsuario��$��24��$
��Left=�$��
42,0,0,260q�$��Bottom=�$	��105��.��
Usuario(*)�� -   $��txtus��$��24��$��153,0,253,261q�$��Bottom=�$��9���� -   $��lblPass��$��24��$��Right=�$��0,0,162,261q�$��Bottom=�$��85��.��Contraseña(*)G� -   $��txtPass��$��23��$��
0,0,44,261q�$��Bottom=�$��Right=�$	��114��$��10���� -   $��lblDerechos��$��28��$
��Left=�$��
42,0,0,229q�$��Bottom=�$	��105��.��
Derechos�� -   $��comboDerechos��$��23��$��153,0,253,234q�$��Bottom=�$��11���� -   $��lblTurno��$��25��$
��Left=�$��
42,0,0,200q�$��Bottom=�$	��105��.��Turno	� -   $��rMañana��$��16��$��
98,0,0,170q�$��Bottom=� 	� 	GroupName$ fisio��$��12��$
��Left=�$��63��.��	Mañana	� -   $��rTarde��$��16��$
��Left=�$��167,0,0,170q�$��Bottom=�$��54��$ fisio��$��13��.��Tarde	� -   $��	rCompleta��$��16��$��227,0,179,170q�$��Bottom=�$ fisio�� d� 	IsChecked$
 TrueY�$��14��.��Todo el día�� -   $��btnModif��$��30��$��0,0,127,115q�$��Bottom=�$��Right=�$��81��$��16��.��	Modificar�� -   $��btnEliminar��$��21��$��Right=�$��
0,173,12,0q�$	��Top=�$��64��.��
Eliminar�� -   $��lblNumC��$
��Left=�$��
42,316,0,0q�$	��105��$��24��$	��Top=�.��Nº colegiado(*)�� -    $��	txtNumCol��$��153,316,44,0q�$��24��$	��Top=�$��6���� -!   $��lblAvisios2��$��21��$��
98,66,78,0q�$	��Top=�
���  ���� -"   $��listVFisios��  CustomerTemplate#���  $��	12,4,12,0q�$	��164��$	��Top=����� *EmpCollection+ �� View �� .P���  �� Width$	 120��$	��DNI�� �� HeaderTemplate# [   �� DisplayMemberBinding �� *Dni+�� $	 197��$��Nombre��# [   �� *Nombre+�� $	 197��$��	Apellidos��# [   �� *	Apellidos+���� $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFFFC704��$ 0.986Q�� $
 	#FFF4E057��$	 0.5Q�� $
 	#FFF4E057��$
 0.51Q��� -#   $��label1��$��24��$��Right=�$��0,0,127,289q�$��Bottom=�$	��120��.��€���� $ 0.939,0.919&�$	 0.061,0.081&�.��� $
 	#FFFFE07E��$ 0Q�� $
 	#FFFFFAEA��$ 1Q�