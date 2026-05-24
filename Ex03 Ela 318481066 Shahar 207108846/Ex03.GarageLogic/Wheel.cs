namespace Ex03.GarageLogic
{
	internal class Wheel
	{
		private string m_ManufacturerName;
		private float m_CurrentAirPressure;
		private float m_MaxAirPressure;

		internal void Inflate(float i_AirPressureToAdd)
		{
			float maxAirPressureToAdd = m_MaxAirPressure - m_CurrentAirPressure;

			if(i_AirPressureToAdd < 0 || i_AirPressureToAdd > maxAirPressureToAdd)
			{
				throw new ValueRangeException(0, maxAirPressureToAdd);
			}
			else
			{
				m_CurrentAirPressure += i_AirPressureToAdd;
			}
		}
	}
}
