   M S B A M L   `   `   `  ����K  GAutobuskaStanica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutobuskaStanicaAutobuskaStanica  5   	   "    AutobuskaStanica.Rezervacija   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AutobuskaStanica     5   	     � Title$   Dodaj / Izmeni Rezervaciju��5      $	��250��6/   $	��300��6<   .��5	      � .+�5
   
   �� $
��Ime:��6   $
��Left=�6   $��	40,30,0,0q�6:   $	��Top=�6M   �� 5   
   $��Datum:��6   $
��Left=�6!   $��	40,60,0,0q�6<   $	��Top=�6O   �� 5   
   $��Vreme:��6   $
��Left=�6!   $��	40,90,0,0q�6<   $	��Top=�6O   �� 5   
   $��Autobus:��6   $
��Left=�6#   $��
40,120,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ txtIme��5      $
��Left=�6"   $��
150,35,0,0q�6=    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatumRezervacije��5      $
��Left=�6/   $��
150,65,0,0q�6J   $	��Top=�6^   �� 5   
   -   5        $ txtVreme��5      $
��Left=�6$   $��
150,95,0,0q�6?   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   �� 5   
   -   5         ��Name$ 	cbAutobus��5      $
��Left=�6&   $��150,125,0,0q�6A   $	��Top=�6V   $	��120��6n    �� DisplayMemberPath$ Naziv��6z    �� SelectedValuePath$ KlubID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��
60,180,0,0q�6R   $	��Top=�6f   6~   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   $
��Left=�65   $��200,180,0,0q�6P   $	��Top=�6e   6}   5      5      