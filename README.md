# idpa_IoT-Abfahrtsbildschirm

Dieses Projekt wurde für die IDPA erstellt. Es handelt sich um einen Zugfahrplan für Schulen und Unternehmen.  
Die Website sieht wie folgt aus.

![Unbenannt](https://user-images.githubusercontent.com/78475321/236708276-91724356-4f92-45d5-b540-ab0fec933cf9.png)



## Vorbedingungen

* Visual Studio 2021
* .NET Core SDK

Für Raspberry Pi
---

* Raspberry Pi (egal welche Version)
* Eine Art von Speicher (8GB sind genug: microSD Card, USB-Stick, Externe SSD)

## How To Run - Windows

* Öffnen Sie die Visual Studio 2021
* Dieses Repository klonen
* Applikation starten

## How To Run - Raspberry Pi

* Laden Sie den Raspberry Pi Imager für Windows herunter.
* Betriebssystem auswählen (vorzugsweise OS 64-bit, Achtung nicht Lite, da es keinen Desktop hat).
* Das Betriebssystem auf den externen Speicher schreiben
* Starten Sie den Raspberry Pi mit dem Betriebssystem.

*	Öffnen Sie ein Terminal und geben Sie Folgendes ein 
    ```
    chromium-browser https://google.com
    ```
    *	Wenn dies nicht funktioniert, überprüfen Sie, ob der Chromium-Browser in /usr/bin/chromium-browser installiert ist.
*	Wenn dies funktioniert, erstellen Sie die folgenden Ordner in /etc 
    ```
    mkdir -p /xdg/lxsession/LXDE-pi
    ```
*	Erstellen Sie dann innerhalb von LXDE-pi eine Datei namens autostart und öffnen Sie diese. Möglicherweise benötigen Sie Superuser-Rechte. 
    ```
    sudo nano autostart
    ```
*	Geben Sie dann folgenden Text in die Datei ein
    ```
      @lxpanel --profile LXDE-pi
      @pcmanfm --desktop --profile LXDE-pi
      #@xscreensaver -no-splash
      point-rpi
      @chromium-browser –start-fullscreen https://idpa-iot-abfahrtsbildschirm.herokuapp.com
    ```
*	Sie können dann sudo reboot eingeben, um zu sehen, ob es funktioniert.
