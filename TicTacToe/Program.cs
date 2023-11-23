namespace TicTacToe
{
    internal class Program
    {
        static char[] TTT = { '*', 'X', 'O' };
        //static int[,] array = new int[9, 3];

        static void Main(string[] args)
        {
            int[,] array =
            {
                { 0 ,0, 0},{ 1 ,0, 0},{ 2 ,0, 0},
                { 0 ,1, 0},{ 1 ,1, 0},{ 2 ,1, 0},
                { 0, 2, 0},{ 1 ,2, 0},{ 2 ,2, 0}
            };
            // 9, i,y,T
            ShowBoard(array);
        }

        static void ShowBoard(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.SetCursorPosition(array[i, 0], array[i, 1]);
                Console.Write(TTT[array[i, 2]]);
            }
        }

        static void GetKey()
        {

        }
    }
}
