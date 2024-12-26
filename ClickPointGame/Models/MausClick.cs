using System;

namespace ClickPointGame
{
    public class MausClick
    {
        public int x;
        public int y;
        public int radius;
        public DateTime dateOfBirth;

        public MausClick(int mX, int mY, int sRadius)
        {
            this.x = mX;
            this.y = mY;
            this.radius = sRadius;
            dateOfBirth = DateTime.Now;
        }
    }
}
