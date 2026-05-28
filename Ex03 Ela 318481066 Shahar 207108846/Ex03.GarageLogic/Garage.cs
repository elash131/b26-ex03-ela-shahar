using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public class Garage
	{
		private Dictionary<string, GarageVehicleRecord> m_VehicleRecords;
		private const string k_VehiclesDBFileName = "VehiclesDB.txt";
		private const int k_VehicleTypeIndex = 0;
		private const int k_LicenseIDIndex = 1;
		private const int k_ModelNameIndex = 2;
		private const int k_EnergyPercentageIndex = 3;
		private const int k_WheelManufacturerIndex = 4;
		private const int k_CurrentAirPressureIndex = 5;
		private const int k_OwnerNameIndex = 6;
		private const int k_OwnerPhoneIndex = 7;

		public Garage()
		{
			m_VehicleRecords = new Dictionary<string, GarageVehicleRecord>();
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
			bool isVehicleInsideTheGarge = m_VehicleRecords.ContainsKey(i_LicenseID);

			return isVehicleInsideTheGarge;
		}

		private void loadVehicleFromDBLine(string i_VehicleLine)
		{
			string[] vehicleData = i_VehicleLine.Split(',');
			string licenseID = vehicleData[k_LicenseIDIndex];
			Vehicle vehicle = VehicleCreator.CreateVehicle(
				vehicleData[k_VehicleTypeIndex],
				licenseID,
				vehicleData[k_ModelNameIndex]);

			vehicle.InitializeEnergy(float.Parse(vehicleData[k_EnergyPercentageIndex]));
			vehicle.InitializeWheels(
				vehicleData[k_WheelManufacturerIndex],
				float.Parse(vehicleData[k_CurrentAirPressureIndex]));
			vehicle.InitializeSpecificInfo(vehicleData);
			m_VehicleRecords.Add(
				licenseID,
				new GarageVehicleRecord(
					vehicle,
					vehicleData[k_OwnerNameIndex],
					vehicleData[k_OwnerPhoneIndex]));
		}
	}
}
