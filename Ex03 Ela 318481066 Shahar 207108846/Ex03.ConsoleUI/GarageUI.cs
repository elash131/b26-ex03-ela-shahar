using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	internal class GarageUI
	{
		private readonly Garage r_Garage;
		private const float k_MinEnergyPercentage = 0.0f;
		private const float k_MaxEnergyPercentage = 100.0f;
		private const float k_MinAirPressure = 0.0f;
		private const float k_CarMaxAirPressure = 31.0f;
		private const float k_MotorcycleMaxAirPressure = 30.0f;
		private const float k_TruckMaxAirPressure = 28.0f;

		internal GarageUI()
		{
			r_Garage = new Garage();
		}

		internal void Run()
		{
			eMainMenuOption selectedOption = eMainMenuOption.Exit;
			bool shouldExit = false;

			while(!shouldExit)
			{
				showMainMenu();

				if(Enum.TryParse(Console.ReadLine(), out selectedOption)
					&& Enum.IsDefined(typeof(eMainMenuOption), selectedOption))
				{
					shouldExit = handleMenuOption(selectedOption);
				}
				else
				{
					Console.WriteLine("Invalid menu option.");
					waitBeforeReturningToMenu();
				}
			}
		}

		private bool handleMenuOption(eMainMenuOption i_SelectedOption)
		{
			bool shouldExit = false;

			try
			{
				switch(i_SelectedOption)
				{
					case eMainMenuOption.LoadVehiclesFromFile:
						loadVehiclesFromFile();
						break;
					case eMainMenuOption.InsertNewVehicleToGarage:
						insertNewVehicleToGarage();
						break;
					case eMainMenuOption.DisplayLicenseNumbers:
						displayLicenseNumbers();
						break;
					case eMainMenuOption.ChangeVehicleStatus:
						changeVehicleStatus();
						break;
					case eMainMenuOption.InflateWheelsToMax:
						inflateWheelsToMax();
						break;
					case eMainMenuOption.RefuelVehicle:
						refuelVehicle();
						break;
					case eMainMenuOption.ChargeVehicle:
						chargeVehicle();
						break;
					case eMainMenuOption.DisplayVehicleDetails:
						displayVehicleDetails();
						break;
					case eMainMenuOption.Exit:
						shouldExit = true;
						break;
				}
			}
			catch(ValueRangeException exception)
			{
				Console.WriteLine(
					"{0} is outside the allowed range. Please enter a value between {1} and {2}.",
					exception.Message,
					exception.MinValue,
					exception.MaxValue);
			}
			catch(FormatException exception)
			{
				Console.WriteLine("Invalid input: {0}", exception.Message);
			}
			catch(ArgumentException exception)
			{
				Console.WriteLine("The requested action cannot be completed: {0}", exception.Message);
			}
			catch(Exception)
			{
				Console.WriteLine("An unexpected error occurred. Please try again.");
			}

			if(!shouldExit)
			{
				waitBeforeReturningToMenu();
			}

			return shouldExit;
		}

		private void loadVehiclesFromFile()
		{
			r_Garage.LoadVehiclesFromDB();
			Console.WriteLine("Vehicles were loaded successfully.");
		}

		private void insertNewVehicleToGarage()
		{
			Console.Clear();
			Console.WriteLine("Insert New Vehicle To Garage");
			Console.WriteLine("============================");

			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();

			if(r_Garage.IsVehicleInsideTheGarge(licenseID))
			{
				r_Garage.ChangeVehicleStatus(licenseID, eVehicleStatus.InRepair);
				Console.WriteLine("Vehicle already exists in the garage. Its status was changed to InRepair.");
			}
			else
			{
				insertNewVehicleByCollectedDetails(licenseID);
			}
		}

		private void insertNewVehicleByCollectedDetails(string i_LicenseID)
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

		private void displayLicenseNumbers()
		{
			Console.Write("Filter by status? (Y/N): ");
			bool shouldFilterByStatus = Console.ReadLine().ToLower() == "y";
			eVehicleStatus? filterStatus = null;
			List<string> licenseIDs;

			if(shouldFilterByStatus)
			{
				Console.Write("Enter status (InRepair, Repaired, Paid): ");
				filterStatus = readVehicleStatus();
			}

			licenseIDs = r_Garage.GetLicenseIDs(filterStatus);

			foreach(string licenseID in licenseIDs)
			{
				Console.WriteLine(licenseID);
			}
		}

		private void changeVehicleStatus()
		{
			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();
			Console.Write("Enter new status (InRepair, Repaired, Paid): ");
			eVehicleStatus newStatus = readVehicleStatus();

			r_Garage.ChangeVehicleStatus(licenseID, newStatus);
			Console.WriteLine("Vehicle status was changed successfully.");
		}

		private void inflateWheelsToMax()
		{
			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();

			r_Garage.InflateVehicleWheelsToMax(licenseID);
			Console.WriteLine("Vehicle wheels were inflated to maximum.");
		}

		private void refuelVehicle()
		{
			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();
			Console.Write("Enter fuel type (Octan98, Octan96, Octan95, Soler): ");
			eFuelType fuelType = readFuelType();
			Console.Write("Enter fuel amount to add: ");
			float litersToAdd = readFloat("Fuel amount");

			r_Garage.RefuelVehicle(licenseID, fuelType, litersToAdd);
			Console.WriteLine("Vehicle was refueled successfully.");
		}

		private void chargeVehicle()
		{
			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();
			Console.Write("Enter charge time in minutes: ");
			float minutesToCharge = readFloat("Charge time");

			r_Garage.ChargeVehicle(licenseID, minutesToCharge);
			Console.WriteLine("Vehicle was charged successfully.");
		}

		private void displayVehicleDetails()
		{
			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();

			Console.WriteLine(r_Garage.GetVehicleDetails(licenseID));
		}
		
		private void waitBeforeReturningToMenu()
		{
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		private void showMainMenu()
		{
			Console.Clear();
			Console.WriteLine("Garage Management System");
			Console.WriteLine("========================");
			Console.WriteLine("1. Load vehicle data from file");
			Console.WriteLine("2. Insert a new vehicle to the garage");
			Console.WriteLine("3. Display license numbers in the garage");
			Console.WriteLine("4. Change vehicle status");
			Console.WriteLine("5. Inflate vehicle wheels to maximum");
			Console.WriteLine("6. Refuel a fueled vehicle");
			Console.WriteLine("7. Charge an electric vehicle");
			Console.WriteLine("8. Display full vehicle details");
			Console.WriteLine("9. Exit");
			Console.WriteLine();
			Console.Write("Please choose an option: ");
		}

		private float readFloat(string i_FieldLabel)
		{
			string input = Console.ReadLine();
			float value;

			if(!float.TryParse(input, out value))
			{
				throw new FormatException(string.Format("{0} must be a number.", i_FieldLabel));
			}

			return value;
		}

		private eFuelType readFuelType()
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

		private eVehicleStatus readVehicleStatus()
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
