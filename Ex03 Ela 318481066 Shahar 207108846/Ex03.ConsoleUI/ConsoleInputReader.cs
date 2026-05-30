using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	internal class ConsoleInputReader
	{
		internal float ReadFloat(string i_FieldLabel)
		{
			string input = Console.ReadLine();
			float value;

			if(!float.TryParse(input, out value))
			{
				throw new FormatException(string.Format("{0} must be a number.", i_FieldLabel));
			}

			return value;
		}

		internal eFuelType ReadFuelType()
		{
			string input = Console.ReadLine();
			eFuelType fuelType;

			switch(input)
			{
				case "Octan98":
					fuelType = eFuelType.Octan98;
					break;
				case "Octan96":
					fuelType = eFuelType.Octan96;
					break;
				case "Octan95":
					fuelType = eFuelType.Octan95;
					break;
				case "Soler":
					fuelType = eFuelType.Soler;
					break;
				default:
					throw new FormatException(string.Format("'{0}' is not a valid fuel type.", input));
			}

			return fuelType;
		}

		internal eVehicleStatus ReadVehicleStatus()
		{
			string input = Console.ReadLine();
			eVehicleStatus status;

			switch(input)
			{
				case "InRepair":
					status = eVehicleStatus.InRepair;
					break;
				case "Repaired":
					status = eVehicleStatus.Repaired;
					break;
				case "Paid":
					status = eVehicleStatus.Paid;
					break;
				default:
					throw new FormatException(string.Format("'{0}' is not a valid vehicle status.", input));
			}

			return status;
		}
	}
}
