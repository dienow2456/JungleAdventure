using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    [Serializable]
    public class TileInfo
    {
        [Tooltip("Pixel color on image to look for")]
        public Color pixelColor;
        [Tooltip("Tile to render when pixel color is found")]
        public GameObject tilePrefab;
    }

