using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Card_Game_Fine
{
    
        class Program
        { 

            static void Main(string[] args)
            {
            bool gameover = false;
                //List of cards available            
                var x = new List<string>()
            {
                "KS", "KH", "KD", "KF",
                "JS", "JH", "JD", "JF",
                "QS", "QH", "QD", "QF",
                "2S", "2H", "2D", "2F",
                "3S", "3H", "3D", "3F",
                "4S", "4H", "4D", "4F",
                "5S", "5H", "5D", "5F",
                "6S", "5H", "5D", "5F",
                "6S", "6H", "6D", "6F",
                "7S,", "7H", "7D", "7F",
                "8S", "8H", "8D", "8F",
                "9S", "9H", "9D", "9F",
                "10S", "10H", "10D", "10F",
                "AS", "AH", "AD", "AF"
            };
                var cardslist = new List<int>();
                var rand = new Random();
                for (int i = 0; i <= x.Count; i++)
                {
                    int cards = rand.Next(x.Count);
                    if (cardslist.Contains(cards))
                    {
                        continue;
                    }
                    cardslist.Add(cards);
                }
                //Shuffling start->
                var shuffledlist = new List<string>();
                foreach (var i in cardslist)
                {
                    shuffledlist.Add(x[i]);
                }

                //Shuffling stop<--
                foreach (var v in shuffledlist)
                {
                    Console.Write($"{v}, ");
                }
                //Setting apart the Start card:
                var starter = shuffledlist[0];
                foreach (var item in shuffledlist)
                {
                    if (!item.StartsWith("2") & !item.StartsWith("3") & !item.StartsWith("8") & !item.StartsWith("J") &
                        !item.StartsWith("K") & !item.StartsWith("Q"))
                    {
                        Console.WriteLine($"\n\n\t\t\tStart Card: {item}");
                        shuffledlist.Remove(item);
                    }
                    else
                    {
                        foreach (var i in cardslist)
                        {
                            shuffledlist.Add(x[i]);
                        }
                    }
                    break;
                }
                //Set two lists for player1 and custom player and assign four cards according to shuffled list
                List<string> player1 = new List<string>();
                List<string> customplayer = new List<string>();
                player1.Add(shuffledlist[0]);
                player1.Add(shuffledlist[1]);
                player1.Add(shuffledlist[2]);
                player1.Add(shuffledlist[3]);

                customplayer.Add(shuffledlist[4]);
                customplayer.Add(shuffledlist[5]);
                customplayer.Add(shuffledlist[6]);
                customplayer.Add(shuffledlist[7]);
                shuffledlist.RemoveRange(0, 8);
                // Console.WriteLine($" CustomPlayer Cards are: {customplayer[0]},{customplayer[1]},{customplayer[2]},{customplayer[3]}");

                //Game Starts
                while (gameover==false)
                {
                    Console.Write($"\n YOUR CARDS ARE: ");
                foreach (var c in player1)
                {
                    Console.Write($"{c} ,");
                }
                    Console.WriteLine($"\nGAME STARTED!!! {starter}");
                    var input = Console.ReadLine();
                    if (player1.Contains(input) || input.Contains("P"))
                    {
                        if (input.Contains(starter[0]) || input.Contains(starter[1]))
                        {
                            player1.Remove(input);
                            starter = input;
                            // Console.WriteLine(starter);
                            //Console.Write($"\n YOUR CARDS: {player1[0]},{player1[1]},{player1[2]},{player1[3]}");
                        }
                        else if (input.Contains("P"))
                        {
                        player1.Add(shuffledlist[0]);
                        Console.WriteLine(player1.Count);

                        }
                        else
                        {
                            player1.Add(shuffledlist[0]);
                            if (customplayer[0].Contains(starter[0]) || customplayer[0].Contains(starter[1]) ||
                                customplayer[1].Contains(starter[0]) || customplayer[1].Contains(starter[1]) ||
                                customplayer[2].Contains(starter[0]) || customplayer[2].Contains(starter[1]) ||
                                customplayer[3].Contains(starter[0]) || customplayer[3].Contains(starter[1]))
                            {
                                customplayer.Remove(customplayer[0]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("! PLEASE ENTER A VALID CARD NAME !");
                    }
                   
                }
                Console.WriteLine($"\n{player1[0]},{player1[1]},{player1[2]},{player1[3]}");
                Console.WriteLine($"\n{customplayer[0]},{customplayer[1]},{customplayer[2]},{customplayer[3]}");
                Console.ReadKey();
            }
        }
}
