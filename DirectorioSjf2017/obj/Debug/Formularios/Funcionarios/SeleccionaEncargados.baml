   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5      D @PadronApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullL4clr-namespace:PadronApi.Converter;assembly=PadronApiPadronApi.Converter 5       DirectorioSjf2017E   ?DirectorioSjf2017.Formularios.Funcionarios.SeleccionaEncargados   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      J	converter4clr-namespace:PadronApi.Converter;assembly=PadronApi     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m	 iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation   	 
    5      -   5        $	��700��5      $	��450��5	      $��Selecccionar Funcionarios��5
      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5      (  "Telerik.Windows.Controls.RadWindow   WindowStartupLocation$ CenterScreen=�5       � 	Resources 5      )  #PadronApi.Converter.TituloConverter   
tituloConv��%   &	          5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��45 �6   .+�5   
   � -   5         �Name$ 
GridBuscar��5      .+�5         UIControls.SearchTextBox  -   5        $	��382��5      $��	75,15,0,0q�5      $
��Left=�5      $	��Top=�5         	LabelText$&  Buscar por nombre y apellidos...��5       5!      �� 5#      $��	10,10,0,5q�5$      $
��Left=�5%      $	��Top=�5&      $��Buscar:��5'      $��14(�5(      $��Black"�5)      5*      *  $Telerik.Windows.Controls.RadGridView  5,   
   -   5          Name$ 
GTitulares��5-      $��1��5.      $	��290��5/      $��Stretch=�50      $��Stretch=�51      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     EnableRowVirtualization . $��14(�54      	   IsFilteringAllowed	 .  
   
IsReadOnly
 .    ShowGroupPanel .  * 
 $Telerik.Windows.Controls.DataControl   ItemsSource 57      ��    Columns 5:      1  +Telerik.Windows.Controls.GridViewDataColumn  5<      -	  'Telerik.Windows.Controls.GridViewColumn 	  Width?
  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 80
 5=      6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Título��5?         DataMemberBinding 5>      �� *
IdTitulo+ �� 	Converter# [  5?        5@      $	 .7*
 5A      $ Nombre��5C       5B      �� *Nombre+5C        5D      $	 .8*
 5E      $ 	Apellidos��5G       5F      �� *	Apellidos+5G      5I      � 5K   
   $��2��6    � ColumnDefinitions 5L      �� 5M      $
��Auto �6#   �� 5N      $��* �6#   .+�5Q      �� -   5         ��Name$ LstTipoObra��5R      $��15,55,15,10q�5S      $��Stretch=�5T      $��Stretch=�5U      $y�	Collapsed=�5W      ��5V      �� ��5X      �� 5Y      .R�5Z      �� ��6#   �� *Descripcion+ d� 	IsChecked 6C   �� *	IsChecked+ �� Mode$ TwoWay=�5[      5]      �� 5^      $��	15,30,0,0q�5_      $
��Left=�5`      $	��Top=�5a      $��Obras que recibe:��5b      $
��Bold"�5c      $y�	Collapsed=�5d      �� 5e      $��1��5f      $��15,0,0,0q�5g      $
��Left=�5h      $	��Top=�5i      $��	Función:��5j      *  $Telerik.Windows.Controls.RadComboBox  5k      -   5          Name$ CbxFunciones��5l      $��1��5m      $��2��5n      $	��250��5o      $��74,3,0,0q�5p      $
��Left=�5q      $	��Top=�5r       �� DisplayMemberPath$ Descripcion��5s         
IsEditable .  �� IsTextSearchEnabled .  �� SelectedValuePath$ 
IdElemento��5w         TextSearchMode$ Contains=�5x      ��5v      �� 5x   +   5z      �� 5|   
   -   5         ��Name$ BtnSalir��5}      $��3��5~      $��80��5      $��	0,14,10,0q�5�      $��Right=�5�      $	��Top=�5�      $��Salir��5�        
BlueButton#��[ 5�      �� 5�   
   -   5        $ 
BtnGuardar��5�      $��3��5�      $��80��5�      $��	0,14,95,0q�5�      $��Right=�5�      $	��Top=�5�      $��Agregar��5�      #��[ 5�      �� 5�   
   -	   5        $��Nuevo encargado��5�      #��[ 6+   $
��Left=�6O   $��	10,14,0,0q�6j   $��3��6}   $	��Top=�6�   $	��130��6�   6�   5�      5�      