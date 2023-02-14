using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {

         class Player
        {
            static int players = 1;
            public int playerNo = players;
            public char xo;
            public int wins = 0;
            public bool bot = false;
            public Player()
            {
                players++;
                this.xo = this.playerNo % 2 == 0 ? 'O' : 'X';
            }

            public Player(bool botMode): this()
            {
                if (botMode)
                    bot = true;
            }

            public int readChoice()
            {
                readChoice:
                    Console.Write($"Player {playerNo}. Please enter the position: ");
                    string choice = Console.ReadLine();
                    int res;
                    int.TryParse(choice, out res);
                    if (res < 1 || res > 9)
                    {
                    goto readChoice;
                    }
                return res;
            }

            int getIrrelevantChoice(char firstPos,char secondPos, char lastPos)
            {
                if (
                    ((firstPos != '-' && secondPos != '-') || (secondPos != '-' && lastPos != '-') || (firstPos != '-' && lastPos != '-'))
                    &&
                    (firstPos == secondPos || secondPos == firstPos || firstPos == lastPos)
                    )
                {
                    if (firstPos == '-')
                        return 0;
                    else if (secondPos == '-')
                        return 1;
                    else if (lastPos == '-')
                        return 2;
                }
                return -1;
            }

            public int[] getBestChoice(char[,] board)
            {
                int[] finalPos = { -1, -1 };

                // Checks for winning or closing spots
                for (int i = 0; i < 3; i++)
                {
                    char firstPos = board[i, 0];
                    char secondPos = board[i, 1];
                    char lastPos = board[i, 2];
                    int pos = getIrrelevantChoice(firstPos, secondPos, lastPos);
                    if (pos >= 0)
                    {
                        finalPos[0] = i;
                        finalPos[1] = pos;
                        // Force push the final position
                        if (firstPos == xo || secondPos == xo)
                            return finalPos;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    char firstPos = board[0, j];
                    char secondPos = board[1, j];
                    char lastPos = board[2, j];
                    int pos = getIrrelevantChoice(firstPos, secondPos, lastPos);
                    if (pos >= 0)
                    {
                        finalPos[0] = pos;
                        finalPos[1] = j;
                        // Force push the final position
                        if (firstPos == xo || secondPos == xo)
                            return finalPos;
                    }
                }

                for (int x = 0; x < 3; x++)
                {
                    char firstPos = board[0, x];
                    char secondPos = board[1, 1];
                    char lastPos = board[2, 2 - x];
                    int pos = getIrrelevantChoice(firstPos, secondPos, lastPos);
                    if (pos >= 0)
                    {
                        finalPos[0] = pos;
                        finalPos[1] = pos == 0 ? x : pos == 1 ? 1 : 2 - x;
                        // Force push the final position
                        if (firstPos == xo || secondPos == xo)
                            return finalPos;
                    }
                }

                if (finalPos[0] != -1 && finalPos[1] != -1)
                    return finalPos;

                // Randomly playing until it gets luck
                if (board[1, 1] == '-')
                {
                    finalPos[0] = 1;
                    finalPos[1] = 1;
                    return finalPos;
                }
                
                Generate:
                    int posRow = new Random().Next(0, 3);
                    int posCol = new Random().Next(0, 3);

                if (board[posRow, posCol] == '-')
                {
                    finalPos[0] = posRow;
                    finalPos[1] = posCol;
                    return finalPos;
                }
                else
                    goto Generate;
            }
        }
        class Game
        {
            private char[,] board = new char[3,3];
            private int turn = 1;
            

            Player[] init()
            {
                makeBoard();
                Console.WriteLine("Welcome to Tic Tac Toe Game...");
                Console.WriteLine("Please select the game mode:  1) Player vs Player   2) Player vs Bot");
                bool mode = Convert.ToInt32(Console.ReadLine()) == 2;
                Player player1 = new Player();
                Player player2;
                if (mode)
                    player2 = new Player(true);
                else
                    player2 = new Player();
                Player[] players = { player1, player2 };
                return players;
            }

            void playAgain(Player player1, Player player2)
            {
                Console.WriteLine();
                board = new char[3, 3];
                makeBoard();
                string botAppear = player2.bot ? "(BOT)" : "";
                Console.WriteLine($"Player {player1.playerNo}: {player1.wins} | Player {player2.playerNo} {botAppear}: {player2.wins}");
                Console.WriteLine($"Player {player1.playerNo} is {player1.xo} and Player {player2.playerNo} is {player2.xo}");
                showBoard();
            }

            void makeBoard()
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        board[i, j] = '-';
                    }
                }
            }

            void showBoard()
            {
                Console.WriteLine();
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        Console.Write(" " + board[i, j]);
                        if (j != 2)
                            Console.Write(" |");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            bool checkCase(char firstPos, char secondPos, char lastPos)
            {
                if (
                    (char.IsLetter(firstPos) && char.IsLetter(secondPos) && char.IsLetter(lastPos))
                    &&
                    (firstPos == secondPos && firstPos == lastPos)
                    )
                    return true;
                return false;
            }
            bool checkBoard()
            {
                    // case 1
                    for (int j = 0; j < 3; j++)
                    {
                    bool _case =  checkCase(board[j, 0], board[j, 1], board[j, 2]);
                    if (_case == true)
                        return _case;
                    }

                    // case 2
                    for (int z = 0; z < 3; z++)
                    {
                    bool _case = checkCase(board[0, z], board[1, z], board[2, z]);
                    if (_case == true)
                        return _case;
                    }

                    // case 3
                    for (int x = 0; x < 3; x++)
                    {
                    bool _case = checkCase(board[0, x], board[1, 1], board[2, 2-x]);
                    if (_case == true)
                        return _case;
                    }
                return false;
            }

            int[] position(int choice)
            {
                int[] res = new int[2];
                res[0] = Convert.ToInt32(Math.Floor((double) ((choice - 1) / 3)));
                res[1] = (choice - 1) % 3;
                return res;
            }

            void play(Player player)
            {
            play:
                int[] choice;
                if (!player.bot)
                    choice = position(player.readChoice());
                else
                    choice = player.getBestChoice(board);
                if (char.IsLetter(board[choice[0], choice[1]]))
                    goto play;
                board[choice[0], choice[1]] = player.xo;
                turn = turn == 1 ? 2 : 1; 
            }

            public void start()
            {
                Player[] players =  init();
                Player player1 = players[0];
                Player player2 = players[1];
                Console.WriteLine($"Player {player1.playerNo} is {player1.xo} and Player {player2.playerNo} is {player2.xo}");
                showBoard();
                int counter = 0;
            gameplay:
                Player currentPlayer;
                if (turn == 1)
                    currentPlayer = player1;
                else
                    currentPlayer = player2;
                play(currentPlayer);
                showBoard();
                counter++;
                bool finish = checkBoard();
                if (counter == 9)
                {
                    Console.WriteLine("Draw!");
                    counter = 0;
                    playAgain(player1, player2);
                    goto gameplay;
                }
                if (finish)
                  {
                    Console.WriteLine($"Player {currentPlayer.playerNo} won");
                    Console.Write("Play again? ");
                    bool answer = Console.ReadLine() == "yes";
                    if (answer)
                    {
                        currentPlayer.wins++;
                        counter = 0;
                        playAgain(player1, player2);
                        goto gameplay;
                    } else
                    {
                        Console.WriteLine("Thanks for playing!");
                    }   
                  }
                else
                    goto gameplay;
            }

        }
        static void Main(string[] args)
        {
            Game game = new Game();
            game.start();
        }
    }
}
