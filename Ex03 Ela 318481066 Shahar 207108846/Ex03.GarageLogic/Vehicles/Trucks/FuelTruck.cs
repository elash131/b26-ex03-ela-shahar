using System.Collections.Generic;

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

		internal override void InitializeSpecificInfo(string[] i_SpecificVehicleProperties)
		{
			IsCarryingRefrigeratedCargo = parseRefrigeratedCargo(i_SpecificVehicleProperties[0]);
			CargoVolume = parseCargoVolume(i_SpecificVehicleProperties[1]);
		}

        private bool parseRefrigeratedCargo(string i_IsCarryingRefrigeratedCargo)
        {
            if (!bool.TryParse(i_IsCarryingRefrigeratedCargo, out bool isCarryingRefrigeratedCargo))
            {
                throw new System.FormatException(
                    string.Format("'{0}' is not a valid refrigerated cargo value.", i_IsCarryingRefrigeratedCargo));
            }

            return isCarryingRefrigeratedCargo;
        }

        private float parseCargoVolume(string i_CargoVolume)
		{
			if(!float.TryParse(i_CargoVolume, out float cargoVolume))
			{
				throw new System.FormatException(string.Format("'{0}' is not a valid cargo volume.", i_CargoVolume));
			}

			return cargoVolume;
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

		public override List<string> SpecificPropertyLabels
		{
			get
			{
				return new List<string>
				{
					"is carrying refrigerated cargo (true/false)",
					"cargo volume"
				};
			}
		}

		public override string ToString()
		{
			string fuelTruckDetails = string.Format(
				"{0}{1}Carrying refrigerated cargo: {2}{1}Cargo volume: {3}",
				base.ToString(),
				System.Environment.NewLine,
				m_IsCarryingRefrigeratedCargo,
				m_CargoVolume);

			return fuelTruckDetails;
		}
	}
}
