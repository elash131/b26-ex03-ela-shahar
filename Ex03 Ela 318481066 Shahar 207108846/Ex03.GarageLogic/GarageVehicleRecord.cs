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

		internal eVehicleStatus Status
		{
			get
			{
				return m_Status;
			}

			set
			{
				m_Status = value;
			}
		}

		internal Vehicle Vehicle
		{
			get
			{
				return m_Vehicle;
			}
		}

		public override string ToString()
		{
			string garageVehicleRecordDetails = string.Format(
				"Owner name: {0}{1}Owner phone: {2}{1}Vehicle status: {3}{1}{4}",
				m_OwnerName,
				System.Environment.NewLine,
				m_OwnerPhone,
				m_Status,
				m_Vehicle.ToString());

			return garageVehicleRecordDetails;
		}
	}
}
