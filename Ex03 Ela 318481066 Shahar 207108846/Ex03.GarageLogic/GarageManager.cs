using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public class GarageManager
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

		public GarageManager()
		{
			r_VehicleRecords = new Dictionary<string, GarageVehicleRecord>();
		}

		public void LoadVehiclesFromDB()
		{
			string[] vehicleLines = System.IO.File.ReadAllLines(k_VehiclesDBFileName);
			int lineNumber = 0;

			foreach(string vehicleLine in vehicleLines)
			{
				lineNumber++;

				try
				{
					loadVehicleFromDBLine(vehicleLine);
				}
				catch(ValueRangeException exception)
				{
					throw new ValueRangeException(
						string.Format("DB file is invalid at line {0}: {1}", lineNumber, exception.Message),
						exception.MinValue,
						exception.MaxValue);
				}
				catch(System.Exception exception)
				{
					throw new System.FormatException(
						string.Format("DB file is invalid at line {0}: {1}", lineNumber, exception.Message));
				}
			}
		}

		public bool IsVehicleInsideTheGarage(string i_LicenseID)
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

		public void AddCreatedVehicle(
			Vehicle i_Vehicle,
			string i_EnergyPercentage,
			string i_WheelManufacturerName,
			string i_CurrentAirPressure,
			string i_OwnerName,
			string i_OwnerPhone,
			string[] i_SpecificVehicleProperties)
		{
			string licenseID = i_Vehicle.LicenseID;

			if(r_VehicleRecords.ContainsKey(licenseID))
			{
				r_VehicleRecords[licenseID].Status = eVehicleStatus.InRepair;
			}
			else
			{
				i_Vehicle.InitializeEnergy(parseFloat(i_EnergyPercentage, "Energy percentage"));
				i_Vehicle.InitializeWheels(
					i_WheelManufacturerName,
					parseFloat(i_CurrentAirPressure, "Wheel air pressure"));
				i_Vehicle.InitializeSpecificInfo(i_SpecificVehicleProperties);
				r_VehicleRecords.Add(
					licenseID,
					new GarageVehicleRecord(i_Vehicle, i_OwnerName, i_OwnerPhone));
			}
		}

		private void loadVehicleFromDBLine(string i_VehicleLine)
		{
			string[] vehicleData = i_VehicleLine.Split(',');

			if(vehicleData.Length < k_FirstSpecificInfoIndex)
			{
				throw new System.FormatException(
					string.Format("Vehicle data line must contain at least {0} fields.", k_FirstSpecificInfoIndex));
			}

			string[] specificVehicleProperties = getSpecificVehicleProperties(vehicleData);

			Vehicle vehicle = VehicleCreator.CreateVehicle(
				vehicleData[k_VehicleTypeIndex],
				vehicleData[k_LicenseIDIndex],
				vehicleData[k_ModelNameIndex]);

			if(vehicle == null)
			{
				throw new System.FormatException(
					string.Format("'{0}' is not a valid vehicle type.", vehicleData[k_VehicleTypeIndex]));
			}

			AddCreatedVehicle(
				vehicle,
				vehicleData[k_EnergyPercentageIndex],
				vehicleData[k_WheelManufacturerIndex],
				vehicleData[k_CurrentAirPressureIndex],
				vehicleData[k_OwnerNameIndex],
				vehicleData[k_OwnerPhoneIndex],
				specificVehicleProperties);
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
			if(!float.TryParse(i_RawValue, out float value))
			{
				throw new System.FormatException(
					string.Format("'{0}' is not a valid number for {1}.", i_RawValue, i_FieldLabel));
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
