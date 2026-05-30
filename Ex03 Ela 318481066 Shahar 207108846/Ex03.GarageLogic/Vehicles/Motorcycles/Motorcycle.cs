namespace Ex03.GarageLogic
{
	internal abstract class Motorcycle : Vehicle
	{
		private eMotorcycleLicenseType m_LicenseType;
		private int m_EngineVolumeInCC;
		private const int k_NumberOfWheels = 2;
		private const float k_MaxAirPressure = 30.0f;

		internal Motorcycle(string i_LicenseID, string i_ModelName, Engine i_Engine)
			: base(i_LicenseID, i_ModelName, i_Engine)
		{
		}

		internal eMotorcycleLicenseType LicenseType
		{
			get
			{
				return m_LicenseType;
			}

			set
			{
				m_LicenseType = value;
			}
		}

		internal int EngineVolumeInCC
		{
			get
			{
				return m_EngineVolumeInCC;
			}

			set
			{
				m_EngineVolumeInCC = value;
			}
		}

		internal override void InitializeSpecificInfo(string[] i_SpecificVehicleProperties)
		{
			LicenseType = parseLicenseType(i_SpecificVehicleProperties[0]);
			EngineVolumeInCC = parseEngineVolumeInCC(i_SpecificVehicleProperties[1]);
		}

		private eMotorcycleLicenseType parseLicenseType(string i_LicenseType)
		{
			eMotorcycleLicenseType licenseType;

			switch(i_LicenseType)
			{
				case "A":
					licenseType = eMotorcycleLicenseType.A;
					break;
				case "A2":
					licenseType = eMotorcycleLicenseType.A2;
					break;
				case "B1":
					licenseType = eMotorcycleLicenseType.B1;
					break;
				case "AB":
					licenseType = eMotorcycleLicenseType.AB;
					break;
				default:
					throw new System.FormatException("Invalid motorcycle license type.");
			}

			return licenseType;
		}

		private int parseEngineVolumeInCC(string i_EngineVolumeInCC)
		{
			int engineVolumeInCC;

			if(!int.TryParse(i_EngineVolumeInCC, out engineVolumeInCC))
			{
				throw new System.FormatException("Engine volume must be a whole number.");
			}

			return engineVolumeInCC;
		}

		protected override int NumberOfWheels
		{
			get
			{
				return k_NumberOfWheels;
			}
		}

		protected override float MaxAirPressure
		{
			get
			{
				return k_MaxAirPressure;
			}
		}

		public override string ToString()
		{
			string motorcycleDetails = string.Format(
				"{0}{1}License type: {2}{1}Engine volume in CC: {3}",
				base.ToString(),
				System.Environment.NewLine,
				m_LicenseType,
				m_EngineVolumeInCC);

			return motorcycleDetails;
		}
	}
}
