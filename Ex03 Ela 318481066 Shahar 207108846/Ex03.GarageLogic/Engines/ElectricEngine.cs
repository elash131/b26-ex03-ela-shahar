namespace Ex03.GarageLogic
{
	internal class ElectricEngine : Engine
	{
		internal void Charge(float i_HoursToAdd)
		{
			AddEnergy(i_HoursToAdd);
		}
	}
}
