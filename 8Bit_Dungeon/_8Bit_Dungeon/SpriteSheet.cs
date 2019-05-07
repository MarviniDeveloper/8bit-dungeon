using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class SpriteSheet
    {
        // SpriteSheet
        public Texture2D Texture;

        // Ganzzahlen
        public int Zeilen;
        public int Spalten;
        public int Spalte;
        private int anzFrame;
        public int aktFrame;

        public SpriteSheet(Texture2D texture, int zeilen, int spalten)
        {
            this.Texture = texture;
            this.Zeilen = zeilen;
            this.Spalten = spalten;
            this.aktFrame = 0;
            this.anzFrame = Zeilen * Spalten;
        }

        public void Update()
        {
            aktFrame++;
            if (aktFrame == anzFrame)
            {
                aktFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, int zeile)
        {
            int breite = Texture.Width / Spalten;
            int hoehe = Texture.Height / Zeilen;

            Spalte = aktFrame % Spalten;

            Rectangle rechteck1 = new Rectangle(breite * Spalte, hoehe * zeile, breite, hoehe);
            Rectangle rechteck2 = new Rectangle((int)position.X, (int)position.Y, breite, hoehe);
            spriteBatch.Draw(Texture, rechteck2, rechteck1,  Color.White);
        }
    }
}
