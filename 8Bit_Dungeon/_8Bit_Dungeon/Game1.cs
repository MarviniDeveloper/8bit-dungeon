using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _8Bit_Dungeon
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Status
        State state;

       // Listen
        // Schriftarten
        List<SpriteFont> fonts;
        // Texturen
        List<Texture2D> li_tex_menu;
        List<Texture2D> li_tex_sequenz;
        List<Texture2D> li_tex_level;
        List<Texture2D> li_tex_player;
        List<Texture2D> li_tex_assets;

        // Objekte
        Menu    obj_menu;
        InGame  obj_inGame;
        InGameMenu obj_inGameMenu;

        public object TextureUsage { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            // Bildschirm Weite und Höhe
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 704;
            graphics.ApplyChanges();

            // Zustand
            state = new State();


            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Initalisieren der Listen
            fonts = new List<SpriteFont>();
            li_tex_menu = new List<Texture2D>();
            li_tex_level = new List<Texture2D>();
            li_tex_player = new List<Texture2D>();
            li_tex_assets = new List<Texture2D>();
            li_tex_sequenz = new List<Texture2D>();

            // Laden der Texturen
            fonts.Add(Content.Load<SpriteFont>("MenuFont"));
            li_tex_menu.Add(Content.Load<Texture2D>("btn"));
            li_tex_menu.Add(Content.Load<Texture2D>("btn_hover"));
            li_tex_menu.Add(Content.Load<Texture2D>("bckgr"));
            li_tex_menu.Add(Content.Load<Texture2D>("menu"));
            li_tex_menu.Add(Content.Load<Texture2D>("win"));
            li_tex_level.Add(Content.Load<Texture2D>("stage0"));
            li_tex_level.Add(Content.Load<Texture2D>("stage1"));
            li_tex_level.Add(Content.Load<Texture2D>("stage2"));
            li_tex_level.Add(Content.Load<Texture2D>("stage3"));
            li_tex_level.Add(Content.Load<Texture2D>("stageEND"));
            li_tex_player.Add(Content.Load<Texture2D>("ply_sprite"));
            li_tex_player.Add(Content.Load<Texture2D>("ply_idle"));
            li_tex_assets.Add(Content.Load<Texture2D>("chest"));
            li_tex_assets.Add(Content.Load<Texture2D>("key"));
            li_tex_assets.Add(Content.Load<Texture2D>("health"));
            li_tex_assets.Add(Content.Load<Texture2D>("hud"));
            li_tex_sequenz.Add(Content.Load<Texture2D>("stage_sequenz"));
            li_tex_sequenz.Add(Content.Load<Texture2D>("player_sequenz"));

            Texture2D test = Content.Load<Texture2D>("boden");

            obj_menu = new Menu(li_tex_menu, state);
            obj_inGame = new InGame(state, fonts, li_tex_level, li_tex_player, li_tex_assets, li_tex_sequenz, test);
            obj_inGameMenu = new InGameMenu(li_tex_menu, state);
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            switch (state.CurrentGameState)
            {
                case _8Bit_Dungeon.Menu:
                    obj_menu.Update();


                    // Mauszeiger
                    IsMouseVisible = true;
                    break;
                case _8Bit_Dungeon.InGame:
                    obj_inGame.Update(gameTime);

                    
                    // Mauszeiger
                    IsMouseVisible = false;
                    break;
                case _8Bit_Dungeon.InGameMenu:
                    obj_inGameMenu.Update();

                    
                    // Mauszeiger
                    IsMouseVisible = true;
                    break;
                case _8Bit_Dungeon.Quit:
                    break;
                case _8Bit_Dungeon.Win:
                    break;
                case _8Bit_Dungeon.Lose:
                    break;
                case _8Bit_Dungeon.Settings:
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            switch (state.CurrentGameState)
            {
                case _8Bit_Dungeon.Menu:
                    obj_menu.Draw(spriteBatch, fonts);
                    break;
                case _8Bit_Dungeon.InGame:
                    obj_inGame.Draw(spriteBatch);
                    break;
                case _8Bit_Dungeon.InGameMenu:
                    obj_inGameMenu.Draw(spriteBatch, fonts);
                    break;
                case _8Bit_Dungeon.Quit:
                    this.Exit();
                    break;
                case _8Bit_Dungeon.Win:
                    spriteBatch.Begin();
                    spriteBatch.Draw(li_tex_menu[4], new Vector2(0, 0), Color.White);
                    spriteBatch.End();
                    break;
                case _8Bit_Dungeon.Lose:
                    break;
                case _8Bit_Dungeon.Settings:

                    break;
                default:
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
