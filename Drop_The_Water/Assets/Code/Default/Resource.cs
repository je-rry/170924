using UnityEngine;
using Instruction;
using System.Collections;
using ObjectHierachy;

namespace Instruction
{
	public static class Resource {

		//public static Instruction instruction = new Instructions();

		public delegate void FAILEVENT();

		public static FAILEVENT failEvent = null;

		//public static Character character;
		//public static Vector3[] starPosition;

		public static bool instructionInput = false;

		//public static ArrayList COLORS = new ArrayList ();

		public static bool canClear = true;
		//public static bool movStar = false;
		//public static bool[] movRuby;

		//public static UnityEngine.GameObject[] characters;
		//public static GameObject[] stars;
		//public static GameObject ring;

		public static int stage;
		public static int stage_add=1;

		//public static Color clearedColor;

		//public static Sprite deadCharacter;

		//public static Sprite[][] Accessories;

		public static void clear()
		{
			canClear = true;
		}

		public static string previousScene = "";
	}
}
