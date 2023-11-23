namespace TicTacToe
{
    internal class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char currentPlayer = 'X';
        static bool gameOver = false;

        static void Main(string[] args)
        {
            do
            {
                board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                currentPlayer = 'X';
                gameOver = false;

                Console.Clear();
                Game();
                Console.WriteLine("Try again? (Y/N)");
            }
            while (Console.ReadKey().Key != ConsoleKey.N);
            Console.Clear();
        }

        static void Game()
        {
            while (!gameOver)
            {
                DrawBoard();
                PlayMove();
                CheckForWin();
                SwitchPlayer();
            }

            Console.ReadLine(); // Pause before closing the console window
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe\n");

            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2} \n", board[6], board[7], board[8]);
        }

        static void PlayMove()
        {
            Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
            int move;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O')
                {
                    board[move - 1] = currentPlayer;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                    Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
                }
            }
        }

        static void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        static void CheckForWin()
        {
            if (CheckForWinner('X'))
            {
                DrawBoard();
                Console.WriteLine("Player X wins!");
                gameOver = true;
            }
            else if (CheckForWinner('O'))
            {
                DrawBoard();
                Console.WriteLine("Player O wins!");
                gameOver = true;
            }
            else if (board.All(c => c == 'X' || c == 'O'))
            {
                DrawBoard();
                Console.WriteLine("It's a tie!");
                gameOver = true;
            }
        }

        static bool CheckForWinner(char player)
        {
            // Check rows, columns, and diagonals for a win
            return (board[0] == player && board[1] == player && board[2] == player) ||
                   (board[3] == player && board[4] == player && board[5] == player) ||
                   (board[6] == player && board[7] == player && board[8] == player) ||
                   (board[0] == player && board[3] == player && board[6] == player) ||
                   (board[1] == player && board[4] == player && board[7] == player) ||
                   (board[2] == player && board[5] == player && board[8] == player) ||
                   (board[0] == player && board[4] == player && board[8] == player) ||
                   (board[2] == player && board[4] == player && board[6] == player);
        }
    }
}
