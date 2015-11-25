UWAGA!
W MainPage.xaml w 2-giej linijce(x:Class="$UWPtemplate$.MainPage") trzeba zamienić $UWPtemplate$ na nazwę projektu(namespace projektu)
tak samo w Controls/Pane.xaml też 2-ga linijka. 
Sorki za te niedopatrzenie. Nie chciało mi się kolejny raz eksportować wzorca. Kolejne wersje będą już ok.



-------------------------------------------------------------
Template przeznaczony dla aplikacji UWP z systemem Windows 10

Wprowadzone zmiany względem pustej aplikacji:
- Dodane powszechnie używane foldery.
- Dodana kontrolka Pane (pusta).
- Dodane dwa konwertery bool -> Visibility i bool -> !Visibility.
- Dodane narzędzie API służące do wysyłania zapytań typu POST wraz z przykładowym zapytaniem.
- Dodany 'wykrywacz gestów' na razie obsługuje tylko oś X, jest potrzebny do otwierania/samykania sekcji Pane gestem
- Dodany lokalizator znajdujący pozycję urządzenia na którym działa apliakcja, jest fajnie zabezpieczony przed błędami więc myślę, że 
się przyda:)
- Dodany ViewModel głównej strony, jedyna rzecz którą trzeba tam zrobić to nawigować frame z MainPage.xaml do jakiejś strony,
ważne, żeby nie nawigować znowu do MainPage bo wywali xaml-owy stack overflow exeption i przywiesi troszkę kompa :p
- W App.xaml dodany customowy accent color, kilka styli text blocków różniących się tylko wielkością. Dodane przeedytowane kontrolki.
ListView, TextBox, CheckBox i Button dzięki edycji obsługują wyżej wymieniony customowy accent color każdy styl który dodałem poprzedzony
jest prefiksem 'App-' tak aby łatwo było go później odnaleść.
- W App.xaml.cs dodane kilka właściwości które mogą okazać się przydatne podczas działania programu, wszystkie z nich są statyczne,
wprowadziłem również podstawową obsługę systemowego przycisku powrotu.
- W MainPage.xaml dodane i całkowicie obsłużone SplitView wraz z przyciskiem do otwierania/zamykania sekcji Pane. Poza tym dodany frame
dzięki któremu nie trzeba po każdej nawigacji budować nowego SplitView
- W MainPage.xaml.cs podpięty ViewModel i eszystkie eventy


Autor: Damian Falkowski
Kontakt: dfalkows@hotmail.com




----------------------------------------------------------
Dodadkowe Uwagi!

Projekt wymaga zainstalowania poniższych Nu-getów. Odpalamy v Visualu View > OtherWindows > PackageManagerConsole i 
wpisujemy w oknie podane instrukcje.

Install-Package Newtonsoft.Json -Version 7.0.1 
Install-Package MvvmLight 


Żeby projekt mógł poprawnie działać do vs 2015 musi być dodane Windows10 SDK https://dev.windows.com/en-us/downloads/windows-10-sdk


Template nie stety nie da się dodać do wersji Express :(





----------------------------------------------------------
Jak zainstalowac template?

1. Plik .zip z template umieszczamy w folderze 
C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\ProjectTemplates\CSharp\Windows Root\Windows UAP\1033\

2. W katalogu C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\ odpalamy cmd koniecznie w trybie administratora.

3. Zamykamy wszystkie instancje Visual Studio

4. W wierszu poleceń wpisujemy 'devenv/installvstemplates' i czekamy aż polecenie się wykona

4. Zamykamy wiersz polecenia, odpalamy vs i template powinien znajdować się razem z innymi wzorcami dla UWP

