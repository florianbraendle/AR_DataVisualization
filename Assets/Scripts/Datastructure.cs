

using System;
using System.Collections.Generic;

namespace AR_DataVisualization
{

    [Serializable]
    public class BarGraphDataSet
    {
        public string UniqueGroupName = "groupname";
        public UnityEngine.Color barColor;
        public UnityEngine.Material barMaterial;
        public List<DataPoint> listOfDataPoints;

        public UnityEngine.Sprite image;
    }

    [Serializable]
    public class DataPoint
    {
        public float value;
        public GermanState germanState;
    }

    [Serializable]
    public enum GermanState
    {
        BW,
        BY,
        BE,
        BB,
        HB,
        HH,
        HE,
        MV,
        NI,
        NW,
        RP,
        SL,
        SN,
        ST,
        SH,
        TH
    }
}