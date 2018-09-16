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
                Each time a player wins - his win count is raised by one and the total time he took to win the race is added and averaged at the end of the code
            */
            int[] winCount = new int[4];
            int[] timeCount = new int[4];

            for (int x = 0; x < 10000; x++)
            {
                int[] a = engageRace();
                winCount[a[0]] += 1;
                timeCount[a[0]] += a[1];
            }

            for (int x = 0; x < winCount.Length; x++)
            {
                Console.WriteLine("Player " + x + " has won " + winCount[x] + " times" + " and did it in an average of " + timeCount[x]/winCount[x] + "sec");
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
            Console.WriteLine("The winner is: Player " + winner + " and did it in " + timeElapsed + " seconds"); 

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
