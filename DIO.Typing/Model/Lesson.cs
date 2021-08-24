using System;
using System.Collections.Generic;

namespace DIO.Typing {
    public class Lesson {
        public static string Create(string listKeys, int totalHeight, int totalRange) {
            
            try {
                
                string text;
                List<string> vector = new List<string>();
                List<string> list = new List<string>();

                Random randNum = new Random();

                for (int i = 0; i < listKeys.Length; i++) {
                    vector.Add(listKeys.Substring(i, 1));
                }

                for (int i = 0; i <= totalHeight; i++) {
                    text = "";
                    for (int j = 0; j <= totalRange; j++) {
                        int index = randNum.Next(0, vector.Count);
                        text += vector[index].TrimEnd();
                    }
                    list.Add(text.Substring(0, text.Length - 1));
                }

                string result = "";

                foreach (string texto in list) {
                    result += texto + " ";
                }

                return result;

            }
            catch(Exception e) {
                return e.Message;
            }
        }
    }
}
