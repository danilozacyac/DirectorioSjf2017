   M S B A M L   `   `   `  ����D  @PadronApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullL4clr-namespace:PadronApi.Converter;assembly=PadronApiPadronApi.Converter  5      L HDirectorioSjf2017, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DirectorioSjf2017.ConverterDirectorioSjf2017.Converter 5      A   ;DirectorioSjf2017.Formularios.Funcionarios.AgregaEncargados   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      H DMahApps.Metro, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null9Custom,http://metro.mahapps.com/winfx/xaml/controls  5      D	converter4clr-namespace:PadronApi.Converter;assembly=PadronApi  5      9	orgConver)clr-namespace:DirectorioSjf2017.Converter  5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m	 iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation   	 
    5      -   5        $	��800��5	      $	��400��5
      $��Agregar encargado��5      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5      (  "Telerik.Windows.Controls.RadWindow   WindowStartupLocation$ CenterScreen=�5       � 	Resources 5      4  .DirectorioSjf2017.Converter.OrganismoConverter   orgConv*   $PadronApi.Converter.TextValConverter  textConv*   $PadronApi.Converter.FuncionConverter  funcConv��%W   &	        &	      &	 &       5   
   6'     5   
   6%     5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   � -   5         �Name$ PanelPrincipal��5      .+�5      �� $	��270��5      $��
15,31,15,0q�5      $��Stretch=�5      $	��Top=�5      $��Datos Personales��5      .��5       � .+�5!      �� $��
16,107,0,0q�5"      $
��Left=�5#      $	��Top=�5$      $��
Apellidos:��5%      �� 5&      -   5         ��Name$ TxtApellidos��5'      $	��437��5(      $��23��5)      $��103,107,-2,0q�5*      $
��Left=�5+      $	��Top=�5,       �� TextWrapping$
 Wrap=�5/      $��3��6-   ��5.      �� *	Apellidos+ �� 	Converter# [ 5/   -   �� 50      $��
16,159,0,0q�51      $
��Left=�52      $	��Top=�53      $��
Nombre(s):��54      �� 55      -   5        $ 	TxtNombre��56      $	��437��57      $��23��58      $��103,159,-2,0q�59      $
��Left=�5:      $	��Top=�5;      $
 Wrap=�5>      $��4��6-   ��5=      �� *Nombre+# [ 5>   -   *  $Telerik.Windows.Controls.RadComboBox  5?      -   5          Name$ CbxGrado��5@      $	��120��5A      $��
103,68,0,0q�5B      $
��Left=�5C      $	��Top=�5D      	 �� DisplayMemberPath$	 
TituloDesc��5E      
 �� SelectedValuePath$
 IdTitulo��5G      $��2��66   ��5F      �� 5G   6   �� 5H      $��	35,64,0,0q�5I      $
��Left=�5J      $	��Top=�5K      $��Título:��5L      )  #MahApps.Metro.Controls.ToggleSwitch  5M      -   5          Name$ TbGenero��5N      $��	35,10,0,0q�5O      $
��Left=�5P      $	��Top=�5Q      $��Genero       ��5S      $��12(�5T         	IsChecked$
 TrueY�5U      $��1��5V   8   �� 5W      -   5         ��Name$ ImGenero��5X      $��32��5Y      $��35��5Z      $��
181,10,0,0q�5[      $
��Left=�5\      $	��Top=�5]      $��Resources/female_128.png��5^      5_      5`      5a      �� 5b   
   -   5         ��Name$ BtnSalir��5c      $��1��5d      $��80��5e      $��30��5f      $��	0,10,20,0q�5g      $��Right=�5h      $	��Top=�5i      $��Cancelar��5k        
BlueButton#��[ 5l      $��6��61   �� 5m   
   -	   5        $ 
BtnGuardar��5n      $��1��5o      $��80��5p      $��30��5q      $��
0,10,105,0q�5r      $��Right=�5s      $	��Top=�5t      $��Guardar��5v      #��[ 5w      $��5��61   5z      5{      