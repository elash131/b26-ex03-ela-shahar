namespace Ex03.GarageLogic
{
	internal class Wheel
	{
		private string m_ManufacturerName;
		private float m_CurrentAirPressure;
		private float m_MaxAirPressure;

		internal void Inflate(float i_AirPressureToAdd)
		{
			if(m_CurrentAirPressure + i_AirPressureToAdd > m_MaxAirPressure)
			{
				// TODO: Throw ValueOutOfRangeException after we implement the custom exception.
			}
			else
			{
				m_CurrentAirPressure += i_AirPressureToAdd;
			}
		}
	}
}
