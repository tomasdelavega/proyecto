   M S B A M L   `   `   `  ����   ClienteFisio2    ,ClienteFisio.Interfaz.Pacientes.VTratamiento   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Icon$"  /data/images/Application.png�� � Title$ Tratamiento��$	��686��$	��565�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � DataContext ��  �� RelativeSource �� *Self+����  �� EndPoint$ 0.939,0.919&� �� 
StartPoint$ 0.061,0.081&�.���  � Color$ 	#FFFFE07E��	 � Offset$	 0Q�� $ 	#FFFFFAEA��$	 1Q�
 � 	Resources
    
BlueHeader �� Orientation��%�   &	        �� .R��� $ 
Horizontal=�$��-5,-5,-5,-5q�$
��1000������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF223B84��$	 1Q�� $ 	#FF57A0F4��$		 0.5Q�� $ 	#FF4B94EC��$		 0.5Q�.+��� $��10,10,10,10q�$��Center=�
����������� .��� .+��� -   $��	btnVolver��$��23��$��Right=�$��	0,0,12,12q�$��Bottom=�$��75��.��Volver�� -   $��listViewSes��  CustomerTemplate#���  $��65,0,271,48q�$	��180��$	��175��$��Bottom=����� *SesCollection+ �� View �� .P���  �� Width$	 120��$��Fecha�� �� HeaderTemplate# [   �� DisplayMemberBinding �� *Fecha+�� $ 60��$��Pagado��# [   �� *Pagado+���� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$	 0Q�� $ 	#FFFFFAEA��$	 1Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ 24����  � �� �	#5EF4E057��  � �� �	#FF4B94EC �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ��  ���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$	 0.986Q�� $ 	#FFF4E057��$		 0.5Q�� $ 	#FFF4E057��$
	 0.51Q��� -   $��	lblavisos��$��28��$��
32,0,97,12q�$��Bottom=�$��15(�
���  ���� -   $��lblTit��$��48��$��
32,17,26,0q�$	��Top=�$��25(�$��Center=��� -   $��lblDiagnostico��$��43��$��
32,88,26,0q�$	��Top=�$��19(��� -   $��
lblTerapia��$��43��$��32,132,271,0q�$	��Top=�$��19(��� -   $��label1��$��28��$
��Left=�$��
65,256,0,0q�$	��Top=�$��83��.��Observaciones�� -	   $��textBox1��$��152,256,138,266q� �� AcceptsReturn .  �� 
AcceptsTab . $ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=��� -
   $��	lblEstado��$��43��$��Right=�$��
0,132,26,0q�$	��Top=�$	��239��$��19(�$��Right=��� -   $��btnModif��$��23��$��Right=�$��
0,254,53,0q�$	��Top=�$��75��.��	Modificar�� -   $��label2��$��33��$��
65,0,0,228q�$��Bottom=�$��18(�$
��Left=�$	��188��.��
Sesiones�� -   $��button1��$��67��$��Right=�$��
0,0,53,156q�$��Bottom=�$	��136��.��Finalizar tratamiento�� -   $��	comboBox1��$��23��$��Right=�$��
0,0,53,128q�$��Bottom=�$	��136���� -   $��label3��$��28��$
��Left=�$��
65,188,0,0q�$	��Top=�$��83��.��Fcha Inicio�� -   $��label4��$��28��$
��Left=�$��
65,220,0,0q�$	��Top=�$��83��.��
Fcha Fin�� -   $��txtFIni��$��23��$
��Left=�$��152,190,0,0q�$	��Top=�$	��120���� -   $��txtffin��$��23��$
��Left=�$��152,222,0,0q�$	��Top=�$	��120��{�.  