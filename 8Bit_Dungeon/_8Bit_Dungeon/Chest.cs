using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class Chest
    {
        // Positionen
        public Vector2 pos_Chest;
        public int stage_pos_Chest;

        // Hitbox
        public Rectangle rec_hitbox;

        // Boolean
        public bool boo_loot;
        public bool boo_animation;

        // Goldwert
        public int int_loot;

        // Zufällige Zahl
        private Random rnd_loot;

        // Animationen
        private SpriteSheet spr_chest;

        // Texturen
        private Texture2D tex_chest;

        // Kommerzahlen
        private float flo_timer;

        // Konstruktor
        public Chest(   Vector2 par_position, 
                        List<Texture2D> par_assets,
                        int par_stage)
        {
            stage_pos_Chest = par_stage;

            pos_Chest   = par_position;

            rec_hitbox  = new Rectangle((int)pos_Chest.X - 32, (int)pos_Chest.Y - 32, 96, 96);

            boo_loot      = true;
            boo_animation = true;

            rnd_loot    = new Random();

            int_loot    = rnd_loot.Next(0, 25);

            tex_chest   = par_assets[0];

            spr_chest   = new SpriteSheet(tex_chest, 1, 10);
        }

        // Update-Funktion die mit der Spielzeit Arbeitet
        public void Update(GameTime gameTime)
        {
            this.flo_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.flo_timer >= 0.25)
            {                
                if (boo_animation)
                {
                    int_loot = rnd_loot.Next(0, 25);
                    spr_chest.Update();
                    this.flo_timer = 0;
                }
            }
        }

        // Draw-Funktion zeichnet alles
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spr_chest.Draw(spriteBatch, pos_Chest, 0);
            spriteBatch.End();
        }
    }
}
