using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    /// <summary>
    /// Holds Textures beetwen scenes
    /// </summary>
    public static class TexturesHolder
    {
        public static List<Texture> Textures { get; set; }
        public static Texture TextureToCloseLook { get; set; }
    }
}
