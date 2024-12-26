using System;
using System.Drawing;


namespace ClickPointGame
{
    public class Target
    {
        public int x;
        public int y;
        public int radius;
        public int mX;
        public int mY;
        public bool isDead = false;
        public long timeMet;
        public DateTime dateOfBirth;
        public long ageSize;
        public long ageDead;
        public int line;
        public int trend;

        public Target(int sX, int sY, int radius)
        {
            this.x = sX;
            this.y = sY;
            this.radius = radius;
            // Berechnet die mittleren X- und Y-Koordinaten des Ziels
            this.mX = sX + sY + radius;
            this.mY = sY + radius;

            dateOfBirth = DateTime.Now;
            // Setzt die Lebensdauer des Ziels
            this.ageSize = 1000;
            this.ageDead = 2000;
        }

        /// <summary>
        /// Gibt ein verkleinertes Rechteck des Ziels zurück.
        /// </summary>
        /// <param name="radius">Der neue Radius des Ziels.</param>
        /// <returns>Ein Rechteck, das das verkleinerte Ziel darstellt.</returns>
        public Rectangle GetShrinkedRectangle(int radius)
        {
            // Speichert den alten Radius
            int altRadius = this.radius;
            // Setzt den neuen Radius
            this.radius = radius;
            int width = 0;
            int height = 0;

            // Berechnet die Differenz zwischen dem neuen und dem alten Radius
            int differnzRadius = radius - altRadius;
            // Passt die Position des Ziels basierend auf der Radiusänderung an
            x -= differnzRadius;
            y -= differnzRadius;
            // Berechnet die Breite und Höhe des neuen Rechtecks
            width = this.radius * 2;
            height = this.radius * 2;
            // Aktualisiert die mittleren X- und Y-Koordinaten des Ziels
            mX = x + this.radius;
            mY = y + this.radius;

            // Gibt das neue Rechteck zurück
            return new Rectangle(x, y, width, height);
        }
    }
}
