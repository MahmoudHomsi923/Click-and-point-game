# Click-and-point-game
C# WinForms desktop game

![grafik](https://github.com/user-attachments/assets/5331d03e-7810-4a6f-be0b-2fff58b386e2)

Point-and-Click Game ist ein 2D-WinForms-Desktopspiel, entwickelt in C#. Das Spiel basiert auf der Darstellung und Steuerung von bewegenden Objekten (Bällen) mithilfe von Bitmaps und Timern.

Spielmechanik

- Ziel des Spiels:
  Klicke mit der linken Maustaste auf die erscheinenden Bälle, um Punkte zu sammeln.
  Verfehlst du oder klickst an eine falsche Stelle, verlierst du Leben.

Features

- Level-Modi:
  Wähle zwischen Easy, Medium und Hard.
  Die Schwierigkeit beeinflusst die Bewegungsgeschwindigkeit der Bälle.
- Levelaufstieg:
  Das Level erhöht sich alle 15 Sekunden.
  Mit jedem neuen Level erscheinen mehr Bälle (z. B. Level 1 = 1 Ball, Level 2 = 2 Bälle usw.).
  Die Lebensanzahl wird bei jedem Levelaufstieg zurückgesetzt.
- Punkte und Leben:
  Punkte werden durch erfolgreiche Treffer auf die Bälle erzielt.
  Ein verfehlter Ball oder ein Klick auf eine leere Stelle verringert die Lebensanzahl.
  Bei einem Treffer wird der Text "Get!" angezeigt, bei einem Fehlversuch "Miss!".
- Highscore:
  Der höchste erreichte Score wird in einer XML-Datei gespeichert.
- Steuerung:
  Drücke S, um das Spiel zu pausieren oder fortzusetzen.
-Anzeigeelemente:
 Highscore: Der höchste erreichte Punktestand.
 Life: Aktuelle Lebensanzahl (maximal 10).
 Points: Die aktuellen Punkte im Spiel.
 FPS: Die Anzahl der pro Sekunde gezeichneten Kreise.
 Time: Verbleibende Spielzeit in Sekunden.
