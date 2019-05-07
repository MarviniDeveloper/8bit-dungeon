using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class Button
    {
        // Texture vom Knopf
        private Texture2D tex_normal;
        private Texture2D tex_hover;
        private Texture2D tex_current;
        
        // Position vom Knopf
        private Vector2 vec_position;
        
        // Beschriftung für die Knöpfe
        private string str_labeling;
        
        // Maus
        private MouseState mse_mouse;
        private MouseState mse_mouseOld;
        
        // Boolean für den Hover Effekt
        public bool boo_Aktiv;

        // Konstruktor
        public Button(  List<Texture2D> par_tex,
                        Vector2 par_pos,
                        string par_labeling)
        {
            tex_normal = par_tex[0];
            tex_hover = par_tex[1];
            tex_current = tex_normal;
            vec_position = par_pos;
            str_labeling = par_labeling;
            boo_Aktiv = false;
        }

        // Aktuallisieren der Knöpfen
        public void Update()
        {
            mse_mouseOld = mse_mouse;
            mse_mouse = Mouse.GetState();
            Rectangle mouseRect = new Rectangle(mse_mouse.X, mse_mouse.Y, 1, 1);
            Rectangle buttonRect = new Rectangle((int)vec_position.X, (int)vec_position.Y, tex_current.Width, tex_current.Height);

            if (mouseRect.Intersects(buttonRect))
            {
                tex_current = tex_hover;

                if (mse_mouse.LeftButton == ButtonState.Pressed && mse_mouseOld.LeftButton == ButtonState.Released)
                {
                    boo_Aktiv = true;
                }
            }
            else
            {
                tex_current = tex_normal;
            }
        }

        // Zeichnen der Knöpfe
        public void Draw(SpriteBatch spriteBatch, SpriteFont menuFont)
        {
            spriteBatch.Draw(tex_current, vec_position, Color.White);
            if (tex_current != tex_hover)
            {
                spriteBatch.DrawString(menuFont, str_labeling, vec_position + new Vector2(tex_current.Width / 2 - str_labeling.Length * 6.5f, tex_current.Height / 2 - 48), new Color(0, 51, 186));
            }
            else if (tex_current == tex_hover)
            {
                spriteBatch.DrawString(menuFont, str_labeling, vec_position + new Vector2(tex_current.Width / 2 - str_labeling.Length * 6.5f, tex_current.Height / 2 - 16), new Color(0, 51, 186));
            }
            
        }
    }
}
