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

		internal override void InitializeSpecificInfo(string[] i_VehicleData)
		{
			LicenseType = parseLicenseType(i_VehicleData[k_FirstSpecificInfoIndex]);
			EngineVolumeInCC = int.Parse(i_VehicleData[k_FirstSpecificInfoIndex + 1]);
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
					throw new System.ArgumentException("Invalid motorcycle license type.");
			}

			return licenseType;
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
	}
}
