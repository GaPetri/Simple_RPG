# SimpleRPG
# Dokumentation für SimpleRPG
## Übersicht
**SimpleRPG** ist ein textbasiertes Rollenspiel (RPG) in C#, das es dem Spieler ermöglicht, in eine 
kleine, aber aufregende Abenteuerwelt einzutauchen. Der Spieler kann aus drei Standardklassen 
wählen, verschiedenen Gegnern gegenübertreten, sich in der Umwelt bewegen und Handlungen 
ausführen. Das Spiel verfügt über ein Level-Up-System, Kampfmechaniken sowie Lade- und 
Speicherfunktionen.
## Features
1. **Klassenauswahl**: Der Spieler wählt zu Beginn des Spiels eine von drei Standardklassen.
2. **Benutzereingabe**: Die Interaktion erfolgt über die Konsole mittels `ReadLine`. Es gibt eine 
Wortfilterfunktion, um Benutzereingaben zu validieren.
3. **Speichern und Laden**: Das Spiel bietet Checkpoint-Speicherung und eine Funktion zum Laden 
des Spielstands.
4. **Charakterattribute**: Jeder Charakter hat spezifische Attribute, die im Laufe des Spiels 
verbessert werden können.
## Spielablauf
### Start
Das Spiel beginnt mit der Auswahl der Charakterklasse. Der Spieler wählt eine der folgenden Klassen:
1. **Krieger**: Hohe Stärke.
2. **Magier**: Hohe Magie.
3. **Bogenschütze**: Hohe Geschicklichkeit.
### Abenteurer
Nach der Klassenauswahl beginnt das Abenteuer. Der Spieler startet an einem festgelegten Punkt 
und kann verschiedene Wege erkunden. Jede Entscheidung beeinflusst den weiteren Verlauf des 
Spiels.
#### Kampfmechaniken
Der Spieler trifft auf verschiedene Gegner. Die Kämpfe sind rundenbasiert und beinhalten folgende 
Aktionen:
- **Angriff**: Standardangriff basierend auf der Klasse.
- **Spezialfähigkeiten**: Klassenbasierte Fähigkeiten
-**Verteidigen**: Reduziert den eingehenden Schaden.
- **Heilen**: Fähigkeiten zur Wiederherstellung der Gesundheit.
### Umweltbeschreibungen
Das Spiel bietet detaillierte Beschreibungen der Umwelt, die zur Atmosphäre und Immersion 
beitragen. Die Spieler erhalten Hinweise darauf, was sie tun können,

Verworfen  z.B.:
- Untersuchen von Objekten.
- Interagieren mit NPCs.
- Finden von Gegenständen.
### Level-Up-System
Der Spieler sammelt Erfahrungspunkte (XP) durch das Besiegen von Gegnern und das Abschließen 
von Quests. Mit genügend XP steigt der Charakter im Level auf, was die Attribute verbessert und 
neue Fähigkeiten freischaltet.
### Speicher- und Ladefunktion
Das Spiel speichert den Fortschritt an bestimmten Checkpoints automatisch. Der Spieler kann den 
Spielstand jederzeit manuell speichern und später laden.
