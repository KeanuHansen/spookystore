   M S B A M L   `   `   `  ����P  LGroupProjectPrototype, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:GroupProjectPrototypeGroupProjectPrototype  5   	   &     GroupProjectPrototype.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:GroupProjectPrototype     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� ���	#FFC19765.+�5
   
   �� $��Cursed Item Shop��6   $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   $��Viner Hand ITC)�6q   
�������6�   o� 5   
   -   5        $��businessMenu��5      $��22��6#    �� Left$	 119��6/   
 �� Top$ 15��6A   $	��518��6Q   ���	#FFFFE2C0.@�5      m� -   5         m�Name$ UpdateItems��5      $��_Update Items��6,   $��Viner Hand ITC)�6]   m� 5      -   5        $ Search��5      $��_Search Invoice��6'   $��Viner Hand ITC)�6U   5      �� 5   
   -   5        $��	createBtn��5      $��Create Invoice��6"   $	 119��6;   $ 83��6M   $��85��6]   ���	#FFA86130$��Viner Hand ITC)�6�   �� 5   
   -   5        $��	deleteBtn��5      $��Delete Invoice��6"   $	 516��6;   $ 83��6M   $	��101��6]   ���	#FFA86130$��Viner Hand ITC)�6�   �� 5   
   -   5        $��editBtn��5      $��Edit Invoice��6    $	 326��67   $ 83��6I   $��74��6Y   ���	#FFA86130$��Viner Hand ITC)�6�   �� 5   
   -   5        $��itemsManager��5      $	��284��6%   $ 65��62   $	 121��6C   $	��572��6T   $y�Visible=�6`   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��	invoiceDG��5      $	��117��6(   $ 20��65   $ 25��6F   $	��532��6V   $��Viner Hand ITC)�6b   (  "System.Windows.Controls.DatePicker  5      -	   5        $��selectedDate��5      $ 50��6-   $	 245��6>   $��Viner Hand ITC)�6O   �� 5      $��View Item: ��6   $
��Left=�6*   $	��Top=�6E   $ 31��6]   $	 150��6n   $��Viner Hand ITC)�6   �� 5      $��Number of Items:��6   $	 427��6/   $	 212��6A   $��Viner Hand ITC)�6R   �� 5      -
   5        $��numItemsLbl��5      $�� ��6   $	 535��62   $	 212��6D   $��Viner Hand ITC)�6U   �� 5      $��Total Cost:��6   $	 466��6*   $	 186��6<   $��Viner Hand ITC)�6M   �� 5      -   5        $��costLbl��5      $�� ��6   $	 535��6.   $	 186��6@   $��Viner Hand ITC)�6Q   �� 5      -   5        $��
addItemBtn��5   (   $��Add Item��6   $	 359��6:   $	 153��6L   $��76��6]   ���	#FFA86130$��Viner Hand ITC)�6�   �� 5      -   5        $��
cbitemList��5      $	 100��6)   $	 153��6;   $	��120��6L   $��Viner Hand ITC)�6�   �� 5      -   5        $��SaveInvoice��5      $��Save Invoice��6(   $	 227��6?   $	 245��6Q   $��84��6b   ���	#FFA86130$��Viner Hand ITC)�6�   �� 5      -   5        $��itemCost��5      $��23��6&   $	 238��62    �� TextWrapping$
 Wrap=�6D   $�� ��6X   $	 153��6`   $��62��6q    �� 
IsReadOnly . 6|   �� 5      -   5        $��	DeleteBtn��5      $��Delete Item��6&   $	 455��6<   $	 153��6N   $��75��6_   ���	#FFA86130$��Viner Hand ITC)�6�   �� 5       -   5        $��itemDesc��5       $ 50��6(   $
��Wrap=�69   $�� ��6M   $	 199��6U   5!      �� 5"   
   -   5        $��emptyLbl��5"      $�� ��6    $	 219��6+   $ 37��6=   
���  ��$��Viner Hand ITC)�6^   �� 5#   
   $��Invoice Number:��6   $ 89��6*   $	 108��6;   $��Viner Hand ITC)�6L   �� 5$   
   -   5        $��
invoiceLbl��5$      $�� ��6"   $	 191��6-   $	 108��6?   $��Viner Hand ITC)�6P   5%      5&      