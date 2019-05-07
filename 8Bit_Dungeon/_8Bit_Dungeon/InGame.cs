using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class InGame
    {
        private State state;

        // Objekte
        private Player  obj_player;
        private Map     obj_map;
        private Sequenz obj_sequenz;

        // Schriftarten
        private List<SpriteFont> li_fonts;

        // Texturen
        private List<Texture2D> li_tex_level;
        private List<Texture2D> li_tex_player;
        private List<Texture2D> li_tex_assets;

        Texture2D test;

        // Konstruktor
        public InGame(  State par_state, 
                        List<SpriteFont> par_fonts, 
                        List<Texture2D> par_level, 
                        List<Texture2D> par_player, 
                        List<Texture2D> par_assets,
                        List<Texture2D> par_sequenz,
                        Texture2D test)
        {
            state = par_state;

            li_fonts        = par_fonts;

            li_tex_level    = par_level;
            li_tex_player   = par_player;
            li_tex_assets   = par_assets;

            this.test = test;

            obj_map         = new Map(li_tex_level, li_tex_assets, test);
            obj_player      = new Player(li_tex_player, li_fonts, obj_map);
            obj_sequenz     = new Sequenz(par_sequenz);
        }

        // Update-Funktion die mit der Spielzeit Arbeitet
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                state.CurrentGameState = _8Bit_Dungeon.InGameMenu;
            }


            if (obj_player.boo_fall)
            {
                obj_sequenz.Update(gameTime);
                if (!obj_sequenz.boo_sequenz)
                {
                    obj_player.boo_fall = false;
                }
            }
            else
            {
                obj_player.Update(gameTime);
                obj_map.Update(gameTime);
            }

            if (obj_player.boo_end)
            {
                state.CurrentGameState = _8Bit_Dungeon.Win;
            }
        }

        // Draw-Funktion zeichnet alles
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!obj_player.boo_fall)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(li_tex_assets[3], new Vector2(0, 576), Color.White);
                spriteBatch.End();
                for (int i = 0; i <= 5; i++)
                {
                    if (i == obj_player.int_health)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            spriteBatch.Begin();
                            spriteBatch.Draw(li_tex_assets[2], new Vector2(524, 646) + new Vector2(j * 86, 0), Color.White);
                            spriteBatch.End();
                        }
                    }
                }
                obj_map.Draw(spriteBatch);
                obj_player.Draw(spriteBatch);
            }
            else
            {
                obj_sequenz.Draw(spriteBatch);
            }
        }
    }
}
