   M S B A M L   `   `   `  ����K  GAutobuskaStanica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutobuskaStanicaAutobuskaStanica  5   	       AutobuskaStanica.Karta   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AutobuskaStanica     5   	     � Title$  Dodaj / Izmeni Kartu��5      $	��368��6*   $	��336��67   .��5	      � .+�5
   
   �� $��Status zaposlenosti:��6   $
��Left=�6/   $��	40,30,0,0q�6J   $	��Top=�6]   �� 5   
   $��Cena:��6   $
��Left=�6    $��	40,60,0,0q�6;   $	��Top=�6N   �� 5   
   $��Sediste:��6   $
��Left=�6#   $��	40,90,0,0q�6>   $	��Top=�6Q   �� 5   
   $��Kupac:��6   $
��Left=�6!   $��
40,120,0,0q�6<   $	��Top=�6P   �� 5   
   $
��Tip:��6   $
��Left=�6   $��
40,150,0,0q�6:   $	��Top=�6N   �� 5   
   $��Rezervacija:��6   $
��Left=�6'   $��
40,180,0,0q�6B   $	��Top=�6V   �� 5   
   $��
Blagajnik:��6   $
��Left=�6%   $��
40,210,0,0q�6@   $	��Top=�6T   �� 5   
   $��Zona:��6   $
��Left=�6    $��
40,240,0,0q�6;   $	��Top=�6O   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ Datum��5      $
��Left=�6$   $��150,274,0,0q�6?   $	��Top=�6T   �� 5   
   $��Datum:��6   $
��Left=�6!   $��
40,274,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ 	txtStatus��5      $
��Left=�6%   $��
150,35,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        $ txtCena��5      $
��Left=�6#   $��
150,65,0,0q�6>   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   �� 5   
   -   5        $ txtBrojSedista��5      $
��Left=�6*   $��
150,95,0,0q�6E   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��120��6�   �� 5   	   -   5         ��Name$ cbKupac��5      $
��Left=�6#   $��150,125,0,0q�6>   $	��Top=�6S   $	��120��6k    �� DisplayMemberPath$ Naziv��6w    �� SelectedValuePath$ KlubID��6�   �� 5   
   -   5        $ 
cbTipKarte��5      $
��Left=�6'   $��150,155,0,0q�6B   $	��Top=�6W   $	��120��6o   $ Naziv��6{   $ KlubID��6�   �� 5   
   -   5        $ cbRezervacija��5      $
��Left=�6*   $��150,185,0,0q�6E   $	��Top=�6Z   $	��120��6r   $ Naziv��6~   $ KlubID��6�   �� 5    
   -   5        $ cbBlagajnik��5       $
��Left=�6(   $��150,215,0,0q�6C   $	��Top=�6X   $	��120��6p   $ Naziv��6|   $ KlubID��6�   �� 5!   
   -	   5        $ cbZona��5!      $
��Left=�6#   $��150,245,0,0q�6>   $	��Top=�6S   $	��120��6k   $ Naziv��6w   $ KlubID��6�   �� 5%   
   -
   5         ��Name$ 
btnSacuvaj��5%      $��Sacuvaj��6%   $
��Left=�67   $��
53,308,0,0q�6R   $	��Top=�6f   6~   �� 5&   
   -   5        $ 	btnOtkazi��5&      $��Otkazi��6$   $
��Left=�65   $��210,308,0,0q�6P   $	��Top=�6e   6}   5'      5(      