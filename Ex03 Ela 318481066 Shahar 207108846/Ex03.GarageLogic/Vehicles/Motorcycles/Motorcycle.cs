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
