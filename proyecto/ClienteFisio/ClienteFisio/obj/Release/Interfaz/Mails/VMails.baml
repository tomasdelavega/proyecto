   M S B A M L   `   `   `  ����   ClienteFisio(    "ClienteFisio.Interfaz.Mails.VMails   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    -   $	��clo��  � Icon$!  /data/images/Edit Email.png�� � Title$% Envío de correos electrónicos��$	��564��$	��600�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� .+��� -   $��lblDestinatarios��$��24��$��	12,12,0,0q�$	��Top=�$
��Left=�$��78��.��Destinatarios�� -   $��	lblAsunto��$��24��$��
27,0,0,186q�$
��Left=�$��82��$��Bottom=�.��Asunto�� -   $��lblTexto��$��
27,0,0,155q�$
��Left=�$��82��$��25��$��Bottom=�.��Texto a enviar�� -   $��	txtAsunto��$��124,0,41,186q�$��24��$��Bottom=�$��1���� -   $��
separator1��$��5��$��	0,0,0,216q�$��Bottom=�	� -   $��
radioTodos��$��16��$
��Left=�$��	38,45,0,0q�$	��Top=�$	��130�� 	� 	GroupName$
 dest��$��5��.��Para todos los clientes	� -   $��radioElegirDest��$��16��$
��Left=�$��	38,67,0,0q�$	��Top=�$	��120��$
 dest�� d� 	IsChecked$ FalseY�$��6�� � BindingGroup &   System.Windows.Data.BindingGroup     NotifyOnValidationError .     Name Z� .��Elegir clientes�� -	   $��canvasDestinatarios��$��56,90,0,227q�.+��� -
   $��	lblElegir��	 �� Left$	 0��

 �� Top$
 25��$��28��$	��259��.��64Elige los clientes a quienes deseas enviar el correo�� -   $��	comboDest��$	 18��$
 82��$��23��$	��199��$��8������  �� EndPoint$ 0.939,0.919&� �� 
StartPoint$ 0.061,0.081&�.���  � Color$ 	#FFFFE07E�� � Offset$ 0Q�� $ 	#FFFFFAEA��$ 1Q��� -   $��
btnAgregar��$		 230��$
 69��$��24��$��58��$��9��.��	Agregar->�� -   $��listDestinatarios��$		 299��$
 50��$	��100��$	��182������ $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$ 0Q�� $ 	#FFFFFAEA��$ 1Q��� -   $��btnEliminar��$		 230��$	
 102��$��24��$��58��$��10��.��
<-Quitar�� -   $��	btnEnviar��$��28��$��	0,0,41,59q�$��Bottom=�$��3��$��Right=�$��94��.��Enviar�� -   $��txtConte��$��84��$��124,0,41,94q�$��Bottom=� �� TextAlignment$
 Left=� �� AcceptsReturn .  �� 
AcceptsTab . $ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=�$��2���� -   $��	btnVolver��$��28��$��Right=�$��	0,0,16,12q�$��Bottom=�$��68��$��4��.��Volver�� -   $��	lblAvisos��$��28                ��$��158,0,92,12q�$��Bottom=�$��15(�
���  ��$��Center=��� -   $��image1��$��71��$��Right=�$��	0,12,16,0q�$!��/data/images/Edit Email.png��$
��Fill=�$	��Top=�$��76���� -   $��btnAdjuntar��$��23��$
��Left=�$��	27,0,0,58q�$��Bottom=�$��75��.��
Adjuntar�� -   $��textBoxRuta��$��22��$
��Left=�$��
124,0,0,59q�$��Bottom=�$	��161������ $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$ 0Q�� $ 	#FFFFFAEA��$ 1Q�