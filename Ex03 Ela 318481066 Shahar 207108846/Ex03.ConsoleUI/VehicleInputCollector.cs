using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	internal class VehicleInputCollector
	{
		private readonly Garage r_Garage;

		internal VehicleInputCollector(Garage i_Garage)
		{
			r_Garage = i_Garage;
		}

		internal void CollectAndAdd(string i_LicenseID)
		{
			string vehicleType = readVehicleType();

			Console.Write("Enter model name: ");
			string modelName = Console.ReadLine();
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

			string[] specificVehicleProperties = getSpecificVehicleProperties(vehicleType);

			r_Garage.AddVehicleToGarage(
				vehicleType,
				i_LicenseID,
				modelName,
				energyPercentageInput,
				wheelManufacturerName,
				currentAirPressureInput,
				ownerName,
				ownerPhone,
				specificVehicleProperties);

			Console.WriteLine("Vehicle was added to the garage successfully.");
		}

		private string readVehicleType()
		{
			List<string> supportedVehicleTypes = r_Garage.SupportedVehicleTypes;
			int selectedVehicleTypeIndex;
			string vehicleType;
			int optionNumber = 1;

			Console.WriteLine("Supported vehicle types:");

			foreach(string supportedVehicleType in supportedVehicleTypes)
			{
				Console.WriteLine("{0}. {1}", optionNumber, supportedVehicleType);
				optionNumber++;
			}

			Console.Write("Enter vehicle type number: ");

			if(!int.TryParse(Console.ReadLine(), out selectedVehicleTypeIndex)
				|| selectedVehicleTypeIndex < 1
				|| selectedVehicleTypeIndex > supportedVehicleTypes.Count)
			{
				throw new FormatException("Invalid vehicle type.");
			}

			vehicleType = supportedVehicleTypes[selectedVehicleTypeIndex - 1];

			return vehicleType;
		}

		private string[] getSpecificVehicleProperties(string i_VehicleType)
		{
			string[] specificVehicleProperties;

			switch(i_VehicleType)
			{
				case "FuelCar":
				case "ElectricCar":
					specificVehicleProperties = getCarSpecificProperties();
					break;
				case "FuelMotorcycle":
				case "ElectricMotorcycle":
					specificVehicleProperties = getMotorcycleSpecificProperties();
					break;
				case "FuelTruck":
					specificVehicleProperties = getTruckSpecificProperties();
					break;
				default:
					throw new FormatException("Invalid vehicle type.");
			}

			return specificVehicleProperties;
		}

		private string[] getCarSpecificProperties()
		{
			Console.Write("Enter car color (Red, Yellow, Black, Silver): ");
			string color = Console.ReadLine();
			Console.Write("Enter number of doors (2, 3, 4, 5): ");
			string numberOfDoors = Console.ReadLine();

			return new string[] { color, numberOfDoors };
		}

		private string[] getMotorcycleSpecificProperties()
		{
			Console.Write("Enter motorcycle license type (A, A2, B1, AB): ");
			string licenseType = Console.ReadLine();
			Console.Write("Enter engine volume in CC: ");
			string engineVolumeInCC = Console.ReadLine();

			return new string[] { licenseType, engineVolumeInCC };
		}

		private string[] getTruckSpecificProperties()
		{
			Console.Write("Is the truck carrying refrigerated cargo (true/false): ");
			string isCarryingRefrigeratedCargo = Console.ReadLine();
			Console.Write("Enter cargo volume: ");
			string cargoVolume = Console.ReadLine();

			return new string[] { isCarryingRefrigeratedCargo, cargoVolume };
		}
	}
}
