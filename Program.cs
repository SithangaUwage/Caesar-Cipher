using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Caesar_Cipher {
    class Program {
        static string Caesar(string value, int shift) {
            char[] cipher = value.ToCharArray();
            for (int i = 0; i < cipher.Length; i++) {
                // letter charcters turn into ASCII characters.
                char letter = cipher[i];
                int letterInt = (int)letter;

                // Upper case character shift.
                if (letterInt >= 65 && letterInt <= 90){
                    letterInt = (int)(letter + shift);
                    if (letterInt <= 65){
                        letterInt = (int)(letter + shift);
                        letterInt += 26;
                    }
                    if (letterInt >= 91){
                        letterInt -= 26;
                    }
                    // ASCII characters getting converted back to letter characters.
                    letter = Convert.ToChar(letterInt);
                }

                // Lower case charcter shift.
                else if (letterInt >= 97 && letterInt <= 122){
                    letterInt = (int)(letter + shift);
                    if (letterInt <= 90){
                        letterInt = (int)(letter + shift);
                        letterInt += 26;
                    }
                    if (letterInt >= 123){
                        letterInt = (int)(letter + shift);
                        letterInt -= 26;
                    }
                    // ASCII characters getting converted back to letter characters.
                    letter = Convert.ToChar(letterInt);
                }
                // Space charcter is not shifted.
                else if (letterInt == 32){
                    if (letter != ' ') ;
                }
                cipher[i] = letter;
            }
            return new string(cipher);
        }

        static void Main(){
            // The main method.
            // Exception handling.
            try{
                Console.WriteLine("PLease select 1= To Enter Message or 2= To Read Text File");
                Console.Write("\nYour Selection: \n");
                string str = Console.ReadLine();

                // Selection between Entering the Message or Reading the Message from Text File.
                switch (str){
                    case "1":
                    case "To Enter Message":
                        Console.WriteLine("Please Enter The Text Of The Message: ");
                        string text = Console.ReadLine();
                        string b;
                        // Characters only shifted between 0 & 25 as there are only 26 letters in the alphabet.
                        for (int x = 0; x <= 25; x++){
                            b = Caesar(text, x);
                            Console.Write("Shift of {0}: ", x);
                            Console.WriteLine(b);
                        }
                        // When the shifts are completed this message appears.
                        Console.WriteLine("\nShift's Completed!");
                        break;
                    case "2":
                        // The location of the Text File.
                        string file = @"C:\myText.txt";
                        string text1 = File.ReadAllText(file);
                        string c;

                        for (int x = 0; x <= 25; x++){
                            c = Caesar(text1, x);
                            Console.Write("Shift of {0}: ", x);
                            Console.WriteLine(c);
                        }
                        Console.WriteLine("\nShift's Completed!");
                        break;
                    // If an Invalid Selection is entered this message will pop up.
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
            catch (Exception e){
                Console.WriteLine("\nThe following exception was caught:\n{0}", e.Message);
            }
            // Console.ReadLine();
        }
    }
}
