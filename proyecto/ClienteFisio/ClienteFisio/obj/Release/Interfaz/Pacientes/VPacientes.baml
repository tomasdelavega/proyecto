   M S B A M L   `   `   `  ����   ClienteFisio0    *ClienteFisio.Interfaz.Pacientes.VPacientes   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Icon$  /data/images/people.png�� � Title$ 	Pacientes��$	��713��$	��671�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � DataContext ��  �� RelativeSource �� *Self+����  �� EndPoint$ 0.939,0.919&� �� 
StartPoint$ 0.061,0.081&�.���  � Color$ 	#FFFFE07E��	 � Offset$	 0Q�� $ 	#FFFFFAEA��$	 1Q�
 � 	Resources
    
BlueHeader �� Orientation��%�   &	        �� .R��� $ 
Horizontal=�$��-5,-5,-5,-5q�$
��1000������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF223B84��$	 1Q�� $ 	#FF57A0F4��$		 0.5Q�� $ 	#FF4B94EC��$		 0.5Q�.+��� $��10,10,10,10q�$��Center=�
����������� .��� .+��� -   $��listViewPac��  CustomerTemplate#���  $��32,58,185,0q�$	��124��$	��Top=����� *PacientesCollection+ �� View �� .P���  �� Width$	 180��$��	Apellidos�� �� HeaderTemplate# [   �� DisplayMemberBinding �� *	Apellidos+�� $	 150��$��Nombre��# [   �� *Nombre+�� $	 120��$	��DNI��# [   �� *Dni+���� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$	 0Q�� $ 	#FFFFFAEA��$	 1Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$	 0.986Q�� $ 	#FFF4E057��$		 0.5Q�� $ 	#FFF4E057��$
	 0.51Q��� -   $��btnAñadirPac��$��27��$��Right=�$��	0,58,92,0q�$	��Top=�$��87��.��Nuevo Paciente�� -   $��	btnVolver��$��23��$��	0,0,12,11q�$��Bottom=�$��Right=�$��63��.��Volver�� -   $��lblTfno��$
��Left=�$��
32,188,0,0q�$��66��$��24��$	��Top=�.��
Teléfono:�� -   $��lblTfno2��$��24��$��115,188,303,0q�$	��Top=��� -   $��lblMovil��$��24��$
��Left=�$��
32,213,0,0q�$	��Top=�$��66��.��Movil:�� -   $��	lblMovil2��$��24��$��115,213,293,0q�$	��Top=��� -	   $��lblMail��$��24��$
��Left=�$��
32,236,0,0q�$	��Top=�$��66��.��eMail:�� -
   $��	lblEmail2��$��24��$��115,236,293,0q�$	��Top=��� -   $��lblFnac��$
��Left=�$��
32,261,0,0q�$��66��$��23��$	��Top=�.��	Fcha nto:�� -   $��lblfe2��$��115,261,293,0q�$��23��$	��Top=��� -   $��	lblAvisos��$��29��$��166,21,185,0q�$	��Top=�$��Right=�$��15(�
���  ���� -   $��btnEliminar��$��Right=�$��0,188,187,0q�$��53��$��24��$	��Top=�.��
Eliminar�� -   $��btnModificar��$��0,188,247,0q�$��24��$	��Top=�$��Right=�$��53��.��	Modificar�� -   $��listViewHist��#���  $��32,0,12,131q�$	��121��$��Bottom=����� *HistCollection+ �� .P��� $	 150��$��Diagnóstico��# [   �� *Diagnostico+�� $	 140��$
��Zona��# [   �� *Zona+�� $	 100��$��Estado��# [   �� *Estado+�� $	 112��$��Fcha Inicio��# [   �� *	FInicio+�� $	 112��$��Fcha Fin��# [   �� *FFin+���� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$	 0Q�� $ 	#FFFFFAEA��$	 1Q����� " ��.���  � ��$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC P�  �@J�IsMouseOver . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$	 0.986Q�� $ 	#FFF4E057��$		 0.5Q�� $ 	#FFF4E057��$
	 0.51Q��� -   $��
lblHistTit��$��33��$��32,0,102,259q�$��Bottom=�$��20(��� -   $��
lblAvisos2��$��28��$��
32,0,12,46q�$��Bottom=�$��Center=�
���  ��$��15(��� -   $��txtObsPaciente��$��32,316,293,0q� �� AcceptsReturn .  �� 
AcceptsTab . $ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=�{�.  �� 
IsReadOnly . $��57��$	��Top=��� -   $��lblObsPaciente��$��24��$��
32,285,0,0q�$	��Top=�$
��Left=�$��89��.��Observaciones:�� -   $��btnAgregarHist��$��39��$
��Left=�$��	32,0,0,82q�$��Bottom=�$	��107��.��Diagnosticar�� -   $��label1��$��39��$��32,11,187,0q�$	��Top=�$��25(�.��	Pacientes�� -   $��image1��$"��/data/images/Application.png��$��Right=�$��
0,0,12,259q�$
��Fill=�$��76��$��57��$��Bottom=�