   M S B A M L   `   `   `  ����P  LGroupProjectPrototype, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GroupProjectPrototype.MainGroupProjectPrototype.Main  5   	   (    "GroupProjectPrototype.Main.wndMain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:GroupProjectPrototype.Main     5   	     � Title$  Invoice System��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   o� -   5         o�Name$
 menu��5
      $��86��6   $��158,21,155,312q�6)   $��Center=�6A   $	��479��6\   $��Center=�6h   $��Center=�6�   $��Disabled=�6�   $��Center=�6�   $��45,17,45,10q�6�   .@�5      �� -   5         ��Name$ 	searchBtn��5      $��Search for Invoice��6(   $	��180��6E   $��20(�6Q   $��50��6_   $��Center=�6k   $��Center=�6�   $��1q�6�   6�   �� 5      -   5        $ itemsBtn��5      $��
Edit Items��6'   $	��180��6<   $��20(�6H   $��50��6V   $��Center=�6b   $��Center=�6   $��1q�6�   5      �� 5   
   -   5        $ 
editInvBtn��5      $��Edit Invoice��6%   $
��Left=�6<   $��
91,288,0,0q�6W   $	��Top=�6k   $	��154��6�   �� 5   
   -   5        $ 	newInvBtn��5      $��New Invoice��6$   $
��Left=�6:   $��
91,253,0,0q�6U   $	��Top=�6i   $	��154��6�   �� 5   
   -   5        $ 
saveInvBtn��5      $��Save Invoice��6%   $
��Left=�6<   $��
91,362,0,0q�6W   $	��Top=�6k   $	��154��6�   �� 5   
   -   5        $ deleteItemBtn��5      $��Delete Item from Invoice��6(   $
��Left=�6K   $��562,327,0,0q�6f   $	��Top=�6{   $	��202��6�   �� 5   
   -   5        $ 
addItemBtn��5      $��Add Item to Invoice��6%   $
��Left=�6C   $��562,288,0,0q�6^   $	��Top=�6s   $	��202��6�   �� 5   
   -	   5        $ deleteInvBtn��5      $��Delete Invoice��6'   $
��Left=�6@   $��
91,327,0,0q�6[   $	��Top=�6o   $	��154��6�   �� 5   
   -
   5         ��Name$ totalCostLbl��5      $��
Total Cost��6&   $
��Left=�6;   $��
10,207,0,0q�6V   $	��Top=�6j   $��76��6�   $��Right=�6�   �� 5   
   -   5        $ 
invDateLbl��5      $��Invoice Date��6$   $
��Left=�6;   $��
10,173,0,0q�6V   $	��Top=�6j    J� RenderTransformOrigin$ -0.595,0.739&�6�   $��76��6�   $��Right=�6�   �� 5   
   -   5        $ 	invNumLbl��5      $��Invoice Number��6#   $
��Left=�6<   $��
10,140,0,0q�6W   $	��Top=�6k   $��76��6�   $��Right=�6�   �� 5   
   -   5         ��Name$ 	invNumTxt��5      $
��Left=�6%   $��23��6@   $��
91,143,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��154��6�   {�.  6�   �� 5   
   -   5        $ costTxt��5      $
��Left=�6#   $��23��6>   $��628,241,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��136��6�   {�.  6�   �� 5   
   -   5        $ totalCostTxt��5      $
��Left=�6(   $��23��6C   $��
91,210,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��154��6�   {�.  6�   �� 5   
   -   5        $ 
invDateTxt��5      $
��Left=�6&   $��23��6A   $��
91,176,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��154��6�   �� 5   
   -   5         ��Name$ itemsCB��5      $
��Left=�6$   $��562,177,0,0q�6?   $	��Top=�6T   $	��202��6l   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ itemsDG��5      $
��Left=�6$   $	��256��6?   $��279,126,0,0q�6L   $	��Top=�6a   $	��251��6y   �� 5   
   -   5        $ costLbl��5      $��	Item Cost��6!   $
��Left=�65   $��562,240,0,0q�6P   $	��Top=�6e   �� 5   
   -   5        $ itemLbl��5      $��Items��6!   $
��Left=�61   $��562,146,0,0q�6L   $	��Top=�6a   5       5!      