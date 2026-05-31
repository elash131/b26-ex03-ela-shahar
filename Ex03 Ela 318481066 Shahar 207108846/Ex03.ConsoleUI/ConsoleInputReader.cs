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

			try
			{
				fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), input);
			}
			catch(ArgumentException)
			{
				throw new FormatException(string.Format("'{0}' is not a valid fuel type.", input));
			}

			return fuelType;
		}

		internal eVehicleStatus ReadVehicleStatus()
		{
			string input = Console.ReadLine();
			eVehicleStatus status;

			try
			{
				status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), input);
			}
			catch(ArgumentException)
			{
				throw new FormatException(string.Format("'{0}' is not a valid vehicle status.", input));
			}

			return status;
		}
	}
}
