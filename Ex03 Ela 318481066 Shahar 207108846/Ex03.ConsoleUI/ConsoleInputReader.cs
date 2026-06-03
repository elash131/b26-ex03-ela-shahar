using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	internal class ConsoleInputReader
	{
		internal float ReadFloat(string i_FieldLabel)
		{
			string input = Console.ReadLine();

			if(!float.TryParse(input, out float value))
			{
				throw new FormatException(string.Format("'{0}' is not a valid number for {1}.", input, i_FieldLabel));
			}

			return value;
		}

		internal eFuelType ReadFuelType()
		{
			string input = Console.ReadLine();

			if(!Enum.TryParse(input, out eFuelType fuelType) || !Enum.IsDefined(typeof(eFuelType), fuelType))
			{
				throw new FormatException(string.Format("'{0}' is not a valid fuel type.", input));
			}

			return fuelType;
		}

		internal eVehicleStatus ReadVehicleStatus()
		{
			string input = Console.ReadLine();

			if(!Enum.TryParse(input, out eVehicleStatus status) || !Enum.IsDefined(typeof(eVehicleStatus), status))
			{
				throw new FormatException(string.Format("'{0}' is not a valid vehicle status.", input));
			}

			return status;
		}
	}
}
