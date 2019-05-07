using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class Menu
    {
        // Knöpfe 
        private Button btn_play;
        private Button btn_settings;
        private Button btn_quit;

        // Spiel Zustände
        private State sta_state;

        // Texturen fürs Menü
        private Texture2D tex_background;

        // Konstruktor
        public Menu(    List<Texture2D> par_tex, 
                        State par_state)
        {
            btn_play        = new Button(par_tex, new Vector2(511, 300), "Spielen");
            btn_settings    = new Button(par_tex, new Vector2(511, 425), "Einstellungen");
            btn_quit        = new Button(par_tex, new Vector2(511, 550), "Verlassen");

            tex_background = par_tex[2];

            sta_state = par_state;
        }

        // Update-Funktion Aktualisiert die Knöpfe, um die
        // Interaktion mit der Maus zu Überprüfen
        public void Update()
        {
            btn_play.Update();
            btn_settings.Update();
            btn_quit.Update();

            if (btn_play.boo_Aktiv)
            {
                sta_state.CurrentGameState = _8Bit_Dungeon.InGame;
                btn_play.boo_Aktiv = false;
            }
            if (btn_settings.boo_Aktiv)
            {
                sta_state.CurrentGameState = _8Bit_Dungeon.Settings;
                btn_settings.boo_Aktiv = false;
            }
            if (btn_quit.boo_Aktiv)
            {
                sta_state.CurrentGameState = _8Bit_Dungeon.Quit;
                btn_quit.boo_Aktiv = false;
            }
        }

        // Draw-Funktion zeichnet alles
        public void Draw(SpriteBatch spriteBatch, List<SpriteFont> font)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex_background, new Vector2(0, 0), Color.White);
            btn_play.Draw(spriteBatch, font[0]);
            btn_settings.Draw(spriteBatch, font[0]);
            btn_quit.Draw(spriteBatch, font[0]);
            spriteBatch.End();
        }
    }
}
