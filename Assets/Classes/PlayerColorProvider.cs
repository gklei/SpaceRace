// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
	public enum PlayerColoredComponentType {
		InnerCircle = 0,
		OuterRing = 1,
		ParticleTrail = 2
	}

	public class PlayerColorProvider
	{
		public static Color colorForPlayerNumber(int number, PlayerColoredComponentType componentType)
		{
			Color color = new Color(1, 1, 1);
			if (number == 1)
			{
				color = pinkColorForComponent(componentType);
			}
			else if (number == 2)
			{
				color = greenColorForComponent(componentType);
			}
			else if (number == 3)
			{
				color = blueColorForComponent(componentType);
			}
			else if (number == 4)
			{
				color = purpleColorForComponent(componentType);
			}
			return color;
		}

		public static Vector3 colorVectorForPlayer(PhotonPlayer player, PlayerColoredComponentType componentType)
		{
			Color color = colorForPlayerNumber(player.playerNumber(), componentType);
			return new Vector3(color.r, color.g, color.b);
		}

		// PINK
		private static Color pinkColorForComponent(PlayerColoredComponentType component)
		{
			Vector3 cv = Vector3.zero;
			switch (component)
			{
			case PlayerColoredComponentType.InnerCircle:
				cv = colorVec(255, 53, 94);
				break;
			case PlayerColoredComponentType.OuterRing:
				cv = colorVec(255, 68, 134);
				break;
			case PlayerColoredComponentType.ParticleTrail:
				cv = colorVec(255, 26, 126);
				break;
			}
			return new Color(cv.x, cv.y, cv.z);
		}

		// GREEN
		private static Color greenColorForComponent(PlayerColoredComponentType component)
		{
			Vector3 cv = Vector3.zero;
			switch (component)
			{
			case PlayerColoredComponentType.InnerCircle:
				cv = colorVec(175, 227, 19);
				break;
			case PlayerColoredComponentType.OuterRing:
				cv = colorVec(120, 210, 182);
				break;
			case PlayerColoredComponentType.ParticleTrail:
				cv = colorVec(89, 210, 133);
				break;
			}
			return new Color(cv.x, cv.y, cv.z);
		}
	
		// BLUE
		private static Color blueColorForComponent(PlayerColoredComponentType component)
		{
			Vector3 cv = Vector3.zero;
			switch (component)
			{
			case PlayerColoredComponentType.InnerCircle:
				cv = colorVec(80, 191, 230);
				break;
			case PlayerColoredComponentType.OuterRing:
				cv = colorVec(41, 159, 189);
				break;
			case PlayerColoredComponentType.ParticleTrail:
				cv = colorVec(52, 122, 186);
				break;
			}
			return new Color(cv.x, cv.y, cv.z);
		}

		// PURPLE
		private static Color purpleColorForComponent(PlayerColoredComponentType component)
		{
			Vector3 cv = Vector3.zero;
			switch (component)
			{
			case PlayerColoredComponentType.InnerCircle:
				cv = colorVec(193, 84, 193);
				break;
			case PlayerColoredComponentType.OuterRing:
				cv = colorVec(176, 111, 184);
				break;
			case PlayerColoredComponentType.ParticleTrail:
				cv = colorVec(172, 58, 180);
				break;
			}
			return new Color(cv.x, cv.y, cv.z);
		}

		private static Vector3 colorVec(int red, int green, int blue)
		{
			return new Vector3(red / 255.0f, green / 255.0f, blue / 255.0f);
		}
	}
}

