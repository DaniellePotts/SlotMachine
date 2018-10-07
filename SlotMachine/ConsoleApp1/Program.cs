using SlotMachine.Controller;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = new GameController();

			game.SetupGame();
			game.Play();

			System.Console.ReadKey();
		}
	}
}
