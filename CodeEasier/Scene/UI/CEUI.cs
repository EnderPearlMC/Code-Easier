using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        UI class

        Usage : Call static method to get differents UI elements

    */

    class CEUI
    {

        public enum Type
        {
            None,
            Button
        }

        /**
         *  Static methods
         */

        /**
         *  <param type="string" name="text">The text of the button</param>
         *  <param type="string" name="themePath">The path of the file that represents the theme of the button</param>
         *  <param type="Main" name="baseGame">The base game</param>
         */
        public static CEUIButton Button(string text, string themePath, Main baseGame)
        {
            return new CEUIButton(text, themePath, baseGame);
        }

    }
}
