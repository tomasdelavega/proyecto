   M S B A M L   `   `   `  ����   ClienteFisio0    *ClienteFisio.Interfaz.Pacientes.VHistorial   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Icon$"  /data/images/Application.png�� � Title$ Diagnóstico��$	��719��$	��628�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � DataContext ��  �� RelativeSource �� *Self+����  �� EndPoint$ 0.939,0.919&� �� 
StartPoint$ 0.061,0.081&�.���  � Color$ 	#FFFFE07E��	 � Offset$	 0Q�� $ 	#FFFFFAEA��$	 1Q�
 � 	Resources
    
BlueHeader �� Orientation��%�   &	        �� .R��� $ 
Horizontal=�$��-5,-5,-5,-5q�$
��1000������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF223B84��$	 1Q�� $ 	#FF57A0F4��$		 0.5Q�� $ 	#FF4B94EC��$		 0.5Q�.+��� $��10,10,10,10q�$��Center=�
����������� .��� .+��� -   $��listViewTrat��  CustomerTemplate#���  $��27,0,27,110q�$	��145��$��Bottom=����� *TratCollection+ �� View �� .P���  �� Width$	 180��$��Terapia�� �� HeaderTemplate# [   �� DisplayMemberBinding �� *	Terapia+�� $	 150��$��Estado��# [   �� *Estado+�� $	 120��$��Fcha Inicio��# [   �� *FIni+�� $	 120��$��Fcha Fin��# [   �� *FFin+���� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$	 0Q�� $ 	#FFFFFAEA��$	 1Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$	 0.986Q�� $ 	#FFF4E057��$		 0.5Q�� $ 	#FFF4E057��$
	 0.51Q��� -   $��	btnVolver��$��23��$��Right=�$��	0,0,22,12q�$��Bottom=�$��65��$��6��.��Volver�� -   $��lblTit��$��47��$��
12,14,12,0q�$	��Top=�$��30(�$��Center=��� -   $��label1��$��24��$
��Left=�$��
27,144,0,0q�$	��Top=�$��82��.��Fcha Inicio�� -   $��label2��$��24��$
��Left=�$��
27,174,0,0q�$	��Top=�$��82��.��
Fcha Fin�� -   $��label3��$��
27,204,0,0q�$
��Left=�$��82��$��24��$	��Top=�.��Observaciones�� -   $��txtObs��$��115,214,169,0q� �� AcceptsReturn .  �� 
AcceptsTab . $ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=�$	��159��$	��Top=�$��2���� -	   $��label4��$��24��$
��Left=�$��
27,114,0,0q�$	��Top=�$��82��.��Zona�� -
   $��lbldiagnostico��$��47��$��12,61,202,0q�$	��Top=�$��20(��� -   $��	lblEstado��$��47��$��	0,61,12,0q�$	��Top=�$��Right=�$	��184��$��20(�$��Right=��� -   $��
lblTitTrat��$��33��$��24,0,22,261q�$��Bottom=�$��18(�.��Tratamientos�� -   $��	lblAvisos��$��28��$��12,0,127,72q�$��Bottom=�$��15(�
���  ���� -   $��
btnAñadir��$��24��$��Right=�$��	0,0,27,72q�$��Bottom=�$��65��$��5��.��	Añadir�� -   $��	btnCerrar��$��50��$��Right=�$��
0,118,12,0q�$	��Top=�$	��126��$��3��.��Finalizar diagnóstico�� -   $��btnModif��$��Right=�$��0,340,74,318q�$��75��$��4��.��	Modificar�� -   $��txtZona��$��23��$
��Left=�$��115,115,0,0q�$	��Top=�$	��186��$��1���� -   $��txtFini��$��23��$
��Left=�$��115,146,0,0q�$	��Top=�$	��113��{�.  �� -   $��txtFFin��$��23��$
��Left=�$��115,174,0,0q�$	��Top=�$	��113��{�.  