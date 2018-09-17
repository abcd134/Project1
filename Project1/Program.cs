using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*this code will initiate 10000 race
                Create a list to store all of the winning player and their winning time
            */
            List<int[]> dataset= new List<int[]>();

            for (int x = 0; x < 10000; x++)
            {
                int[] a = engageRace();
                dataset.Add(a);
            }

            int[][] winnerAndTime = dataset.ToArray(); // convert the list in to a 2 dimensional array 
                                                       //data format: [x][0] - winning player [x][1] - winning player's time



            // Functional code ends here - below are possible uses


            /*
             * This will show the user each winner and their times 
             */

            for (int x = 0; x < winnerAndTime.Length; x++)
            {
                Console.WriteLine("Player " + winnerAndTime[x][0] + " won at " + winnerAndTime[x][1] + " sec");
            } 

            /*
             * This code will count how many times each player wins - winnerCount will have a tally of how many times each player won
             */
            int[] winnerCount = new int[1];
            for (int x = 0; x < winnerAndTime.Length; x++)
            {
                winnerCount[winnerAndTime[x][0]] += 1; //add 1 everytime a winner wins
            }

            //creates 3 lists seperating out each of the player's time - data is ordered based on recent wins - being recent wins is the last data
            List<int> player0Times = new List<int>();
            List<int> player1Times = new List<int>();
            List<int> player2Times = new List<int>();
            List<int> player3Times = new List<int>();

            for (int x = 0; x < winnerAndTime.Length; x++)
            {
                switch (winnerAndTime[x][0])
                {
                    case 0:
                        player0Times.Add(winnerAndTime[x][1]);
                        break;
                    case 1:
                        player1Times.Add(winnerAndTime[x][1]);
                        break;
                    case 2:
                        player2Times.Add(winnerAndTime[x][1]);
                        break;
                    case 3:
                        player3Times.Add(winnerAndTime[x][1]);
                        break;
                }
            }

            Console.ReadLine();
        }

        /* engageRace will create 4 players, stores the winner, time it took the winner to win and how much leaps each player made
         * dataToRetuen - This array stores the winner and the time it took it to win
         * winner - stores the winner
         * timeElapsed - keeps track of the time
         * players[] - a 4 value array representing the players
         * 
         * It will only return the winner and the winner's time
         * 
        */
        static int[] engageRace ()
        {
            Random rnd = new Random();     
            int [] dataToReturn = new int[2];
            int winner;
            int timeElapsed = 0;
            int[] players = new int[4];
           
            // while statement will initiate the race and will keep the race going until there is a winner
            while (checkWinner(players) == 5)
            {
                for (int x = 0; x < players.Length; x++)
                {
                    players[x] += rnd.Next(1, 4);
                }

                timeElapsed += 1;       //advance time by 1 sec

            }

            winner = checkWinner(players); //store the winner here

            //preparing data return
            dataToReturn[0] = winner; 
            dataToReturn[1] = timeElapsed;

            return dataToReturn;
        }

        //checks to see if any of the players have reached the winning condition
        static int checkWinner(int [] players)
        {
            int winner = 5;
            for (int x = 0; x < players.Length; x++)
            {
                if (players[x] >= 1500)
                {
                    winner = x;
                }
            }
            return winner;
        }
    }
}
