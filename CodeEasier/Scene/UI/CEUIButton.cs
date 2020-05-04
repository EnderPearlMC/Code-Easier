using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
   _____          _        ______          _           
  / ____|        | |      |  ____|        (_)          
 | |     ___   __| | ___  | |__   __ _ ___ _  ___ _ __ 
 | |    / _ \ / _` |/ _ \ |  __| / _` / __| |/ _ \ '__|
 | |___| (_) | (_| |  __/ | |___| (_| \__ \ |  __/ |   
  \_____\___/ \__,_|\___| |______\__,_|___/_|\___|_|   
                                                      

    Made by EnderPearl MC

     This framework allows you to create games very quickly.
     Made with monogame.

     You are free to use this framework in all your projects
     but you cannot REDISTRIBUTE it. 

 */

namespace CodeEasier.Scene.UI
{

    /*

        UIButton class

        Usage : Call CEUI.Button(text); (returns an instance)

    */

    class CEUIButton : ICESceneDrawable
    {

        /*
         *  Properties 
         */

        public string Text { get; set; }
        public string ThemePath { get; private set; }
        public Main BaseGame { get; private set; }

        public string ImgPath { get; private set; }
        public string ImgHoverPath { get; private set; }
        public string ImgPressedPath { get; private set; }
        public string FontPath { get; private set; }

        public Texture2D Img { get; private set; }
        public Texture2D ImgHover { get; private set; }
        public Texture2D ImgPressed { get; private set; }
        public SpriteFont Font { get; private set; }

        /*
         *  Constructor
         */

        /**
         *  <param type="string" name="text">The text on the button</param>
         *  <param type="string" name="themePath">The path of the theme file</param>
         *  <param type="Main" name="baseGame">The base game</param>
         */
        public CEUIButton(string text, string themePath, Main baseGame)
        {
            Text = text;
            ThemePath = themePath;
            BaseGame = baseGame;

            ParseTheme(System.IO.File.ReadAllLines(themePath));


        }

        /*
         *  Methods 
         */

        private void ParseTheme(string[] lines)
        {
             
            if (lines[0] == "--<thm>--")
            {

                CEUI.Type type = CEUI.Type.None;
                string img = "";
                string imgHover = "";
                string imgPressed = "";
                string font = "";

                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        string[] parts = line.Split(' ');
                        
                        // means "type : <type>"
                        if (parts[0] == "type")
                        {
                            if (parts[1] == ":")
                            {
                                if (parts[2] == "button")
                                {
                                    type = CEUI.Type.Button;
                                }
                            }
                        }

                        // means "background : <bg>"
                        if (parts[0] == "background")
                        {
                            if (parts[1] == ":")
                            {
                                img = parts[2];
                            }
                        }

                        // means "background-hover : <bg>"
                        if (parts[0] == "background-hover")
                        {
                            if (parts[1] == ":")
                            {
                                imgHover = parts[2];
                            }
                        }

                        // means "background-pressed : <bg>"
                        if (parts[0] == "background-pressed")
                        {
                            if (parts[1] == ":")
                            {
                                imgPressed = parts[2];
                            }
                        }

                        // means "font : <font>"
                        if (parts[0] == "font")
                        {
                            if (parts[1] == ":")
                            {
                                font = parts[2];
                            }
                        }

                    }
                }
                
                if (type != CEUI.Type.None && img != "" && imgHover != "" && imgPressed != "" && font != "")
                {
                    ImgPath = img;
                    ImgHoverPath = imgHover;
                    ImgPressedPath = imgPressed;
                    FontPath = font;
                }
                else
                {
                    throw new Exception("Theme file incorrect! File : " + ThemePath);
                }

            }

        }
        
        public void Load()
        {

            // load textures and font
            Img = BaseGame.Content.Load<Texture2D>(ImgPath);
            ImgHover = BaseGame.Content.Load<Texture2D>(ImgHoverPath);
            ImgPressed = BaseGame.Content.Load<Texture2D>(ImgPressedPath);
            Font = BaseGame.Content.Load<SpriteFont>(FontPath);

        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
