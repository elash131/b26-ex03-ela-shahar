namespace Ex03.GarageLogic
{
	internal class GarageVehicleRecord
	{
		private readonly Vehicle r_Vehicle;
		private readonly string r_OwnerName;
		private readonly string r_OwnerPhone;
		private eVehicleStatus m_Status;

		internal GarageVehicleRecord(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
		{
			r_Vehicle = i_Vehicle;
			r_OwnerName = i_OwnerName;
			r_OwnerPhone = i_OwnerPhone;
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
				return r_Vehicle;
			}
		}

		public override string ToString()
		{
			string garageVehicleRecordDetails = string.Format(
				"Owner name: {0}{1}Owner phone: {2}{1}Vehicle status: {3}{1}{4}",
				r_OwnerName,
				System.Environment.NewLine,
				r_OwnerPhone,
				m_Status,
				r_Vehicle.ToString());

			return garageVehicleRecordDetails;
		}
	}
}
