   M S B A M L   `   `   `  ����K  GAutobuskaStanica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutobuskaStanicaAutobuskaStanica  5   	       AutobuskaStanica.Polazak   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AutobuskaStanica     5   	     � Title$  Dodaj / Izmeni Polazak��5      $	��250��6,   $	��300��69   .��5	      � .+�5
   
   �� $��Vreme:��6   $
��Left=�6!   $��	40,30,0,0q�6<   $	��Top=�6O   �� 5   
   $��Datum:��6   $
��Left=�6!   $��	40,60,0,0q�6<   $	��Top=�6O   �� 5   
   $��Vreme Dolaska:��6   $
��Left=�6)   $��	40,90,0,0q�6D   $	��Top=�6W   �� 5   
   -   5         ��Name$ txtVreme��5      $
��Left=�6$   $��
150,35,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatumPolaska��5      $
��Left=�6+   $��
150,65,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $ txtVremeDolaska��5      $
��Left=�6+   $��
150,95,0,0q�6F   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��
60,180,0,0q�6R   $	��Top=�6f   6~   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   $
��Left=�65   $��200,180,0,0q�6P   $	��Top=�6e   6}   5      5      