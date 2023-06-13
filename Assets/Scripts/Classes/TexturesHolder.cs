using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
