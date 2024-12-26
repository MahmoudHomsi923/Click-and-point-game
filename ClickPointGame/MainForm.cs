using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;


namespace ClickPointGame
{
    public partial class MainForm : Form
    {
        // Synchronisationsobjekt für Thread-Sicherheit
        private static object Sync;
        // Liste zur Speicherung von Zielobjekten
        private static List<Target> TargetsList = new List<Target>();
        // Liste zur Speicherung von Mausklick-Objekten
        private static List<MausClick> MausClickList = new List<MausClick>();
        // Zähler für Frames pro Sekunde
        private static int Fps = 0;
        // Zeitstempel, wann das Menü zuletzt gestoppt wurde
        private static DateTime TimeMenuStop = new DateTime();
        // Zeitdifferenz zwischen Menüstopps
        private static TimeSpan TimeDiffernze = new TimeSpan();
        // Geschwindigkeit der Spielelemente
        private static int Tempo = 2;
        // Flag, um anzuzeigen, ob das Spiel im Spielmodus ist
        private static bool PlayModeOn = false;

        // Konstanten für die Zähler
        private const string LevelCounter = "1";
        private const string LifeCounter = "10";
        private const string PointsCounter = "0";
        private const string FSPCounter = "0";
        private const string TimeCounter = "180";

        // Konstanten für die XML-Elemente
        private const string Scores = "Scores";
        private const string Highscore = "Highscore";

        public MainForm()
        {
            // Sync-Objekt erstellen
            Sync = new object();
            InitializeComponent();
            // KeyPreview aktivieren
            this.KeyPreview = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Icon festlegen
            this.Icon = Resources.Resources.AppIcon;
            // Hintergrundbild festlegen
            this.BackgroundImage = Resources.Resources.AppBackgrundImage;
            // Zähler initialisieren
            LoadHighscore();
            lblLevelCounter.Text = LevelCounter;
            lblLifeCounter.Text = LifeCounter;
            lblPointsCounter.Text = PointsCounter;
            lblFSPCounter.Text = FSPCounter;
            lblTimeCounter.Text = TimeCounter;
            // Menüelemente einblenden
            lblGameMenu.Text = "Game Start";
            lblGameMenu.Visible = true;
            rdbtnEasy.Visible = true;
            rdbtnMedium.Visible = true;
            rdbtnHard.Visible = true;
            btnStart.Visible = true;
            btnResume.Visible = false;
            btnRestart.Visible = false;
            btnExit.Visible = false;   
        }

        private void rdbtnEasy_CheckedChanged(object sender, EventArgs e)
        {
            // Geschwindigkeit festlegen
            Tempo = 2;
        }

        private void rdbtnMedium_CheckedChanged(object sender, EventArgs e)
        {
            // Geschwindigkeit festlegen
            Tempo = 4;
        }

        private void rdbtnHard_CheckedChanged(object sender, EventArgs e)
        {
            // Geschwindigkeit festlegen
            Tempo = 6;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            ResumeGame();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitGame();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                StopGame();
            }
        }

        private void TimerKreis_Tick(object sender, EventArgs e)
        {
            // Sperre setzen
            lock (Sync)
            {
                // Zeichne Hintergrundbild
                Bitmap Bitmap = new Bitmap(Resources.Resources.AppBackgrundImage);
                Graphics GFX = Graphics.FromImage(Bitmap);

                // Zeichne Ziele
                for (int i = 0; i < TargetsList.Count; i++)
                {
                    // Ziel ist jünger als 1 Sekund
                    if ((DateTime.Now - TargetsList[i].dateOfBirth).TotalMilliseconds < 1000)
                    {
                        if (TargetsList[i].isDead == false)
                        {
                            // Zeichne lebendes Ziel
                            int radius = (int)(60 * (DateTime.Now - TargetsList[i].dateOfBirth).TotalMilliseconds / 1000);
                            GFX.FillEllipse(Brushes.Red, TargetsList[i].GetShrinkedRectangle(radius));
                            GFX.DrawEllipse(Pens.Black, TargetsList[i].GetShrinkedRectangle(radius));
                            GFX.DrawEllipse(Pens.Black, TargetsList[i].GetShrinkedRectangle(radius + 1));
                        }
                        else
                        {
                            // Zeichne getroffenes Ziel
                            GFX.FillEllipse(Brushes.Transparent, new Rectangle(TargetsList[i].x, TargetsList[i].y, 120, 120));
                            Font font1 = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Point);
                            GFX.DrawString("Get!!!", font1, new SolidBrush(Color.Black), TargetsList[i].x + 20, TargetsList[i].y + 20);
                            GFX.DrawString(TargetsList[i].timeMet.ToString(), font1, new SolidBrush(Color.Black), TargetsList[i].x + 30, TargetsList[i].y + 30);
                        }
                    }
                    else
                    {
                        if (TargetsList[i].isDead == false)
                        {
                            // Zeichne lebendes Ziel, das älter als 1 Sekunde ist
                            int radius = (int)(60 * ((2000 - (DateTime.Now - TargetsList[i].dateOfBirth).TotalMilliseconds) / 1000));
                            GFX.FillEllipse(Brushes.Red, TargetsList[i].GetShrinkedRectangle(radius));
                            GFX.DrawEllipse(Pens.Black, TargetsList[i].GetShrinkedRectangle(radius));
                            GFX.DrawEllipse(Pens.Black, TargetsList[i].GetShrinkedRectangle(radius - 1));

                            // Entferne Ziel, wenn der Radius 0 erreicht
                            if (TargetsList[i].radius <= 0)
                            {
                                lblLifeCounter.Text = (Int32.Parse(lblLifeCounter.Text) - 1).ToString();
                                TargetsList.RemoveAt(i);
                            }
                        }
                        else
                        {
                            // Zeichne getroffenes Ziel, das älter als 1 Sekunde ist
                            GFX.FillEllipse(Brushes.Transparent, new Rectangle(TargetsList[i].x, TargetsList[i].y, 120, 120));
                            Font font1 = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Point);
                            GFX.DrawString("Get!!!", font1, new SolidBrush(Color.Black), TargetsList[i].x + 20, TargetsList[i].y + 20);
                            GFX.DrawString(TargetsList[i].timeMet.ToString(), font1, new SolidBrush(Color.Black), TargetsList[i].x + 30, TargetsList[i].y + 40);

                            // Entferne Ziel, wenn es tot ist und die Zeit abgelaufen ist
                            if ((DateTime.Now - TargetsList[i].dateOfBirth).TotalMilliseconds >= TargetsList[i].ageDead)
                            {
                                TargetsList.RemoveAt(i);
                            }
                        }
                    }
                }

                // Zeichne Mausklicks
                for (int j = 0; j < MausClickList.Count; j++)
                {
                    if ((DateTime.Now - MausClickList[j].dateOfBirth).TotalMilliseconds < 1000)
                    {
                        GFX.FillEllipse(Brushes.Transparent, new Rectangle(MausClickList[j].x, MausClickList[j].y, 60, 60));
                        Font font1 = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Point);
                        GFX.DrawString("Miss!!!", font1, new SolidBrush(Color.Black), MausClickList[j].x, MausClickList[j].y);
                    }
                    else
                    {
                        MausClickList.RemoveAt(j);
                    }
                }
                // Setze Hintergrundbild und erhöhe FPS
                BackgroundImage = Bitmap;
                Fps++;
                MoveKreis();
            }
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            // Sperre setzen
            lock (Sync)
            {
                // Aktualisiere den Zeit- und FPS-Zähler
                lblTimeCounter.Text = (Int32.Parse(lblTimeCounter.Text) - 1).ToString();
                lblFSPCounter.Text = Fps.ToString();
                Fps = 0;

                // Überprüfe, ob die Zeit abgelaufen ist
                if (lblTimeCounter.Text.Equals("0"))
                {
                    EndGame();
                }
            }
        }

        private void TimerCreat_Tick(object sender, EventArgs e)
        {
            // Sperre setzen
            lock (Sync)
            {
                // Wartezeit basierend auf dem Level
                double waitTime = 2 / Int32.Parse(lblLevelCounter.Text);

                // Überprüfe, ob das Level 1 ist
                if (lblLevelCounter.Text.Equals("1"))
                {
                    if (GetNumberLiveItems() == 0)
                        Creat(1);
                }
                else
                {
                    // Erstelle neue Ziele basierend auf der Levelanzahl
                    if (GetNumberLiveItems() < Int32.Parse(lblLevelCounter.Text))
                    {
                        // Überprüfe, ob die Wartezeit abgelaufen ist
                        if ((DateTime.Now - TargetsList[TargetsList.Count - 1].dateOfBirth).TotalMilliseconds >= waitTime)
                        {
                            Creat(1);
                        }
                    }
                }
            }

        }

        private void TimerLive_Tick(object sender, EventArgs e)
        {
            // Sperre setzen
            lock (Sync)
            {
                int lifeCounter = Int32.Parse(lblLifeCounter.Text);
                // Überprüfen, ob der Lebenszähler auf 0 steht
                if (lifeCounter <= 0)
                {
                    // Spiel verlieren, wenn keine Leben mehr übrig sind
                    LoseGame();
                }
            }
        }
        private void TimerLevel_Tick(object sender, EventArgs e)
        {
            // Sperre setzen
            lock (Sync)
            {
                // Level erhohen
                lblLevelCounter.Text = (Int32.Parse(lblLevelCounter.Text) + 1).ToString();
                // Live new
                lblLifeCounter.Text = LifeCounter;
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (PlayModeOn)
            {
                lock (Sync)
                {
                    MouseEventArgs ME = (MouseEventArgs)e;
                    bool isMet = false;

                    for (int i = 0; i < TargetsList.Count; i++)
                    {
                        // Rigth Shot
                        if (Math.Sqrt(Math.Pow((ME.X - TargetsList[i].mX), 2) + Math.Pow((ME.Y - TargetsList[i].mY), 2)) <= TargetsList[i].radius && TargetsList[i].isDead == false)
                        {
                            TargetsList[i].isDead = true;
                            TargetsList[i].ageDead = 3000;
                            lblPointsCounter.Text = (Int32.Parse(lblPointsCounter.Text) + 1).ToString();
                            TargetsList[i].timeMet = (long)(DateTime.Now - TargetsList[i].dateOfBirth).TotalMilliseconds;
                            isMet = true;
                            //break;
                        }
                    }
                    // Rong Shot
                    if (isMet == false)
                    {
                        // Reduziere den Lebenszähler
                        int lifeCounter = Int32.Parse(lblLifeCounter.Text);
                        lblLifeCounter.Text = (lifeCounter - 1).ToString();
                        if (lifeCounter <= 0)
                        {
                            LoseGame();
                        }
                        // Füge den Mausklick zur Liste hinzu
                        MausClickList.Add(new MausClick(ME.X, ME.Y, 60));
                    }
                }
            }
        }

        /// <summary>
        /// Diese Methode erstellt ein neues Ziel (Target) mit einem gegebenen Radius
        /// </summary>
        /// <param name="radius">Einzusetzendes Radius</param>
        public void Creat(int radius)
        {
            bool isPlaced = false;
            Target target = null;

            Random random = new Random();

            int mX;
            int mY;

            // Wenn keine Ziele vorhanden sind, erstelle das erste Ziel
            if (TargetsList.Count == 0)
            {
                // Rand Kontrolle
                while (true)
                {
                    target = new Target(random.Next(1200), random.Next(800), radius);
                    mX = target.x + 60;
                    mY = target.y + 60;
                    if (mX - 200 >= 1 && mX + 200 < 1200 && mY - 200 >= 1 && mY + 200 < 800)
                        break;
                }
                target.line = random.Next(2);
                target.trend = random.Next(2);
                TargetsList.Add(target);
            }
            // Wenn bereits Ziele vorhanden sind, erstelle ein neues Ziel
            else if (TargetsList.Count > 0)
            {
                isPlaced = false;
                while (isPlaced == false)
                {
                    // Rand Kontrolle
                    while (true)
                    {
                        target = new Target(random.Next(1200), random.Next(800), radius);
                        mX = target.x + 60;
                        mY = target.y + 60;
                        if (mX - 200 >= 1 && mX + 200 < 1200 && mY - 200 >= 1 && mY + 200 < 800)
                            break;
                        //if (mX - 120 >= 1 && mX + 120 < 1200 && mY - 120 - 80 >= 1 && mY + 120 < 800)
                        //    break;
                    }
                    // Kollision Kontrolle
                    for (int i = 0; i < TargetsList.Count; i++)
                    {
                        if (Math.Sqrt(Math.Pow(((mX) - TargetsList[i].mX), 2) + Math.Pow(((mY) - TargetsList[i].mY), 2)) <= 120)
                        {
                            isPlaced = false;
                            break;
                        }
                        else
                        {
                            isPlaced = true;
                        }
                    }
                }
                // Setze die Linie des Ziels auf einen zufälligen Wert (0 oder 1)
                target.line = random.Next(2);
                // Setze den Trend des Ziels auf einen zufälligen Wert (0 oder 1)
                target.trend = random.Next(2);
                // Füge das Ziel der Liste der Ziele hinzu
                TargetsList.Add(target);
            }
        }

        /// <summary>
        /// Startet das Spiel und initialisiert alle notwendigen Komponenten.
        /// </summary>
        private void StartGame()
        {
            // Spielmodus aktivieren
            PlayModeOn = true;
            // Listen leeren
            TargetsList.Clear();
            MausClickList.Clear();
            // BackgroundImage neu setzen
            this.BackgroundImage = Resources.Resources.AppBackgrundImage;
            // Zähler zurücksetzen
            LoadHighscore();
            lblLevelCounter.Text = LevelCounter;
            lblLifeCounter.Text = LifeCounter;
            lblPointsCounter.Text = PointsCounter;
            lblFSPCounter.Text = FSPCounter;
            lblTimeCounter.Text = TimeCounter;
            // Menüelemente ausblenden
            lblGameMenu.Visible = false;
            rdbtnEasy.Visible = false;
            rdbtnMedium.Visible = false;
            rdbtnHard.Visible = false;
            btnResume.Visible = false;
            btnRestart.Visible = false;
            btnExit.Visible = false;
            btnStart.Visible = false;
            // Timers starten
            OnOffTimer(true);
        }

        /// <summary>
        /// Stoppt das Spiel und zeigt das Menü an.
        /// </summary>
        private void StopGame()
        {
            // Stoptime speichern
            TimeMenuStop = DateTime.Now;
            // Timer stopen
            OnOffTimer(false);
            // Spielmodus aktivieren
            PlayModeOn = false;
            // Menüelemente einblenden
            lblGameMenu.Text = "Game Resume";
            lblGameMenu.Visible = true;
            rdbtnEasy.Visible = false;
            rdbtnMedium.Visible = false;
            rdbtnHard.Visible = false;
            btnStart.Visible = false;
            btnResume.Visible = true;
            // Fokus auf Resume-Button setzen
            btnResume.Focus();
            btnRestart.Visible = true;
            btnExit.Visible = true;  
        }

        /// <summary>
        /// Setzt das Spiel fort und aktualisiert die notwendigen Komponenten.
        /// </summary>
        private void ResumeGame()
        {
            // Spielmodus aktivieren
            PlayModeOn = true;
            // Menüelemente einblenden
            lblGameMenu.Visible = false;
            rdbtnEasy.Visible = false;
            rdbtnMedium.Visible = false;
            rdbtnHard.Visible = false;
            btnResume.Visible = false;
            btnRestart.Visible = false;
            btnExit.Visible = false;
            btnStart.Visible = false;
            // Zeitdifferenz berechnen
            TimeDiffernze = DateTime.Now - TimeMenuStop;
            for (int i = 0; i < TargetsList.Count; i++)
            {
                TargetsList[i].dateOfBirth += TimeDiffernze;
            }
            // Timers starten
            OnOffTimer(true);
        }

        /// <summary>
        /// Beendet das Spiel und zeigt das "Game Over"-Menü an.
        /// </summary>
        private void LoseGame()
        {
            // Timers Stopen
            OnOffTimer(false);
            // Spielmodus daktivieren
            PlayModeOn = false;
            // Highscore aktualisieren
            UpdateHighscore();
            // Menüelemente einblenden
            lblGameMenu.Text = "Game Over";
            lblGameMenu.Visible = true;
            rdbtnEasy.Visible = true;
            rdbtnMedium.Visible = true;
            rdbtnHard.Visible = true;
            btnResume.Visible = false;
            btnRestart.Visible = true;
            // Fokus auf Restart-Button setzen
            btnRestart.Focus();
            btnExit.Visible = true;
            btnStart.Visible = false;
            
        }

        /// <summary>
        /// Beendet das Spiel und zeigt das "Game Ende"-Menü an.
        /// </summary>
        private void EndGame()
        {
            // Timers Stopen
            OnOffTimer(false);
            // Spielmodus daktivieren
            PlayModeOn = false;
            // Highscore aktualisieren
            UpdateHighscore();
            // Menüelemente einblenden
            lblGameMenu.Text = "Game Ende";
            lblGameMenu.Visible = true;
            rdbtnEasy.Visible = true;
            rdbtnMedium.Visible = true;
            rdbtnHard.Visible = true;
            btnResume.Visible = false;
            btnRestart.Visible = true;
            // Fokus auf Restart-Button setzen
            btnRestart.Focus();
            btnExit.Visible = true;
            btnStart.Visible = false;
        }

        /// <summary>
        /// Beendet das Spiel und schließt die Anwendung.
        /// </summary>
        private void ExitGame()
        {
            // Highscore aktualisieren
            UpdateHighscore();
            // Anwendung beenden
            Application.Exit();
        }

        /// <summary>
        /// Diese Methode gibt die Anzahl der lebenden Ziele (Targets) zurück
        /// </summary>
        public int GetNumberLiveItems()
        {
            int counter = 0;

            // Durchlaufe die Liste der Ziele
            for (int i = 0; i < TargetsList.Count; i++)
            {
                // Überprüfe, ob das Ziel nicht tot ist
                if (TargetsList[i].isDead == false)
                    counter++; // Erhöhe den Zähler für lebende Ziele
            }
            return counter; // Rückgabe der Anzahl der lebenden Ziele
        }

        /// <summary>
        /// Überprüft, ob das Ziel kollisionsfrei ist.
        /// </summary>
        /// <param name="target">Das zu überprüfende Ziel.</param>
        /// <returns>Gibt true zurück, wenn das Ziel kollisionsfrei ist, andernfalls false.</returns>
        private bool IsKollesionFrei(Target target)
        {
            bool result = false;

            // Rand Kollision Kontrolle 
            if (target.line == 0)
            {
                if (target.trend == 0)
                {
                    // Überprüfen, ob das Ziel innerhalb der rechten Grenze liegt
                    if (target.mX + 260 < 1200)
                        result = true;
                }
                if (target.trend == 1)
                {
                    // Überprüfen, ob das Ziel innerhalb der linken Grenze liegt
                    if (target.mX - 120 >= 1)
                        result = true;
                }
            }
            if (target.line == 1)
            {
                if (target.trend == 0)
                {
                    // Überprüfen, ob das Ziel innerhalb der oberen Grenze liegt
                    if (target.mY - 140 >= 1)
                        result = true;
                }
                if (target.trend == 1)
                {
                    // Überprüfen, ob das Ziel innerhalb der unteren Grenze liegt
                    if (target.mY + 240 <= 800)
                        result = true;
                }
            }
            
            return result;
        }

        /// <summary>
        /// Setzt eine neue Linie und Richtung für das Ziel.
        /// </summary>
        /// <param name="target">Das Ziel, für das die Linie und Richtung gesetzt werden.</param>
        private void LineAndTrendNew(Target target)
        {
            Random random = new Random();

            // Setzt eine zufällige Linie (0 oder 1)
            target.line = random.Next(2);
            // Setzt eine zufällige Richtung (0 oder 1)
            target.trend = random.Next(2);
        }

        /// <summary>
        /// Bewegt die Ziele (Kreise) basierend auf ihrer Linie und Richtung.
        /// </summary>
        private void MoveKreis()
        {
            for (int i = 0; i < TargetsList.Count; i++)
            {
                if (TargetsList[i].isDead == false)
                {
                    // Stelle sicher, dass das Ziel kollisionsfrei ist
                    while (IsKollesionFrei(TargetsList[i]) == false)
                    {
                        LineAndTrendNew(TargetsList[i]);
                    }

                    // Horizontal bewegen
                    if (TargetsList[i].line == 0)
                    {
                        // Rechts bewegen
                        if (TargetsList[i].trend == 0)
                        {
                            TargetsList[i].x += Tempo;
                            TargetsList[i].mX = TargetsList[i].x + TargetsList[i].radius;
                        }
                        // Links bewegen
                        else
                        {
                            TargetsList[i].x -= Tempo;
                            TargetsList[i].mX = TargetsList[i].x + TargetsList[i].radius;
                        }
                    }
                    // Vertikal bewegen
                    else
                    {
                        // Oben bewegen
                        if (TargetsList[i].trend == 0)
                        {
                            TargetsList[i].y -= Tempo;
                            TargetsList[i].mY = TargetsList[i].y + TargetsList[i].radius;
                        }
                        // Unten bewegen
                        else
                        {
                            TargetsList[i].y += Tempo;
                            TargetsList[i].mY = TargetsList[i].y + TargetsList[i].radius;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Lädt den Highscore aus einer XML-Datei.
        /// </summary>
        /// <exception cref="Exception">Wird ausgelöst, wenn ein Fehler beim Laden des Highscores auftritt.</exception>
        private void LoadHighscore()
        {
            try
            {
                // Ermitteln des aktuellen Verzeichnisses
                DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
                // Ermitteln des übergeordneten Verzeichnisses
                string parentDirectory = currentDirectory.Parent.Parent.FullName;
                // Speichern der aktualisierten XML-Datei
                string filePath = Path.Combine(parentDirectory, "Resources", "AppXml.xml");

                XDocument doc = XDocument.Load(filePath);
                XElement highscoreElement = doc.Element(nameof(Scores))?.Element(nameof(Highscore));
                if (highscoreElement != null)
                {
                    lblHighScoreCounter.Text = highscoreElement.Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Laden des Highscores", ex);
            }
        }

        /// <summary>
        /// Speichert den Highscore in einer XML-Datei.
        /// </summary>
        /// <param name="highscore">Der Score zu speichern</param>
        /// <exception cref="Exception">Wird ausgelöst, wenn ein Fehler beim Speichern des Highscores auftritt.</exception>
        private void SaveHighscore(int highscore)
        {
            try
            {
                // Laden der XML-Datei aus den Ressourcen
                string xmlContent = Resources.Resources.AppXml;
                XDocument doc = XDocument.Parse(xmlContent);
                XElement highscoreElement = doc.Element(nameof(Scores))?.Element(nameof(Highscore));
                if (highscoreElement != null)
                {
                    highscoreElement.Value = highscore.ToString();
                }
                else
                {
                    XElement scoresElement = new XElement(nameof(Scores));
                    highscoreElement = new XElement(nameof(Highscore), highscore.ToString());
                    scoresElement.Add(highscoreElement);
                    doc.Add(scoresElement);
                }

                // Ermitteln des aktuellen Verzeichnisses
                DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
                // Ermitteln des übergeordneten Verzeichnisses
                string parentDirectory = currentDirectory.Parent.Parent.FullName;
                // Speichern der aktualisierten XML-Datei
                string filePath = Path.Combine(parentDirectory, "Resources", "AppXml.xml");
                doc.Save(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Speichern des Highscores", ex);
            }
        }

        /// <summary>
        /// Aktualisiert den Highscore, wenn der aktuelle Score höher ist.
        /// </summary>
        private void UpdateHighscore()
        {
            int currentScore = int.Parse(lblPointsCounter.Text);
            int highscore = int.Parse(lblHighScoreCounter.Text);

            // Überprüfen, ob der aktuelle Score höher als der Highscore ist
            if (currentScore > highscore)
            {
                // Speichern des neuen Highscores
                SaveHighscore(currentScore);
            }
        }

        /// <summary>
        /// Setzt die Benutzeroberfläche zurück und aktualisiert den Highscore.
        /// </summary>
        private void ResetUi()
        {
            // Aktualisiert den Highscore, falls der aktuelle Score höher ist
            UpdateHighscore();

            // Setzt die Labels auf ihre Standardwerte zurück
            lblLevelCounter.Text = LevelCounter;
            lblLifeCounter.Text = LifeCounter;
            lblPointsCounter.Text = PointsCounter;
            lblFSPCounter.Text = FSPCounter;
            lblTimeCounter.Text = TimeCounter;
        }

        /// <summary>
        /// Startet oder stoppt die Timer basierend auf dem übergebenen Parameter.
        /// </summary>
        /// <param name="On">Wenn true, werden die Timer gestartet; andernfalls werden sie gestoppt.</param>
        private void OnOffTimer(bool On)
        {
            if (On)
            {
                // Startet alle Timer
                TimerCreat.Start();
                TimerLive.Start();
                TimerTime.Start();
                TimerKreis.Start();
                TimerLevel.Start();
            }
            else
            {
                // Stoppt alle Timer
                TimerCreat.Stop();
                TimerLive.Stop();
                TimerTime.Stop();
                TimerKreis.Stop();
                TimerLevel.Stop();
            }
        }
    }
}

