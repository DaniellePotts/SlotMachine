using System;
using System.Linq;
using System.Collections.Generic;
using SlotMachine.Data;
using SlotMachine.Services;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var gameService = new GameService(new Player());

			gameService.SetupGame();
			gameService.Play();

			Console.ReadKey();
		}
	}
}
