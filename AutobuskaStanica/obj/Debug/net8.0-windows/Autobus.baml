   M S B A M L   `   `   `  ����K  GAutobuskaStanica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AutobuskaStanicaAutobuskaStanica  5   	       AutobuskaStanica.Autobus   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AutobuskaStanica     5   	     � Title$  Dodaj / Izmeni Autobus��5      $	��250��6,   $	��300��69   .��5	      � .+�5
      �� $��Vrsta:��6   $
��Left=�6   $��	40,30,0,0q�68   $	��Top=�6K   �� 5      $��Putanja:��6   $
��Left=�6   $��	40,60,0,0q�6:   $	��Top=�6M   �� 5      $��
Prevoznik:��6   $
��Left=�6!   $��	40,90,0,0q�6<   $	��Top=�6O   �� 5      $��Garaza:��6   $
��Left=�6   $��
40,120,0,0q�69   $	��Top=�6M   �� 5      $��Polazak��6   $
��Left=�6   $��
40,150,0,0q�69   $	��Top=�6M   �� 5      -   5         ��Name$ txtVrsta��5      $
��Left=�6    $��
150,35,0,0q�6;    �� TextWrapping$
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $	��120��6�   �� 5      -   5        $ 
txtPutanja��5      $
��Left=�6"   $��
150,65,0,0q�6=   $
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��120��6�   �� 5      -   5        $ txtPrevoznik��5      $
��Left=�6$   $��
150,95,0,0q�6?   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   �� 5      -   5         ��Name$ cbGaraza��5      $
��Left=�6!   $��150,125,0,0q�6<   $	��Top=�6Q   $	��120��6i    �� DisplayMemberPath$ Naziv��6u    �� SelectedValuePath$ KlubID��6�   �� 5      -   5        $ 	cbPolazak��5      $
��Left=�6"   $��150,155,0,0q�6=   $	��Top=�6R   $	��120��6j   $ Naziv��6v   $ KlubID��6�   �� 5      -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6!   $
��Left=�63   $��
60,180,0,0q�6N   $	��Top=�6b   6z   �� 5      -   5        $ 	btnOtkazi��5      $��Otkazi��6    $
��Left=�61   $��200,180,0,0q�6L   $	��Top=�6a   6y   5      5      