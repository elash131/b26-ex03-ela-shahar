using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	internal class GarageUI
	{
		private readonly Garage r_Garage;
		private readonly VehicleInputCollector r_VehicleInputCollector;
		private readonly ConsoleInputReader r_InputReader;
		private const float k_MinEnergyPercentage = 0.0f;
		private const float k_MaxEnergyPercentage = 100.0f;
		private const float k_MinAirPressure = 0.0f;
		private const float k_CarMaxAirPressure = 31.0f;
		private const float k_MotorcycleMaxAirPressure = 30.0f;
		private const float k_TruckMaxAirPressure = 28.0f;

		internal GarageUI()
		{
			r_Garage = new Garage();
			r_VehicleInputCollector = new VehicleInputCollector(r_Garage);
			r_InputReader = new ConsoleInputReader();
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
					"{0} is outside the allowed range.",
					exception.Message);
                Console.WriteLine(
					"Allowed range: {0} to {1}.",
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
				r_VehicleInputCollector.CollectAndAdd(licenseID);
			}
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
				filterStatus = r_InputReader.ReadVehicleStatus();
			}

			licenseIDs = r_Garage.GetLicenseIDs(filterStatus);

			if(licenseIDs.Count == 0)
			{
				Console.WriteLine("(No vehicles match.)");
			}
			else
			{
				foreach(string licenseID in licenseIDs)
				{
					Console.WriteLine(licenseID);
				}
			}
		}

		private void changeVehicleStatus()
		{
			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();
			Console.Write("Enter new status (InRepair, Repaired, Paid): ");
			eVehicleStatus newStatus = r_InputReader.ReadVehicleStatus();

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
			eFuelType fuelType = r_InputReader.ReadFuelType();
			Console.Write("Enter fuel amount to add: ");
			float litersToAdd = r_InputReader.ReadFloat("Fuel amount");

			r_Garage.RefuelVehicle(licenseID, fuelType, litersToAdd);
			Console.WriteLine("Vehicle was refueled successfully.");
		}

		private void chargeVehicle()
		{
			Console.Write("Enter license ID: ");
			string licenseID = Console.ReadLine();
			Console.Write("Enter charge time in minutes: ");
			float minutesToCharge = r_InputReader.ReadFloat("Charge time");

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
	}
}
