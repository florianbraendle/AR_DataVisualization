using System.Collections;
using System.Collections.Generic;
using BarGraph.VittorCloud;
using UnityEngine;

public class GeneralBarGraph : MonoBehaviour
{
    BarGraphGenerator barGraphGenerator;
    List<BarGraphDataSet> dataSet;

    // Start is called before the first frame update
    void Start()
    {
        barGraphGenerator = GetComponent<BarGraphGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDataSet(List<BarGraphDataSet> bgds)
    {
        this.dataSet = bgds;
        barGraphGenerator.GeneratBarGraph(this.dataSet);
    }

    public void SetDataSet(AR_DataVisualization.BarGraphDataSet dataSet)
    {
        BarGraphDataSet bGDataSet = new BarGraphDataSet();
        bGDataSet.barColor = dataSet.barColor;
        bGDataSet.barMaterial = dataSet.barMaterial;
        bGDataSet.GroupName = dataSet.UniqueGroupName;
        Debug.Log("BarGraph - transform data structure");
        List<XYBarValues> listOfBars = new List<XYBarValues>();
        foreach (AR_DataVisualization.DataPoint dp in dataSet.listOfDataPoints)
        {
            XYBarValues xybv = new XYBarValues();
            xybv.XValue = dp.germanState.ToString();
            xybv.YValue = dp.value;
            listOfBars.Add(xybv);
        }
        bGDataSet.ListOfBars = listOfBars;
        List<BarGraphDataSet> barGraphDataSets = new List<BarGraphDataSet>();
        barGraphDataSets.Add(bGDataSet);
        Debug.Log("GenerateBarGraph");
        if (null == barGraphGenerator)
        {
            Debug.Log("barGraphGenerator is null");
            barGraphGenerator = GetComponent<BarGraphGenerator>();
            Debug.Log("Got BarGraphGenerator: " + !(null == barGraphGenerator));
        }
        if (null == barGraphGenerator)
        {
            Debug.Log("barGraphGenerator is still null");
            barGraphGenerator = this.transform.parent.GetComponent<BarGraphGenerator>();
            Debug.Log("barGraphGenerator is null: " + (null == barGraphGenerator));
        }
        barGraphGenerator.gameObject.transform.localScale.Set(0.001f, 0.001f, 0.001f);
        barGraphGenerator.GeneratBarGraph(barGraphDataSets);
    }
}
