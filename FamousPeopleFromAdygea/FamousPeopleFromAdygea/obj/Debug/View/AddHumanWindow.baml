   M S B A M L   `   `   `  ����Q  MFamousPeopleFromAdygea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FamousPeopleFromAdygea.ViewFamousPeopleFromAdygea.View  5   	   0    *FamousPeopleFromAdygea.View.AddHumanWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:FamousPeopleFromAdygea.View     5   	     � Title$  AddHumanWindow��5   	   $	��800��5	   	   $	��500��5
   	   $	��800��5   	   $	��500��5   	   ���	#FFE9FBE6 � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15,20q�6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $	��200 �6   �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ addFirstName��5      $��Имя:��5      $��Center=�5      $��18(�5      �� 5   
   -   5        $ 
addSurname��5      $��Фамилия:��5       $��1��5!      $��Center=�5"      $��18(�5#      �� 5$   
   -   5        $ addPatronymic��5$      $��Отчество:��5%      $��2��5&      $��Center=�5'      $��18(�5(      �� 5)   
   $ ��Дата рождения:��6   $��3��5*      $��Center=�5+      $��18(�5,      �� 5-   
   $��Дата смерти:��6   $��4��5.      $��Center=�5/      $��18(�50      �� 51   
   $��Описание:��6   $��5��52      $��Center=�53      $��18(�54      �� 57   
   -   5         ��Name$ tbFirstName��57      $��Bottom=�58      $
��50,0q�59      $��18(�5:      �� 5<   
   -   5        $ 	tbSurname��5<      $��Bottom=�5=      $
��50,0q�5>      $��1��5?      $��18(�5@      �� 5B   
   -   5        $ tbPatronymic��5B      $��Bottom=�5C      $
��50,0q�5D      $��2��5E      $��18(�5F      (  "System.Windows.Controls.DatePicker  5H   
   -   5          Name$ dpDeathDate��5H      $��Bottom=�5I      $
��50,0q�5J      $��18(�5K      $��4��5L        5N   
   -   5        $ dpBirthDate��5N      $��Bottom=�5O      $
��50,0q�5P      $��3��5Q      $��18(�5S      5U      �� 5V   
   -	   5        $ tbDes��5V      $��
50,50,50,0q�5W      $��5��5X      $��18(�5Y       �� TextWrapping$
 Wrap=�5Z       �� AcceptsReturn . 5[      �� 5]   
   $:��4Введите путь для фотографии:��6   $��0��5^      $��6��5_      $��3��5`      $��Center=�5a      $��18(�5b      $��0q�5c      �� 5d   
   -
   5        $ pathTB��5d      $��6��5e      $��18(�5f      $��0��5g      $��Bottom=�5h      $��3��5i      $
��50,0q�5j      �� 5l   
   -   5         ��Name$ 
addPathBtn��5l      $��Добавить путь��5m      $��7��5n      $��1��5o      $��18(�5p      $	��160��5q      $��40��5r      5t      �� 5v   
   -   5        $ btnSave��5v      $��8��5w      $��Сохранить��5x      $��60, 0q�5y      $��20(�5z      5{      5|      5}      