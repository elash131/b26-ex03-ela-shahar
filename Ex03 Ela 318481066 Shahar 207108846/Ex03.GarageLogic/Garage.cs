using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public class Garage
	{
		private readonly Dictionary<string, GarageVehicleRecord> r_VehicleRecords;
		private const string k_VehiclesDBFileName = "VehiclesDB.txt";
		private const int k_VehicleTypeIndex = 0;
		private const int k_LicenseIDIndex = 1;
		private const int k_ModelNameIndex = 2;
		private const int k_EnergyPercentageIndex = 3;
		private const int k_WheelManufacturerIndex = 4;
		private const int k_CurrentAirPressureIndex = 5;
		private const int k_OwnerNameIndex = 6;
		private const int k_OwnerPhoneIndex = 7;
		private const int k_FirstSpecificInfoIndex = 8;

		public Garage()
		{
			r_VehicleRecords = new Dictionary<string, GarageVehicleRecord>();
		}

		public void LoadVehiclesFromDB()
		{
			string[] vehicleLines = System.IO.File.ReadAllLines(k_VehiclesDBFileName);

			foreach(string vehicleLine in vehicleLines)
			{
				loadVehicleFromDBLine(vehicleLine);
			}
		}

		public bool IsVehicleInsideTheGarge(string i_LicenseID)
		{
			return r_VehicleRecords.ContainsKey(i_LicenseID);
		}

		public List<string> SupportedVehicleTypes
		{
			get
			{
				List<string> supportedVehicleTypes = VehicleCreator.SupportedTypes;

				return supportedVehicleTypes;
			}
		}

		public List<string> GetLicenseIDs(eVehicleStatus? i_FilterStatus)
		{
			List<string> licenseIDs = new List<string>();

			foreach(KeyValuePair<string, GarageVehicleRecord> vehicleRecord in r_VehicleRecords)
			{
				if(!i_FilterStatus.HasValue || vehicleRecord.Value.Status == i_FilterStatus.Value)
				{
					licenseIDs.Add(vehicleRecord.Key);
				}
			}

			return licenseIDs;
		}

		public void ChangeVehicleStatus(string i_LicenseID, eVehicleStatus i_NewStatus)
		{
			validateVehicleExists(i_LicenseID);

			r_VehicleRecords[i_LicenseID].Status = i_NewStatus;
		}


		public void InflateVehicleWheelsToMax(string i_LicenseID)
		{
			validateVehicleExists(i_LicenseID);

			r_VehicleRecords[i_LicenseID].Vehicle.InflateWheelsToMax();
		}

		public void RefuelVehicle(string i_LicenseID, eFuelType i_FuelType, float i_LitersToAdd)
		{
			validateVehicleExists(i_LicenseID);

			r_VehicleRecords[i_LicenseID].Vehicle.Refuel(i_FuelType, i_LitersToAdd);
		}

		public void ChargeVehicle(string i_LicenseID, float i_MinutesToCharge)
		{
			float hoursToCharge = i_MinutesToCharge / 60;

			validateVehicleExists(i_LicenseID);

			r_VehicleRecords[i_LicenseID].Vehicle.Charge(hoursToCharge);
		}

		public string GetVehicleDetails(string i_LicenseID)
		{
			validateVehicleExists(i_LicenseID);

			return r_VehicleRecords[i_LicenseID].ToString();
		}

		public bool AddVehicleToGarage(
			string i_VehicleType,
			string i_LicenseID,
			string i_ModelName,
			string i_EnergyPercentage,
			string i_WheelManufacturerName,
			string i_CurrentAirPressure,
			string i_OwnerName,
			string i_OwnerPhone,
			string[] i_SpecificVehicleProperties)
		{
			bool isNewVehicle = !r_VehicleRecords.ContainsKey(i_LicenseID);

			if(isNewVehicle)
			{
				addNewVehicleRecord(
					i_VehicleType,
					i_LicenseID,
					i_ModelName,
					i_EnergyPercentage,
					i_WheelManufacturerName,
					i_CurrentAirPressure,
					i_OwnerName,
					i_OwnerPhone,
					i_SpecificVehicleProperties);
			}
			else
			{
				r_VehicleRecords[i_LicenseID].Status = eVehicleStatus.InRepair;
			}

			return isNewVehicle;
		}

		private void loadVehicleFromDBLine(string i_VehicleLine)
		{
			string[] vehicleData = i_VehicleLine.Split(',');
			string[] specificVehicleProperties = getSpecificVehicleProperties(vehicleData);
			
			AddVehicleToGarage(
				vehicleData[k_VehicleTypeIndex],
				vehicleData[k_LicenseIDIndex],
				vehicleData[k_ModelNameIndex],
				vehicleData[k_EnergyPercentageIndex],
				vehicleData[k_WheelManufacturerIndex],
				vehicleData[k_CurrentAirPressureIndex],
				vehicleData[k_OwnerNameIndex],
				vehicleData[k_OwnerPhoneIndex],
				specificVehicleProperties);
		}

		private void addNewVehicleRecord(
			string i_VehicleType,
			string i_LicenseID,
			string i_ModelName,
			string i_EnergyPercentage,
			string i_WheelManufacturerName,
			string i_CurrentAirPressure,
			string i_OwnerName,
			string i_OwnerPhone,
			string[] i_SpecificVehicleProperties)
		{
			Vehicle vehicle = VehicleCreator.CreateVehicle(
				i_VehicleType,
				i_LicenseID,
				i_ModelName);

			if(vehicle == null)
			{
				throw new System.FormatException("Invalid vehicle type.");
			}

			vehicle.InitializeEnergy(parseFloat(i_EnergyPercentage, "Energy percentage"));
			vehicle.InitializeWheels(i_WheelManufacturerName, parseFloat(i_CurrentAirPressure, "Wheel air pressure"));
			vehicle.InitializeSpecificInfo(i_SpecificVehicleProperties);
			r_VehicleRecords.Add(
				i_LicenseID,
				new GarageVehicleRecord(
					vehicle,
					i_OwnerName,
					i_OwnerPhone));
		}

		private void validateVehicleExists(string i_LicenseID)
		{
			if(!r_VehicleRecords.ContainsKey(i_LicenseID))
			{
				throw new System.ArgumentException("Vehicle is not in the garage.");
			}
		}

		private float parseFloat(string i_RawValue, string i_FieldLabel)
		{
			float value;

			if(!float.TryParse(i_RawValue, out value))
			{
				throw new System.FormatException(string.Format("{0} must be a number.", i_FieldLabel));
			}

			return value;
		}
		
		private string[] getSpecificVehicleProperties(string[] i_VehicleData)
		{
			int numberOfSpecificProperties = i_VehicleData.Length - k_FirstSpecificInfoIndex;
			string[] specificVehicleProperties = new string[numberOfSpecificProperties];

			for(int i = 0; i < numberOfSpecificProperties; i++)
			{
				specificVehicleProperties[i] = i_VehicleData[k_FirstSpecificInfoIndex + i];
			}

			return specificVehicleProperties;
		}
	}
}
