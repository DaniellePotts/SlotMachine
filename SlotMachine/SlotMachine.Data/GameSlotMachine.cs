using System.Linq;
using System.Collections.Generic;

namespace SlotMachine.Data
{
	public class GameSlotMachine
	{
		public List<SlotMachineCard> SlotMachineCards;

		public GameSlotMachine()
		{
			this.SlotMachineCards = SetDefaultSlotMachine();
		}

		List<SlotMachineCard> SetDefaultSlotMachine()
		{
			var slotMachineCards = new List<SlotMachineCard>();

			slotMachineCards.Add(new SlotMachineCard
			{
				Name = "Wildcard",
				Token = "*",
				Coefficient = 0,
				Probability = 5
			});

			slotMachineCards.Add(new SlotMachineCard
			{
				Name = "Banana",
				Token = "B",
				Coefficient = 0.6,
				Probability = 35
			});
			slotMachineCards.Add(new SlotMachineCard
			{
				Name = "Pineapple",
				Token = "P",
				Coefficient = 0.8,
				Probability = 15
			});
			slotMachineCards.Add(new SlotMachineCard
			{
				Name = "Apple",
				Token = "A",
				Coefficient = 0.4,
				Probability = 45
			});

			SetCumulativeProbability(slotMachineCards);

			return slotMachineCards;
		}

		void SetCumulativeProbability(List<SlotMachineCard>slotMachineCards)
		{
			for (var i = 0; i < slotMachineCards.Count; i++)
			{
				if (i == 0)
				{
					slotMachineCards[i].CumulativeProbability = slotMachineCards[i].Probability;
				}
				else
				{
					slotMachineCards[i].CumulativeProbability = slotMachineCards[i].Probability + slotMachineCards[i - 1].CumulativeProbability;
				}
			}
		}
	}
}
