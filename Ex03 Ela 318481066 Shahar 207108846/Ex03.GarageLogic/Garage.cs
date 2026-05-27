using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public class Garage
	{
		private Dictionary<string, GarageVehicleRecord> m_VehicleRecords;

        public void LoadVehiclesFromDB()
        {
            //System.IO.File.ReadAllLines
        }

        public bool IsVehicleInsideTheGarge(string i_LicenseID)
        {
            return true;
        }

    }
}


//THE FORMAT IS:
//VehicleType, LicensePlate, ModelName, EnergyPercentage, TierModel, CurrAirPressure, OwnerName, OwnerPhone, [SPECIFIC VEHICLE PROPERTIES]
