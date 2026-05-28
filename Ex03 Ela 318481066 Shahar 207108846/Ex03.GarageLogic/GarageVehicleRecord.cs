namespace Ex03.GarageLogic
{
	internal class GarageVehicleRecord
	{
		private Vehicle m_Vehicle;
		private string m_OwnerName;
		private string m_OwnerPhone;
		private eVehicleStatus m_Status;

		internal GarageVehicleRecord(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
		{
			m_Vehicle = i_Vehicle;
			m_OwnerName = i_OwnerName;
			m_OwnerPhone = i_OwnerPhone;
			m_Status = eVehicleStatus.InRepair;
		}
	}
}
