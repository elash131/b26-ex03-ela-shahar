namespace Ex03.GarageLogic
{
	internal abstract class Car : Vehicle
	{
		private eCarColor m_Color;
		private eNumberOfDoors m_NumberOfDoors;
		private const int k_NumberOfWheels = 5;
		private const float k_MaxAirPressure = 31.0f;

		internal Car(string i_LicenseID, string i_ModelName, Engine i_Engine)
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
