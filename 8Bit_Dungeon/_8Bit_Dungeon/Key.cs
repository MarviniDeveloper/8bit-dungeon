using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class Key
    {
        // Positionen
        public Vector2 pos_Key;
        public int stage_pos_Key;

        // Hitbox
        public Rectangle rec_hitbox;

        // Boolean
        public bool boo_loot;

        // Animationen
        private SpriteSheet sprite_key;

        // Texturen
        private Texture2D tex_key;

        // Kommerzahlen
        private float flo_timer;

        // Konstruktor
        public Key(Vector2 position,
                    List<Texture2D> assets,
                    int par_stage)
        {
            stage_pos_Key = par_stage;

            pos_Key = position;

            rec_hitbox = new Rectangle((int)pos_Key.X - 32, (int)pos_Key.Y - 32, 96, 96);

            boo_loot = true;

            tex_key = assets[1];

            sprite_key = new SpriteSheet(tex_key, 1, 10);
        }

        // Update-Funktion die mit der Spielzeit Arbeitet
        public void Update(GameTime gameTime)
        {
            this.flo_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.flo_timer >= 0.225)
            {
                sprite_key.Update();
                this.flo_timer = 0;
            }
        }

        // Draw-Funktion zeichnet alles
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            sprite_key.Draw(spriteBatch, pos_Key, 0);
            spriteBatch.End();
        }
    }
}
