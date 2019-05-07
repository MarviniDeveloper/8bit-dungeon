using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8Bit_Dungeon
{
    class Player
    {
        // Position vom Spieler
        public Vector2 vec_pos_player;

        public Rectangle rec_hitbox;

        // Die Geschwindigkeit vom Spieler
        public float flo_spe_player;

        // Fall für die Sequenz
        public bool boo_fall;

        // Kommerzahlen
        private float flo_timer;
        private float flo_player_width;
        private float flo_player_height;

        // Ganzzahlen
        public int  int_Keys;
        public int  int_current_key;
        public int int_health;
        private int int_sprite_zeile;
        private int int_gold;

        // Idel-Frame
        public bool boo_end;
        private bool boo_idle;

        // Karte
        private Map obj_map;

        // Animation
        private SpriteSheet obj_ani_walk;
        private SpriteSheet obj_ani_idel;

        // Schriftart
        private SpriteFont fon_text;

        // Schriftart
        private List<Texture2D> li_tex_player;

        // Leerer Konstruktor
        public Player()
        {

        }

        // Konsturtor
        public Player(  List<Texture2D> par_player, 
                        List<SpriteFont> par_font, 
                        Map par_map)
        {
            vec_pos_player = new Vector2(656, 450);

            rec_hitbox = new Rectangle((int)vec_pos_player.X, (int)vec_pos_player.Y-32, 32, 64);

            obj_ani_walk = new SpriteSheet(par_player[0], 4, 12);
            obj_ani_idel = new SpriteSheet(par_player[1], 4, 1);

            obj_map = par_map;

            flo_spe_player      = 3.5f;
            flo_player_width    = 30f;
            flo_player_height   = 30f;

            int_gold        = 0;
            int_health      = 5;
            int_current_key = 6;

            boo_idle = true;
            boo_fall = false;
            boo_end = false;

            this.li_tex_player = par_player;

            this.fon_text = par_font[0];            
        }

        // Update-Funktion die mit der Spielzeit Arbeitet
        public void Update(GameTime gameTime)
        {            
            KeyboardState keyboard = Keyboard.GetState();
            int y1 = (int)(vec_pos_player.Y / 32);
            int y2 = (int)((vec_pos_player.Y + 30) / 32);
            int x1 = (int)(vec_pos_player.X / 32);
            int x2 = (int)((vec_pos_player.X + 30) / 32);


            if (keyboard.IsKeyDown(Keys.A))
            {
                if (!boo_fall)
                {
                    x1 = (int)((vec_pos_player.X - flo_spe_player) / 32);
                    x2 = (int)((vec_pos_player.X + flo_player_width - flo_spe_player) / 32);

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1)
                    {
                        vec_pos_player.X -= flo_spe_player;
                        boo_idle = false;
                    }
                    else
                    {
                        boo_idle = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 2 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 2 && obj_map.Int_level[y2, x2] == 1)
                    {
                        obj_map.Enum_stage = Map.Stage.stage1;
                        obj_map.Update(gameTime);
                        vec_pos_player = new Vector2(1075, 335);
                        boo_fall = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 5 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 5 && obj_map.Int_level[y2, x2] == 1)
                    {
                        obj_map.Enum_stage = Map.Stage.stage3;
                        obj_map.Update(gameTime);
                        vec_pos_player = new Vector2(1175, 320);
                    }

                    int_sprite_zeile = 2;
                }
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                if (!boo_fall)
                {
                    x1 = (int)((vec_pos_player.X + flo_spe_player) / 32);
                    x2 = (int)((vec_pos_player.X + flo_player_width + flo_spe_player) / 32);

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1)
                    {
                        vec_pos_player.X += flo_spe_player;
                        boo_idle = false;
                    }
                    else
                    {
                        boo_idle = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 2 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 2)
                    {
                        obj_map.Enum_stage = Map.Stage.stage1;
                        obj_map.Update(gameTime);
                        vec_pos_player = new Vector2(1075, 335);
                        boo_fall = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 6 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 6)
                    {
                        obj_map.Enum_stage = Map.Stage.stage2;
                        obj_map.Update(gameTime);
                        vec_pos_player = new Vector2(92, 307);
                    }

                    int_sprite_zeile = 3;
                }
            }

            if (keyboard.IsKeyDown(Keys.W))
            {
                if (!boo_fall)
                {
                    y1 = (int)((vec_pos_player.Y - flo_spe_player) / 32);
                    y2 = (int)((vec_pos_player.Y + flo_player_height - flo_spe_player) / 32);

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1)
                    {
                        vec_pos_player.Y -= flo_spe_player;
                        boo_idle = false;
                    }
                    else
                    {
                        boo_idle = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 2 && obj_map.Int_level[y1, x2] == 2 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1)
                    {
                        obj_map.Enum_stage = Map.Stage.stage1;
                        obj_map.Update(gameTime);
                        vec_pos_player = new Vector2(624, 370);
                        boo_fall = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 8 && obj_map.Int_level[y1, x2] == 8 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1)
                    {
                        obj_map.Enum_stage = Map.Stage.stageEnd;
                        obj_map.Update(gameTime);
                        vec_pos_player = new Vector2(624, 352);
                    }

                    if (obj_map.Int_level[y1, x1] == 4 && obj_map.Int_level[y1, x2] == 4 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1)
                    {
                        obj_map.Enum_stage = Map.Stage.stage1;
                        obj_map.Update(gameTime);
                        vec_pos_player = new Vector2(660, 420);
                    }

                    if ((obj_map.Int_level[y1, x1] == 10 && obj_map.Int_level[y1, x2] == 10 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1) && int_Keys == 5)
                    {
                        boo_end = true;
                    }

                    int_sprite_zeile = 0;
                }
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                if (!boo_fall)
                {
                    y1 = (int)((vec_pos_player.Y + flo_spe_player) / 32);
                    y2 = (int)((vec_pos_player.Y + flo_player_height + flo_spe_player) / 32);

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 1 && obj_map.Int_level[y2, x2] == 1)
                    {
                        vec_pos_player.Y += flo_spe_player;
                        boo_idle = false;
                    }
                    else
                    {
                        boo_idle = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 2 && obj_map.Int_level[y2, x2] == 2)
                    {
                        obj_map.Enum_stage = Map.Stage.stage1;
                        obj_map.Update(gameTime);
                        obj_map.Int_level = obj_map.stage0;
                        vec_pos_player = new Vector2(1075, 335);
                        boo_fall = true;
                    }

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 3 && obj_map.Int_level[y2, x2] == 3)
                    {
                        obj_map.Enum_stage = Map.Stage.stage2;
                        obj_map.Update(gameTime);
                        obj_map.Int_level = obj_map.stage2;
                        vec_pos_player = new Vector2(720, 160);
                    }

                    if (obj_map.Int_level[y1, x1] == 1 && obj_map.Int_level[y1, x2] == 1 && obj_map.Int_level[y2, x1] == 9 && obj_map.Int_level[y2, x2] == 9)
                    {
                        obj_map.Enum_stage = Map.Stage.stage1;
                        obj_map.Update(gameTime);
                        obj_map.Int_level = obj_map.stage1;
                        vec_pos_player = new Vector2(720, 85);
                    }

                    int_sprite_zeile = 1;
                }
            }

            rec_hitbox.X = (int)vec_pos_player.X;
            rec_hitbox.Y = (int)vec_pos_player.Y - 32;

            for (int i = 0; i < obj_map.li_obj_chest.Count; i++)
            {
                if (this.rec_hitbox.Intersects(obj_map.li_obj_chest[i].rec_hitbox) && (keyboard.IsKeyDown(Keys.E) && obj_map.li_obj_chest[i].boo_loot) && obj_map.Current_State_Info == obj_map.li_obj_chest[i].stage_pos_Chest)
                {
                    int_gold += obj_map.li_obj_chest[i].int_loot;
                    obj_map.li_obj_chest[i].boo_loot = false;
                    obj_map.li_obj_chest[i].boo_animation = false;
                }
            }

            for (int i = 0; i < obj_map.li_obj_key.Count; i++)
            {
                if (this.rec_hitbox.Intersects(obj_map.li_obj_key[i].rec_hitbox) && (keyboard.IsKeyDown(Keys.E) && obj_map.li_obj_key[i].boo_loot))
                {
                    obj_map.li_obj_key[i].boo_loot = false;
                    int_current_key = i;
                    int_Keys += 1;
                }
            }

            if (keyboard.IsKeyUp(Keys.A) && keyboard.IsKeyUp(Keys.D) && keyboard.IsKeyUp(Keys.W) && keyboard.IsKeyUp(Keys.S))
            {
                boo_idle = true;
            }

            flo_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.flo_timer >= 0.15)
            {
                obj_ani_walk.Update();
                flo_timer = 0;
            }

            if (int_current_key == 0)
            {
                obj_map.li_obj_key[0].pos_Key.X = 1024;
                obj_map.li_obj_key[0].pos_Key.Y = 656;
            }
            if (int_current_key == 1)
            {
                obj_map.li_obj_key[1].pos_Key = new Vector2(1072, 656);
            }
            if (int_current_key == 2)
            {
                obj_map.li_obj_key[2].pos_Key = new Vector2(1120, 656);
            }
            if (int_current_key == 3)
            {
                obj_map.li_obj_key[3].pos_Key = new Vector2(1168, 656);
            }
            if (int_current_key == 4)
            {
                obj_map.li_obj_key[4].pos_Key = new Vector2(1216, 656);
            }
        }

        // Draw-Funktion zeichnet alles
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (!boo_idle)
            {
                obj_ani_walk.Draw(spriteBatch, vec_pos_player - new Vector2(15, 30), int_sprite_zeile);
            }
            else
            {
                obj_ani_idel.Draw(spriteBatch, vec_pos_player - new Vector2(15, 30), int_sprite_zeile);
            }
            spriteBatch.DrawString(fon_text, int_gold.ToString(), new Vector2(112, 648), Color.AntiqueWhite);
            spriteBatch.End();
        }
    }
}