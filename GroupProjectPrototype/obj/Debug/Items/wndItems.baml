   M S B A M L   `   `   `  ����P  LGroupProjectPrototype, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:GroupProjectPrototypeGroupProjectPrototype  5   	   *    $GroupProjectPrototype.Items.wndItems   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:GroupProjectPrototype     5   	   -   5          � Title$  wndItems��5   	   $	��450��6   $	��800��6'   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ itemsDataGrid��5
      $
��Left=�6*   $	��367��6E   $��	10,10,0,0q�6R   $	��Top=�6e   $	��500��6}      CanUserAddRows .     AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 63      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� 	 �� Path$	 sCode�6^     5      $
 Cost��6%   $	 100 63    .  6?   �� $	 dCost�6^     5      $ Description��6%   $ * 6:    .  6D   �� $	 sDesc�6c   5      �� 5   
   -   5        
 ��Name$
 
errorLabel��5      $��If error, show here��6$   $
��Left=�6B   $��
10,385,0,0q�6]   $	��Top=�6q   
���  ��6�   � 5   
   -   5         �Name$ gRecordControls��5      $��515,10,10,10q�6(   $y�Visible=�6>   .+�5      �� -   5         ��Name$ bAddItem��5      $��Add Item��6'   $��Center=�6:   $��	0,102,0,0q�6W   $	��Top=�6j   $��93��6�   6�   �� 5      -   5        $ 	bEditItem��5      $��	Edit Item��6(   $��Center=�6<   $��	0,144,0,0q�6Y   $	��Top=�6l   $��93��6�   6�   �� 5      -   5        $ bDeleteItem��5      $��Delete Item��6*   $��Center=�6@   $��	0,186,0,0q�6]   $	��Top=�6p   $��93��6�   6�   5      5      5      