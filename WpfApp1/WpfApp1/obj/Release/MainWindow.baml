   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1       � Title$  
MainWindow��$	��350��$	��525�� � 	Resources    
LabelStyle �� 
TargetType �� Property �� Value  GridViewHeaderStyle  	itemStyle �� Triggers P� Property P� Value��%�   &	        &	 %     &	 z     �� " ��.���  � ��$
 Bold"��� " ��.���  � ��$
 Bold"���  � ��
 �  ����  � ��
 ��·��� " �� P�  �@J�IsKeyboardFocusWithin . . ���  �@��
IsSelected . .���  � RowDefinitions �� $
��Auto ��� $��40 ��� $��40 ��� $��30 ��� $��* �.+�o� $��0�����	#FF8883FF$��Italic$�$
��Bold"�$��14(�.@�m� $��_File��.@�m� $��E_xit��	 m� InputGestureText$	 Ctrl-X��
 m� Command
 �� *ExitCommand+� $��2�����	#FF8B9BFF.+���  �� Orientation$ 
Horizontal=�.+��� #��[  $��Italic$�$��0,10,0,0q�$��41���� $
�Name���� ���	#FFB5EBFF$��93��$��0,10,0,0q�$��20��$	��Top=����� *HumanNameToAdd+ �� Mode$ OneWayToSource=�.���� #��[  $��Italic$�$��55��$��0,10,0,0q�$�� Surname���� ���	#FFBCEDFF$��94��$
��0,10q����� *HumanSurnameToAdd+$ OneWayToSource=�.���� #��[  $��Italic$�$��37��$��0,10,0,0q�$��    Sex���� ���	#FFB2EAFF$��78��$
��0,10q����� *HumanSexToAdd+$ OneWayToSource=�.���� #��[  $��Italic$�$��34��$��0,10,0,0q�$��   Age���� ���	#FFB2EAFF$��58��$
��0,10q����� *HumanAgeToAdd+$ OneWayToSource=�.���� -    ��Name$ btnAddHuman��$��3��$	��Add�����	#FF9C8CFF$
��Bold"����� *
AddHuman+�� -    ��Name$ listMyItems��$��5��
�������#��[ $��Stretch=�$��5,5,5,10q�$��Italic$�$
��Bold"����� *Humans+ �� SelectedItem �� *SelectedItem+����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFEEFFA1�� � Offset$ 0Q�� $ 	#FF9FE9FF��$ 1Q� �� View �� .P��� $
��Name�� �� Width$	 120�� �� HeaderContainerStyle# [  �� DisplayMemberBinding �� *Name+�� $��Surname��$	 120��# [  �� *	Surname+�� $	��Sex��$	 100��# [  �� *Sex+�� $	��Age��$	 100��# [  �� *Age+�� $ 51��# [  �� CellTemplate �� .R��� $ btnRemoveBody��$��X�����	#FF9C8CFF$
��Bold"�����  �� ElementName$ listMyItems�� �� Path$ DataContext.RemoveHuman� �� RelativeSource �� *FindAncestor+ �� AncestorType" ��