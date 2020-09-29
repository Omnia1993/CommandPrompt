using System;
using System.IO;

namespace Cmd
{
    class CmdPrompt
    {
     ConsoleColor backgroundColor;
     ConsoleColor foregroundColor;
        string[] screenText;
        int height;
        int columns;


        // set the backgroundColor to some default
        // set the foregroundColor to some default
        // create the screen to hold the number of rows passed in with the height parameter


        public CmdPrompt(int height, int columns)
        {
            this.height =height;
            this.columns = columns;
            screenText = new string[height];
            for (int i = 0; i < screenText.Length; i++)
            {
                screenText[i] = "";
            }
            //backgroundColor = ConsoleColor.Red;   
            //foregroundColor = ConsoleColor.Black; 
        }// end of CommandPrompt constructor
        public void Display()
        {
            // set the foreground and background colors
            Console.Clear(); //  the Console object is available to us to control aspects of our terminal window. The Clear method will blank our window
                                         // The Clear method has blanked the screen and left the cursor at the top of the window.
                                         // We will now loop through the screenText array to put out text on the screen.
            for (int i = 0; i < screenText.Length; i++)
            {
                Console.WriteLine(screenText[i]);
            }
        }   // end of Display method
        public void SetScreenText(int lineNumber, string lineOfText)
        {
            screenText[lineNumber] = lineOfText;
        }   // end of SetScreenText method
        public void SetBackgroundColor(string color)
        {
            backgroundColor = ConvertColor(color);
        }   // end of SetBackgroundColor

        public void SetForegroundColor(string color)
        {
            foregroundColor = ConvertColor(color);
        }   // end of SetForegroundColor
        public static ConsoleColor ConvertColor(string strColor)
        {
            ConsoleColor color;
            switch (strColor.ToLower())
            {
                case "black": color = ConsoleColor.Black; break;
                case "red": color = ConsoleColor.Red; break;
                case "blue": color = ConsoleColor.Blue; break;
                case "darkYellow": color = ConsoleColor.DarkYellow; break;

                default: color = ConsoleColor.DarkGray; break;
            }
            return color;
        }   // end of ConvertColor method
        public void SaveScreen(string fileName)
        {
            StreamWriter textOut = null;
            try
            {
                fileName = "../../../" + fileName;
                textOut = new StreamWriter(fileName);
                //your code here!!!
                foreach (var line in screenText)
                {
                    textOut.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating file: ");
                Console.WriteLine(ex.ToString());
                return;
            }
            finally
            {
                if (textOut != null)
                    textOut.Close();
            }
        }   // End of SaveScreen method

        public void ReloadScreen(string fileName)
        {
            StreamReader textIn;
            fileName = "../../../" + fileName;
            textIn = new StreamReader(fileName);
            int i = 0;
            while (true)
            {
                string text= textIn.ReadLine();
                if (text == null)
                    break;
                screenText[i++] = text;

            }
            textIn.Close();
        }

    } // end of CommandPrompt class

}