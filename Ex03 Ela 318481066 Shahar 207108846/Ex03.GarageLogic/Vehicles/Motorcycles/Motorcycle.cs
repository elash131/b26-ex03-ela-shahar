using System.Collections.Generic;

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
			if(!System.Enum.TryParse(i_LicenseType, out eMotorcycleLicenseType licenseType)
				|| !System.Enum.IsDefined(typeof(eMotorcycleLicenseType), licenseType))
			{
				throw new System.FormatException(string.Format("'{0}' is not a valid motorcycle license type.", i_LicenseType));
			}

			return licenseType;
		}

		private int parseEngineVolumeInCC(string i_EngineVolumeInCC)
		{
			int engineVolumeInCC;

			if(!int.TryParse(i_EngineVolumeInCC, out engineVolumeInCC))
			{
				throw new System.FormatException(
					string.Format("'{0}' is not a valid engine volume.", i_EngineVolumeInCC));
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

		public override List<string> SpecificPropertyLabels
		{
			get
			{
				return new List<string>
				{
					string.Format(
						"motorcycle license type ({0})",
						string.Join(", ", System.Enum.GetNames(typeof(eMotorcycleLicenseType)))),
					"engine volume in CC"
				};
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
