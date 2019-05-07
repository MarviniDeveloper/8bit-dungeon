using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class Sequenz
    {
        // Boolean
        public bool boo_sequenz;

        // Texturen
        private List<Texture2D> li_tex_sequenz;

        // Kommarzahlen
        private float flo_timer;
        private float flo_transition;
        private float flo_speed;

        // Positionen
        private Vector2 vec_position;

        // Konstruktor
        public Sequenz(List<Texture2D> par_sequenz)
        {
            boo_sequenz = true;

            li_tex_sequenz  = par_sequenz;

            flo_timer       = 0;
            flo_transition  = 0;
            flo_speed       = 70.4f;

            vec_position    = new Vector2(0, 0);            
        }

        // Update-Funktion die mit der Spielzeit Arbeitet
        public void Update(GameTime gameTime)
        {
            flo_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.flo_timer >= 0.25)
            {
                if (vec_position.Y >= -1056)
                {
                    vec_position -= new Vector2(0, flo_speed);
                    if (flo_transition <= 1)
                    {
                        flo_transition += 0.075f;
                    }                    
                }
                else
                {
                    if (flo_transition >= 0)
                    {
                        flo_speed = 0;
                    }
                    flo_transition -= 0.075f;
                }
                if (flo_transition <= 0)
                {
                    boo_sequenz = false;
                }
                flo_timer = 0;
            }
        }

        // Draw-Funktion zeichnet alles
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(li_tex_sequenz[0], vec_position, Color.White * flo_transition);
            spriteBatch.Draw(li_tex_sequenz[1], new Vector2(1075, 325), Color.White * flo_transition);
            spriteBatch.End();
        }
    }
}
