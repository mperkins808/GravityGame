/*
 * Class auto generated by TexturePacker
 *
 * Contains references to each image within the sprite sheet.
 *
 * https://www.codeandweb.com/texturepacker
 * $TexturePacker:SmartUpdate:9f07cb34776d0a6e4451242166a25684:b76e191474be377259ae573286d4ad2f:04581a9a0ec00beb6b02b11e2294e14f$
 *
 */
using System;

namespace TexturePackerMonoGameDefinitions
{
	public class earthSprites
	{
		public static string[] getSprites()
		{
			string placeholder = "finalEarth-";
			string[] sprites = new string[11];
			for (int i = 0; i < 11; i++)
            {
				sprites[i] = placeholder + Convert.ToString(i);
            }
			return sprites;
		}
	}
}