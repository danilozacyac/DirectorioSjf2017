   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5       DirectorioSjf2017E   ?DirectorioSjf2017.Formularios.Funcionarios.SeleccionaOrgAdscrip   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a	 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e
 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
   5      -   5        $	��700��5      $	��480��5      $*��$Selecciona organismo de adscripción��5	      (  "Telerik.Windows.Controls.RadWindow    WindowStartupLocation$  CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $
��Auto �6   �� 5      $��60 �6   �� 5      $��50 �6   .+�5   
      UIControls.SearchTextBox  -   5          Name$ 	SearchBox��5      $��0��5      $	��250��5      $��25��5      $��25,5,0,0q�5      $
��Left=�5      $	��Top=�5         	LabelText$ Buscar organismo...��5       �� TextWrapping$
 Wrap=�5      � 5   
   -   5         �Name$ PanelOrganismo��5       $��1��5!      $	��290��5"      .+�5#      *  $Telerik.Windows.Controls.RadGridView  -   5          Name$ GOrganismos��5$      $��1��5%      $��	25,0,25,0q�5&      $��Stretch=�5'      $��Stretch=�5(      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     EnableRowVirtualization . 	   
IsReadOnly	 . 
   ShowGroupPanel
 .  * 	 $Telerik.Windows.Controls.DataControl   ItemsSource 5,      ��    Columns 5/      1  +Telerik.Windows.Controls.GridViewDataColumn  51      -  'Telerik.Windows.Controls.GridViewColumn   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ * 52      6	  0Telerik.Windows.Controls.GridViewBoundColumnBase 	  Header$ 	Organismo��54       	  DataMemberBinding 53      �� *OrganismoDesc+54      56      58      � 5:   
   $��2��6    � ColumnDefinitions 5;      �� 5<      $
��Auto �6#   �� 5=      $��* �6#   .+�5B      �� -   5         ��Name$ LstTipoObra��5C      $��15,55,15,10q�5D      $��Stretch=�5E      $��Stretch=�5F      $y�	Collapsed=�5H      ��5G      �� ��5I      �� 5J      .R�5K      �� ��6#   �� *Descripcion+ d� 	IsChecked 6C   �� *	IsChecked+ �� Mode$ TwoWay=�5L      5N      �� 5O      $��	15,30,0,0q�5P      $
��Left=�5Q      $	��Top=�5R      $��Obras que recibe:��5S      $
��Bold"�5T      $y�	Collapsed=�5U      *
  $Telerik.Windows.Controls.RadComboBox
  5V      -   5         
 Name$ CbxFunciones��5W      $��1��5X      $	��250��5Y      $��	88,20,0,0q�5Z      $
��Left=�5[      $	��Top=�5\       �� DisplayMemberPath$ Descripcion��5]       
  
IsEditable .  
  IsFilteringEnabled .  �� SelectedValuePath$ 
IdElemento��5a       
  TextSearchMode$ Contains=�5b      ��5`      �� 5b      �� 5c      $��1��5d      $��	29,16,0,0q�5e      $
��Left=�5f      $	��Top=�5g      $��	Función:��5h      5j      �� 5n   
   -   5         ��Name$ BtnCancelar��5o      $��3��5p      $��80��5q      $��	0,10,28,0q�5r      $��Right=�5s      $	��Top=�5t      $��Cancelar��5v       �� IsCancel .    
BlueButton#��[  5x      �� 5y   
   -   5        $ 
BtnGuardar��5z      $��3��5{      $��80��5|      $��
0,10,113,0q�5}      $��Right=�5~      $	��Top=�5      $��Guardar��5�      #��[  5�      5�      5�      