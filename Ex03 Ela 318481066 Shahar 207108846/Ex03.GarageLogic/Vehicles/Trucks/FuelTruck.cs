namespace Ex03.GarageLogic
{
	internal class FuelTruck : Vehicle
	{
		private bool m_IsCarryingRefrigeratedCargo;
		private float m_CargoVolume;
		private const eFuelType k_FuelType = eFuelType.Soler;
		private const float k_CurrentFuelAmountInLiters = 0.0f;
		private const float k_MaxFuelAmountInLiters = 125.0f;
		private const int k_NumberOfWheels = 14;
		private const float k_MaxAirPressure = 28.0f;

		internal FuelTruck(string i_LicenseID, string i_ModelName)
			: base(i_LicenseID, i_ModelName, new FueledEngine(k_FuelType, k_CurrentFuelAmountInLiters, k_MaxFuelAmountInLiters))
		{
		}

		internal bool IsCarryingRefrigeratedCargo
		{
			get
			{
				return m_IsCarryingRefrigeratedCargo;
			}

			set
			{
				m_IsCarryingRefrigeratedCargo = value;
			}
		}

		internal float CargoVolume
		{
			get
			{
				return m_CargoVolume;
			}

			set
			{
				m_CargoVolume = value;
			}
		}

		internal override void InitializeSpecificInfo(string[] i_VehicleData)
		{
			IsCarryingRefrigeratedCargo = parseRefrigeratedCargo(i_VehicleData[k_FirstSpecificInfoIndex]);
			CargoVolume = float.Parse(i_VehicleData[k_FirstSpecificInfoIndex + 1]);
		}

		private bool parseRefrigeratedCargo(string i_IsCarryingRefrigeratedCargo)
		{
			bool isCarryingRefrigeratedCargo;

			switch(i_IsCarryingRefrigeratedCargo)
			{
				case "true":
				case "True":
					isCarryingRefrigeratedCargo = true;
					break;
				case "false":
				case "False":
					isCarryingRefrigeratedCargo = false;
					break;
				default:
					throw new System.ArgumentException("Invalid refrigerated cargo value.");
			}

			return isCarryingRefrigeratedCargo;
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
