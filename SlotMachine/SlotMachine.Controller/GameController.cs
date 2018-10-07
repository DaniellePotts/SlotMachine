using SlotMachine.Data;
using SlotMachine.Services;
using System;

namespace SlotMachine.Controller
{
	public class GameController
	{
		public Player Player;
		public SlotMachineService SlotMachine;


		public GameController()
		{
			Player = new Player();
			SlotMachine = new SlotMachineService();
		}

		public void SetupGame()
		{
			Console.WriteLine("Input Deposit Amount:");
			this.Player.Balance = Convert.ToDouble(Console.ReadLine());
		}

		private void Stake()
		{
			Console.WriteLine("How much money do you want to stake?");
			this.Player.StakeAmount = Convert.ToDouble(Console.ReadLine());

			while (this.Player.StakeAmount > this.Player.Balance)
			{
				Console.WriteLine("Cannot stake more than the current balance. Balance is: " + this.Player.Balance);
				this.Player.StakeAmount = Convert.ToDouble(Console.ReadLine());
			}

			this.Player.Balance -= this.Player.StakeAmount;
			Console.Clear();
		}

		public void Play()
		{
			while (this.Player.Balance > 0)
			{
				Stake();

				var totalWon = SlotMachine.RunSlots(this.Player);

				if (totalWon > 0)
				{
					Console.WriteLine("Total win amount: " + totalWon);
					Console.WriteLine("Total balance is: " + this.Player.Balance);
				}
				else
				{
					Console.WriteLine("You lost this time. Balance is: " + this.Player.Balance);
				}
			}
		}
	}
}
