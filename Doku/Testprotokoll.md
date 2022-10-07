# Testfälle :material-projector-screen-outline:

## Allgemeine Testfälle

### Testfall A-001

| ID/Bezeichnung      | A-001                                          |
| ------------------- | ---------------------------------------------- |
| Beschreibung        | Kamera kann geöffnet werden                    |
| Testvoraussetzung   | Gerät verfügbar über eine Kamera               |
| Testzeitpunkt       | -                                              |
| Testschritte        | Knopf mit Kameraverlinkung klicken             |
| Weiteres Vorgehen   | -                                              |
| Erwartetes Ergebnis | Kamera wird geöffnet und Bild wird gespeichert |

### Testfall A-002

| ID/Bezeichnung      | A-002                                                      |
| ------------------- | ---------------------------------------------------------- |
| Beschreibung        | Fotomediothek können geöffnet werden                       |
| Testvoraussetzung   | Gerät verfügbar über Fotos                                 |
| Testzeitpunkt       | -                                                          |
| Testschritte        | Knopf mit Fotomediothekverlinkung klicken                  |
| Weiteres Vorgehen   | -                                                          |
| Erwartetes Ergebnis | Fotoauswahl wird angezeigt und Foto kann ausgewählt werden |

### Testfall A-003

| ID/Bezeichnung      | A-003                                                    |
| ------------------- | -------------------------------------------------------- |
| Beschreibung        | Bedienungsanleitung wird nicht benötigt                  |
| Testvoraussetzung   | App startet & Angemeldet                                 |
| Testzeitpunkt       | -                                                        |
| Testschritte        | Kontoeinrichtung und Nachrichten versenden durchlaufen   |
| Weiteres Vorgehen   | -                                                        |
| Erwartetes Ergebnis | Es ist klar was verlangt ist und was welcher Knopf macht |

### Testfall A-004

| ID/Bezeichnung      | A-004                                                   |
| ------------------- | ------------------------------------------------------- |
| Beschreibung        | App ist auf unterschiedlichen Versionen lauffähig       |
| Testvoraussetzung   | Unterschiedliche Geräte                                 |
| Testzeitpunkt       | Start                                                   |
| Testschritte        | App auf unterschiedlichen Geräten installieren          |
| Weiteres Vorgehen   | App ist auf gängigen Betriebssystemen lauffähig (A-005) |
| Erwartetes Ergebnis | Das Verhalten ist auf allen Geräten gleich              |

### Testfall A-005

| ID/Bezeichnung      | A-005                                                     |
| ------------------- | --------------------------------------------------------- |
| Beschreibung        | App ist auf gängigen Betriebssystemen lauffähig           |
| Testvoraussetzung   | Unterschiedliche Geräte                                   |
| Testzeitpunkt       | Start                                                     |
| Testschritte        | App auf Windows, Android, MacOS & iOS installieren        |
| Weiteres Vorgehen   | App ist auf unterschiedlichen Versionen lauffähig (A-004) |
| Erwartetes Ergebnis | Das Verhalten ist auf allen Geräten gleich                |

### Testfall A-006

| ID/Bezeichnung      | A-006                                                            |
| ------------------- | ---------------------------------------------------------------- |
| Beschreibung        | JavaScript & Html Eingaben werden escaped                        |
| Testvoraussetzung   | Eingabefeld mit Freitext                                         |
| Testzeitpunkt       | Start                                                            |
| Testschritte        | HTML in Eingabefeld schreiben                                    |
|                     | Daten aus Eingabefeld anzeigen                                   |
| Weiteres Vorgehen   | -                                                                |
| Erwartetes Ergebnis | JavaScript & HTML wird als Text dargestellt und nicht ausgeführt |

## Datenbank

### Testfall D-001

| ID/Bezeichnung      | D-001                                                                                |
| ------------------- | ------------------------------------------------------------------------------------ |
| Beschreibung        | Models werden auf die Datenbank gemappt                                              |
| Testvoraussetzung   | Datenbankverbindung                                                                  |
| Testzeitpunkt       | Appstart                                                                             |
| Testschritte        | App starten                                                                          |
| Weiteres Vorgehen   | Speichern (D-002) & Auslesen (D-003)                                                 |
| Erwartetes Ergebnis | Entitäten sind auf der Datenbank und besitzen dieselben Eigenschaften wie die Models |

### Testfall D-002

| ID/Bezeichnung      | D-002                                                   |
| ------------------- | ------------------------------------------------------- |
| Beschreibung        | Speichern                                               |
| Testvoraussetzung   | Datenbankverbindung                                     |
| Testzeitpunkt       | -                                                       |
| Testschritte        | Datenbankspeicherung verlangen                          |
| Weiteres Vorgehen   | Auslesen (D-003)                                        |
| Erwartetes Ergebnis | Daten sind auf lokaler & externer Datenbank gespeichert |

### Testfall D-003

| ID/Bezeichnung      | D-003                                                         |
| ------------------- | ------------------------------------------------------------- |
| Beschreibung        | Auslesen                                                      |
| Testvoraussetzung   | Datenbankverbindung                                           |
| Testzeitpunkt       | -                                                             |
| Testschritte        | Datenbankspeicherung verlangen                                |
| Weiteres Vorgehen   | Speichern (D-002)                                             |
| Erwartetes Ergebnis | Daten werden von Server geladen, wenn verbunden               |
|                     | Wenn keine Verbindung besteht, dann wird die lokale Verwendet |

### Testfall D-004

| ID/Bezeichnung      | D-004                                           |
| ------------------- | ----------------------------------------------- |
| Beschreibung        | Datenbankverbindung kann hergestellt werden     |
| Testvoraussetzung   | App startet & Internetverbindung besteht        |
| Testzeitpunkt       | Appstart                                        |
| Testschritte        | App starten                                     |
|                     | Debugger testen ob Verbunden                    |
| Weiteres Vorgehen   | Models werden auf die Datenbank gemappt (D-001) |
| Erwartetes Ergebnis | Datenbank ist verbunden                         |

### Testfall D-005

| ID/Bezeichnung      | D-005                                                    |
| ------------------- | -------------------------------------------------------- |
| Beschreibung        | Lokale Datenbank wird mit Server synchronisiert          |
| Testvoraussetzung   | Datenbankspeicherung zu Server                           |
| Testzeitpunkt       | Appstart                                                 |
| Testschritte        | App starten                                              |
|                     | Debugger testen ob Datenbank synchron ist                |
| Weiteres Vorgehen   | Auslesen (D-003)                                         |
| Erwartetes Ergebnis | Lokale Datenbank besitzt dieselben Werte wie die Externe |

## Login Testfälle

### Testfall L-001

| ID/Bezeichnung      | L-001                         |
| ------------------- | ----------------------------- |
| Beschreibung        | App kann installiert werden   |
| Testvoraussetzung   | APK auf Gerät                 |
| Testzeitpunkt       | Start                         |
| Testschritte        | APK auf Gerät laden           |
|                     | Installer öffnen              |
|                     | App starten                   |
| Weiteres Vorgehen   | App start testen              |
| Erwartetes Ergebnis | App startet & ist installiert |

### Testfall L-002

| ID/Bezeichnung      | L-002                                             |
| ------------------- | ------------------------------------------------- |
| Beschreibung        | App startet und wird richtig aufgesetzt           |
| Testvoraussetzung   | App installiert (L-001)                           |
| Testzeitpunkt       | Start                                             |
| Testschritte        | App starten                                       |
|                     | Dateiverzeichnis inspizieren                      |
| Weiteres Vorgehen   | Start mit / ohne Internet                         |
| Erwartetes Ergebnis | Datenbank vorhanden & Anmeldeseite wird angezeigt |

### Testfall L-003

| ID/Bezeichnung      | L-003                             |
| ------------------- | --------------------------------- |
| Beschreibung        | App startet ohne Internet         |
| Testvoraussetzung   | Kein Internet                     |
| Testzeitpunkt       | Start                             |
| Testschritte        | Internet ausschalten              |
|                     | App starten                       |
| Weiteres Vorgehen   |                                   |
| Erwartetes Ergebnis | App startet nach Vorgaben (L-002) |

### Testfall L-004

| ID/Bezeichnung      | L-004                                     |
| ------------------- | ----------------------------------------- |
| Beschreibung        | Benutzer kann sich registrieren           |
| Testvoraussetzung   | App startet (L-002)                       |
| Testzeitpunkt       | Start                                     |
| Testschritte        | App starten                               |
|                     | Sign Up anklicken                         |
|                     | Felder ausfüllen                          |
|                     | Continue klicken                          |
| Weiteres Vorgehen   | Login testen                              |
| Erwartetes Ergebnis | Anmeldung erfolgt                         |
|                     | User wird in Datenbank angelegt           |
|                     | Es wird auf die Home-Seite weitergeleitet |

### Testfall L-005

| ID/Bezeichnung      | L-005                                                              |
| ------------------- | ------------------------------------------------------------------ |
| Beschreibung        | Anmeldefelder werden validiert                                     |
| Testvoraussetzung   | -                                                                  |
| Testzeitpunkt       | Start                                                              |
| Testschritte        | Registrierung öffnen                                               |
|                     | Eingabelimit übertreffen                                           |
| Weiteres Vorgehen   | -                                                                  |
| Erwartetes Ergebnis | Fehlerhafte Felder werden gekennzeichnet & Anmeldung erfolgt nicht |

### Testfall L-006

| ID/Bezeichnung      | L-006                                                 |
| ------------------- | ----------------------------------------------------- |
| Beschreibung        | Registrierung ohne Internet                           |
| Testvoraussetzung   | Kein Internet                                         |
| Testzeitpunkt       | Start                                                 |
| Testschritte        | Internet ausschalten                                  |
|                     | Registrierung ausführen                               |
| Weiteres Vorgehen   | Login ohne Internet                                   |
| Erwartetes Ergebnis | Weiterknopf führt nichts aus & Meldung wird angezeigt |

### Testfall L-007

| ID/Bezeichnung      | L-007                                                 |
| ------------------- | ----------------------------------------------------- |
| Beschreibung        | Login ohne Internet                                   |
| Testvoraussetzung   | Kein Internet                                         |
| Testzeitpunkt       | Start                                                 |
| Testschritte        | Internet ausschalten                                  |
|                     | Login ausführen                                       |
| Weiteres Vorgehen   | Registrierung ohne Internet                           |
| Erwartetes Ergebnis | Weiterknopf führt nichts aus & Meldung wird angezeigt |

### Testfall L-008

| ID/Bezeichnung      | L-008                                                          |
| ------------------- | -------------------------------------------------------------- |
| Beschreibung        | Benutzer kann sich anmelden                                    |
| Testvoraussetzung   | Konto existiert                                                |
| Testzeitpunkt       | Start                                                          |
| Testschritte        | Loginseite öffnen                                              |
|                     | Anmeldedaten einfügen                                          |
| Weiteres Vorgehen   | Benutzer kann sich registrieren (L-004)                        |
| Erwartetes Ergebnis | Benutzer wird angemeldet und auf die Home-Seite weitergeleitet |

### Testfall L-009

| ID/Bezeichnung      | L-009                                        |
| ------------------- | -------------------------------------------- |
| Beschreibung        | Benutzer kann ein Profilbild hinterlegen     |
| Testvoraussetzung   | Gerät verfügt über eine Kamera               |
| Testzeitpunkt       | Start                                        |
| Testschritte        | Registrierung öffnen                         |
|                     | Kamera auswählen                             |
| Weiteres Vorgehen   | -                                            |
| Erwartetes Ergebnis | Profilbild wird in die Datenbank gespeichert |

### Testfall L-010

| ID/Bezeichnung      | L-010                                       |
| ------------------- | ------------------------------------------- |
| Beschreibung        | Benutzer bleibt angemeldet nach Schliessung |
| Testvoraussetzung   | Erfolgreiche Anmeldung                      |
| Testzeitpunkt       | Start                                       |
| Testschritte        | Anmelden                                    |
|                     | App schliessen                              |
|                     | App neu öffnen                              |
| Weiteres Vorgehen   | -                                           |
| Erwartetes Ergebnis | Benutzer ist mit Anmeldedaten angemeldet    |

### Testfall L-011

| ID/Bezeichnung      | L-011                                                   |
| ------------------- | ------------------------------------------------------- |
| Beschreibung        | Anmeldedaten werden in Geräte-Cloud                     |
| Testvoraussetzung   | Erfolgreiche Anmeldung                                  |
| Testzeitpunkt       | Start                                                   |
| Testschritte        | Anmelden                                                |
|                     | Anderes Gerät mit gleichem Account öffnen               |
| Weiteres Vorgehen   | -                                                       |
| Erwartetes Ergebnis | Die Anmeldedaten sind auf einem anderen Gerät verfügbar |

### Testfall L-012

| ID/Bezeichnung      | L-012                                                                            |
| ------------------- | -------------------------------------------------------------------------------- |
| Beschreibung        | Profilbild wird generiert                                                        |
| Testvoraussetzung   | Kein Profilbild erstellt                                                         |
| Testzeitpunkt       | Start                                                                            |
| Testschritte        | Registrierung ohne Bild hinterlegen                                              |
| Weiteres Vorgehen   | -                                                                                |
| Erwartetes Ergebnis | Es wird ein [Bild](https://avatars.dicebear.com/) generiert & ist immer dasselbe |

### Testfall L-013

| ID/Bezeichnung      | L-013                                    |
| ------------------- | ---------------------------------------- |
| Beschreibung        | App löschen                              |
| Testvoraussetzung   | App erfolgreich installiert & Angemeldet |
| Testzeitpunkt       | Start                                    |
| Testschritte        | App installieren                         |
|                     | App deinstallieren                       |
|                     | App neu installieren                     |
| Weiteres Vorgehen   | -                                        |
| Erwartetes Ergebnis | Daten sind nicht mehr vorhanden          |

### Testfall L-014

| ID/Bezeichnung      | L-014                                        |
| ------------------- | -------------------------------------------- |
| Beschreibung        | Quer & Hochformat                            |
| Testvoraussetzung   | App installiert                              |
| Testzeitpunkt       | Start                                        |
| Testschritte        | Login / Registrierung öffnen                 |
|                     | Bildschirm drehen                            |
| Weiteres Vorgehen   | -                                            |
| Erwartetes Ergebnis | Seiten passen sich responsive der Grösse an. |

### Testfall L-015

| ID/Bezeichnung      | L-015                                                         |
| ------------------- | ------------------------------------------------------------- |
| Beschreibung        | Pflichtfelder müssen ausgefüllt werden                        |
| Testvoraussetzung   | -                                                             |
| Testzeitpunkt       | Start                                                         |
| Testschritte        | Registrierung öffnen                                          |
|                     | Weiter ohne ausfüllen klicken                                 |
| Weiteres Vorgehen   | -                                                             |
| Erwartetes Ergebnis | Pflichtfelder werden gekennzeichnet & Anmeldung erfolgt nicht |

### Testfall L-016

| ID/Bezeichnung      | L-016                                                             |
| ------------------- | ----------------------------------------------------------------- |
| Beschreibung        | Pflichtfelder müssen ausgefüllt werden                            |
| Testvoraussetzung   | Benutzer mit Nickname                                             |
| Testzeitpunkt       | Start                                                             |
| Testschritte        | Registrierung öffnen                                              |
|                     | Bereits existierender Nickname eingeben                           |
| Weiteres Vorgehen   | -                                                                 |
| Erwartetes Ergebnis | Meldung wird angezeigt, dass keine Verbindung gemacht werden kann |

## Home-Seite

### Testfall H-001

| ID/Bezeichnung      | H-001                                                           |
| ------------------- | --------------------------------------------------------------- |
| Beschreibung        | Chats werden geladen                                            |
| Testvoraussetzung   | Benutzer ist angemeldet                                         |
| Testzeitpunkt       | Mitte                                                           |
| Testschritte        | Home-Seite öffnen                                               |
| Weiteres Vorgehen   | Chats suchen (H-002)                                            |
|                     | Ohne Internet Home öffnen (H-006)                               |
| Erwartetes Ergebnis | Chats werden dargestellt und sind nach letzter Sendung sortiert |

### Testfall H-002

| ID/Bezeichnung      | H-002                                                         |
| ------------------- | ------------------------------------------------------------- |
| Beschreibung        | Chat kann gesucht werden                                      |
| Testvoraussetzung   | Chats sind vorhanden                                          |
| Testzeitpunkt       | Mitte                                                         |
| Testschritte        | Home-Seite öffnen                                             |
|                     | Name in Suchleiste eingeben                                   |
| Weiteres Vorgehen   | Chat öffnen                                                   |
| Erwartetes Ergebnis | Nur Chats, welche das Suchkriterium besitzen werden angezeigt |

### Testfall H-003

| ID/Bezeichnung      | H-003                                        |
| ------------------- | -------------------------------------------- |
| Beschreibung        | Neuer Chat mit Benutzer                      |
| Testvoraussetzung   | Benutzer existiert                           |
| Testzeitpunkt       | Mitte                                        |
| Testschritte        | Home-Seite öffnen                            |
|                     | Benutzerhinzufügen-Popup öffnen              |
|                     | Benutzer suchen                              |
| Weiteres Vorgehen   | Nicht existierender Benutzer suchen (H-004)  |
|                     | Chat öffnen (H-005)                          |
| Erwartetes Ergebnis | Benutzer wird gesucht und Chat wird begonnen |

### Testfall H-004

| ID/Bezeichnung      | H-004                                       |
| ------------------- | ------------------------------------------- |
| Beschreibung        | Nicht existierender Benutzer suchen         |
| Testvoraussetzung   | Nicht existenter Benutzer                   |
| Testzeitpunkt       | Mitte                                       |
| Testschritte        | Home-Seite öffnen                           |
|                     | Benutzerhinzufügen-Popup öffnen             |
|                     | Benutzer suchen                             |
| Weiteres Vorgehen   | Nicht existierender Benutzer suchen (H-004) |
| Erwartetes Ergebnis | Meldung wird angezeigt                      |

### Testfall H-005

| ID/Bezeichnung      | H-005              |
| ------------------- | ------------------ |
| Beschreibung        | Chat öffnen        |
| Testvoraussetzung   | Chat existiert     |
| Testzeitpunkt       | Mitte              |
| Testschritte        | Home-Seite öffnen  |
|                     | Auf Chat klicken   |
| Weiteres Vorgehen   | Nachrichten senden |
| Erwartetes Ergebnis | Chat wird geöffnet |

### Testfall H-006

| ID/Bezeichnung      | H-006                                   |
| ------------------- | --------------------------------------- |
| Beschreibung        | Ohne Internet Home öffnen               |
| Testvoraussetzung   | Bestehende Chats & kein Internet        |
| Testzeitpunkt       | Mitte                                   |
| Testschritte        | Internet ausschalten                    |
|                     | Home-Seite öffnen                       |
| Weiteres Vorgehen   | -                                       |
| Erwartetes Ergebnis | Zuletzt synchronisierte Chats angezeigt |

### Testfall H-007

| ID/Bezeichnung      | H-001                                                 |
| ------------------- | ----------------------------------------------------- |
| Beschreibung        | Benutzer kann sich Abmelden                           |
| Testvoraussetzung   | Benutzer ist angemeldet                               |
| Testzeitpunkt       | Mitte                                                 |
| Testschritte        | Anmelden                                              |
|                     | Klick auf Abmelden                                    |
|                     | Abmelden bestätigen                                   |
| Weiteres Vorgehen   | Erneut anmelden                                       |
| Erwartetes Ergebnis | Bestätigung wird abgefragt & Benutzer wird abgemeldet |

### Testfall H-008

| ID/Bezeichnung      | H-008                                               |
| ------------------- | --------------------------------------------------- |
| Beschreibung        | Profil öffnen                                       |
| Testvoraussetzung   | Benutzer ist angemeldet                             |
| Testzeitpunkt       | Mitte                                               |
| Testschritte        | Home-Seite öffnen                                   |
|                     | Auf Zahnrad klicken                                 |
| Weiteres Vorgehen   |                                                     |
| Erwartetes Ergebnis | Kontoseite wird angezeigt & Änderungen sind möglich |

### Testfall H-009

| ID/Bezeichnung      | H-009                     |
| ------------------- | ------------------------- |
| Beschreibung        | Chat nicht mit mir selber |
| Testvoraussetzung   | Benutzer ist angemeldet   |
| Testzeitpunkt       | Mitte                     |
| Testschritte        | Home-Seite öffnen         |
|                     | Neuer Chat erstellen      |
|                     | Eigener Nickname eingeben |
| Weiteres Vorgehen   | -                         |
| Erwartetes Ergebnis | Meldung wird angezeigt    |

## Chat

### Testfall C-001

| ID/Bezeichnung      | C-001                                                                                    |
| ------------------- | ---------------------------------------------------------------------------------------- |
| Beschreibung        | Bestehende Nachrichten werden geladen                                                    |
| Testvoraussetzung   | Nachrichten wurden zuvor versendet                                                       |
| Testzeitpunkt       | Ende                                                                                     |
| Testschritte        | Nachricht versenden                                                                      |
|                     | Chat verlassen                                                                           |
|                     | Chat öffnen                                                                              |
| Weiteres Vorgehen   | Ohne Internet laden (C-002), Nachricht versenden (C-003) & Nachrichten empfangen (C-007) |
| Erwartetes Ergebnis | Nachrichten werden geladen                                                               |
|                     | Nachricht sind nach Versanddatum sortiert                                                |
|                     | Gesendete Nachrichten sind rechts                                                        |
|                     | Empfangene Nachrichten sind links                                                        |

### Testfall C-002

| ID/Bezeichnung      | C-002                                               |
| ------------------- | --------------------------------------------------- |
| Beschreibung        | Bestehende Nachrichten werden ohne Internet geladen |
| Testvoraussetzung   | Nachrichten wurden zuvor versendet                  |
| Testzeitpunkt       | Ende                                                |
| Testschritte        | Nachricht versenden                                 |
|                     | Chat verlassen                                      |
|                     | Internet ausstellen                                 |
|                     | Chat öffnen                                         |
| Weiteres Vorgehen   |                                                     |
| Erwartetes Ergebnis |                                                     |

### Testfall C-003

| ID/Bezeichnung      | C-003                               |
| ------------------- | ----------------------------------- |
| Beschreibung        | Bild kann versenden werden          |
| Testvoraussetzung   | Internetverbindung                  |
| Testzeitpunkt       | Ende                                |
| Testschritte        | Meme auswählen                      |
|                     | Meme versenden                      |
| Weiteres Vorgehen   | Ohne Internet versenden (C-004)     |
| Erwartetes Ergebnis | Nachricht wird an Server gesendet   |
|                     | Nachricht wird lokal gespeichert    |
|                     | Nachricht wird in Verlauf angezeigt |

### Testfall C-004

| ID/Bezeichnung      | C-004                               |
| ------------------- | ----------------------------------- |
| Beschreibung        | Bild ohne Internet nicht versandbar |
| Testvoraussetzung   | Internetverbindung                  |
| Testzeitpunkt       | Ende                                |
| Testschritte        | Auswahl anklicken                   |
| Weiteres Vorgehen   | Mit Internet versenden (C-003)      |
| Erwartetes Ergebnis | Auswahl öffnet sich nicht           |

### Testfall C-005

| ID/Bezeichnung      | C-005                      |
| ------------------- | -------------------------- |
| Beschreibung        | Nur Bilder auswählbar      |
| Testvoraussetzung   | Internetverbindung         |
| Testzeitpunkt       | Ende                       |
| Testschritte        | Auswahl anklicken          |
|                     | PDF auswählen              |
| Weiteres Vorgehen   | -                          |
| Erwartetes Ergebnis | Nur Bilder sind auswählbar |

### Testfall C-006

| ID/Bezeichnung      | C-006                                           |
| ------------------- | ----------------------------------------------- |
| Beschreibung        | Chat verhält sich Responsive                    |
| Testvoraussetzung   | Nachrichten geladen                             |
| Testzeitpunkt       | Ende                                            |
| Testschritte        | Chat auf unterschiedlichen Gerätegrössen öffnen |
| Weiteres Vorgehen   | -                                               |
| Erwartetes Ergebnis | Bilder skalieren sich                           |
|                     | Bilder blieben links und rechts                 |

### Testfall C-007

| ID/Bezeichnung      | C-007                           |
| ------------------- | ------------------------------- |
| Beschreibung        | Nachricht werden empfangen      |
| Testvoraussetzung   | Anderer Nutzer                  |
| Testzeitpunkt       | Ende                            |
| Testschritte        | Chat öffnen                     |
|                     | Anderer Nutzer sendet Nachricht |
| Weiteres Vorgehen   | -                               |
| Erwartetes Ergebnis | Nachricht wird angezeigt        |

### Testfall C-008

| ID/Bezeichnung      | C-008                                 |
| ------------------- | ------------------------------------- |
| Beschreibung        | Plötzlich kein Internet               |
| Testvoraussetzung   | Internetverbindung                    |
| Testzeitpunkt       | Ende                                  |
| Testschritte        | Chat öffnen                           |
|                     | Internet ausschalten                  |
|                     | Anderer Nutzer sendet Nachricht       |
| Weiteres Vorgehen   | Plötzlich Internet (C-009)            |
| Erwartetes Ergebnis | Bestehende Nachrichten werden geladen |
|                     | Lokale Datenbank wird Verwendet       |

### Testfall C-009

| ID/Bezeichnung      | C-009                           |
| ------------------- | ------------------------------- |
| Beschreibung        | Plötzlich Internet              |
| Testvoraussetzung   | Keine Internetverbindung        |
| Testzeitpunkt       | Ende                            |
| Testschritte        | Chat öffnen                     |
|                     | Internet ausschalten            |
|                     | Anderer Nutzer sendet Nachricht |
|                     | Internet einschalten            |
| Weiteres Vorgehen   | Plötzlich kein Internet (C-008) |
| Erwartetes Ergebnis | Neue Nachrichten werden geladen |
|                     | Serverdatenbank wird Verwendet  |

## Testprotokoll

### Allgemeine Testfälle

| ID    | Status | Testdatum  | Tester        | Bemerkung                        |
| ----- | :----: | ---------- | ------------- | -------------------------------- |
| A-001 |   ✔️   | 07.06.2022 | M. Schumacher |                                  |
| A-002 |   ✔️   | 07.06.2022 | M. Schumacher |                                  |
| A-003 |   ✔️   | 07.06.2022 | M. Schumacher |                                  |
| A-004 |   ✔️   | 07.06.2022 | M. Schumacher |                                  |
| A-005 |   ❌   | 07.06.2022 | M. Schumacher | Nur Android und Windows getestet |
| A-006 |   ✔️   | 07.06.2022 | M. Schumacher |                                  |

### Datenbank

| ID    | Status | Testdatum  | Tester        | Bemerkung |
| ----- | :----: | ---------- | ------------- | --------- |
| D-001 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| D-002 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| D-003 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| D-004 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| D-005 |   ✔️   | 07.06.2022 | M. Schumacher |           |

### Login Testfälle

| ID    | Status | Testdatum  | Tester        | Bemerkung  |
| ----- | :----: | ---------- | ------------- | ---------- |
| L-001 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-002 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-003 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-004 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-005 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-006 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-007 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-008 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-009 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-010 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-011 |   ❌   | 07.06.2022 | M. Schumacher | Keine Zeit |
| L-012 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-013 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-014 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-015 |   ✔️   | 07.06.2022 | M. Schumacher |            |
| L-016 |   ✔️   | 07.06.2022 | M. Schumacher |            |

### Home-Seite

| ID    | Status | Testdatum  | Tester        | Bemerkung |
| ----- | :----: | ---------- | ------------- | --------- |
| H-001 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-002 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-003 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-004 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-005 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-006 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-007 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-008 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| H-009 |   ✔️   | 07.06.2022 | M. Schumacher |           |

### Chat

| ID    | Status | Testdatum  | Tester        | Bemerkung |
| ----- | :----: | ---------- | ------------- | --------- |
| C-001 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-002 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-003 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-004 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-005 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-006 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-007 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-008 |   ✔️   | 07.06.2022 | M. Schumacher |           |
| C-009 |   ✔️   | 07.06.2022 | M. Schumacher |           |
