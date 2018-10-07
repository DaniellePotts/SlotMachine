using SlotMachine.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachine.Services
{
	public class SlotMachineService
	{
		public GameSlotMachine SlotMachine;

		private const int COLUMNS = 4;
		private const int ROW_COUNT = 3;

		public SlotMachineService()
		{
			SlotMachine = new GameSlotMachine();
		}

		public double RunSlots(Player p)
		{
			var random = new Random();
			var totalWon = 0.0;
			for (var i = 0; i < COLUMNS; i++)
			{
				var selectedTokens = new List<SlotMachineCard>();
				var line = String.Empty;

				for (var j = 0; j < ROW_COUNT; j++)
				{
					var prob = random.Next(1, 100);
					var matched = false;

					for (var k = 0; k < SlotMachine.SlotMachineCards.Count; k++)
					{
						if (!matched && prob <= SlotMachine.SlotMachineCards[k].CumulativeProbability)
						{
							selectedTokens.Add(SlotMachine.SlotMachineCards[k]);
							line += SlotMachine.SlotMachineCards[k].Token;

							matched = true;
						}
					}
				}

				Console.WriteLine(line);

				if (HasWon(line))
				{
					totalWon = WinAmount(selectedTokens, p.StakeAmount);
					p.Balance += totalWon;
				}
			}

			return totalWon;
		}

		public static bool HasWon(string line)
		{
			if (line.Distinct().Count() == 1)
			{
				return true;
			}
			else if (line.Contains("*"))
			{

				var wildCards = line.ToCharArray().Where(x => x == '*').ToArray();
				if (wildCards.Length > 1)
				{
					return true;
				}
				else
				{
					var otherChars = line.ToCharArray().Where(x => x != '*').ToArray();

					if (new string(otherChars).Distinct().Count() == 1)
					{
						return true;
					}
				}

				return false;
			}

			return false;
		}

		public static double WinAmount(List<SlotMachineCard> slotMachineCards, double stakeAmount)
		{
			var coefficientSum = 0.0;

			foreach (var card in slotMachineCards)
			{
				coefficientSum += card.Coefficient;
			}

			return coefficientSum * stakeAmount;
		}




	}
}
