using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	internal class VehicleInputCollector
	{
		private readonly GarageManager r_GarageManager;

		internal VehicleInputCollector(GarageManager i_GarageManager)
		{
			r_GarageManager = i_GarageManager;
		}

		internal void AddVehicleFromUserInput(string i_LicenseID)
		{
			string vehicleType = readVehicleType();

			Console.Write("Enter model name: ");
			string modelName = Console.ReadLine();

			Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, i_LicenseID, modelName);

			if(vehicle == null)
			{
				throw new FormatException(string.Format("'{0}' is not a valid vehicle type.", vehicleType));
			}

			Console.Write("Enter remaining energy percentage: ");
			string energyPercentageInput = Console.ReadLine();
			Console.Write("Enter wheel manufacturer name: ");
			string wheelManufacturerName = Console.ReadLine();
			Console.Write("Enter current wheel air pressure: ");
			string currentAirPressureInput = Console.ReadLine();
			Console.Write("Enter owner name: ");
			string ownerName = Console.ReadLine();
			Console.Write("Enter owner phone: ");
			string ownerPhone = Console.ReadLine();

			string[] specificProperties = collectSpecificProperties(vehicle);

			r_GarageManager.AddCreatedVehicle(
				vehicle,
				energyPercentageInput,
				wheelManufacturerName,
				currentAirPressureInput,
				ownerName,
				ownerPhone,
				specificProperties);

			Console.WriteLine("Vehicle was added to the garage successfully.");
		}

		private string readVehicleType()
		{
			List<string> supportedVehicleTypes = r_GarageManager.SupportedVehicleTypes;
			string vehicleTypeInput;
			int optionNumber = 1;

			Console.WriteLine("Supported vehicle types:");
			foreach(string supportedVehicleType in supportedVehicleTypes)
			{
				Console.WriteLine("{0}. {1}", optionNumber, supportedVehicleType);
				optionNumber++;
			}

			Console.Write("Enter vehicle type number: ");
			vehicleTypeInput = Console.ReadLine();

			if(!int.TryParse(vehicleTypeInput, out int selectedVehicleTypeIndex)
				|| selectedVehicleTypeIndex < 1
				|| selectedVehicleTypeIndex > supportedVehicleTypes.Count)
			{
				throw new FormatException(string.Format("'{0}' is not a valid vehicle type.", vehicleTypeInput));
			}

			return supportedVehicleTypes[selectedVehicleTypeIndex - 1];
		}

		private string[] collectSpecificProperties(Vehicle i_Vehicle)
		{
			List<string> labels = i_Vehicle.SpecificPropertyLabels;
			string[] values = new string[labels.Count];
			int index = 0;

			foreach(string label in labels)
			{
				Console.Write("Enter {0}: ", label);
				values[index] = Console.ReadLine();
				index++;
			}

			return values;
		}
	}
}
