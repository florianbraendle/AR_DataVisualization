using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public List<AR_DataVisualization.BarGraphDataSet> dataSets;
    public UnityEngine.UI.Button buttonPrefab;

    public GameObject mapToSpawn;
    GameObject spawnedMap;
    GameObject panel;
    GameObject navBar;
    GameObject scroll;
    GameObject canvas;
    GameObject detailCard;
    GameObject detailCardSymbol;
    GameObject detailCardData;

    public int barchart_x_offset = 0;
    public int barchart_y_offset = 0;
    public int barchart_z_offset = 0;

    public GameObject generalBarGraphPrefab;
    GameObject generalBarGraphInstance;

    bool graphIsVisible = false;
    bool detailCardIsVisible = false;

    Dictionary<string, UnityEngine.UI.Button> buttons = new Dictionary<string, UnityEngine.UI.Button>();

    Dictionary<AR_DataVisualization.GermanState, GameObject> germanStates = new Dictionary<AR_DataVisualization.GermanState, GameObject>();


    AR_DataVisualization.BarGraphDataSet currentDataset;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SceneManager.Start()");
        initiateGameObjects();
        initiateButtons();
        initiateMap();
    }

    void initiateButtons()
    {
        Debug.Log("instantiateButtons()");
        foreach (AR_DataVisualization.BarGraphDataSet dataSet in dataSets)
        {
            Debug.Log("instatiate Button - " + dataSet.UniqueGroupName);
            Button button = Instantiate(buttonPrefab, panel.transform) as Button;
            // set image
            Debug.Log("set Image - " + dataSet.UniqueGroupName);
            button.GetComponent<Button>().image.sprite = dataSet.image;
            Debug.Log("AddListener - " + dataSet.UniqueGroupName);
            button.onClick.AddListener(() => toggleBarGraph(dataSet));
            Debug.Log("Add to dictionary - " + dataSet.UniqueGroupName);
            buttons.Add(dataSet.UniqueGroupName, button);
        }
    }

    void initiateMap()
    {
        spawnedMap = Instantiate(mapToSpawn, this.transform.position, Quaternion.Euler(this.transform.rotation.eulerAngles + mapToSpawn.transform.rotation.eulerAngles));
        Debug.Log("instantiated map");
        // initiate german states
        foreach (string name in Enum.GetNames(typeof(AR_DataVisualization.GermanState)))
        {
            GameObject transform1 = spawnedMap.transform.Find(name).gameObject;
            germanStates.Add(Enum.Parse<AR_DataVisualization.GermanState>(name), transform1);
        }
    }

    void initiateGameObjects()
    {
        panel = GameObject.FindWithTag("NavPanel");
        navBar = GameObject.FindWithTag("NavBar");
        scroll = GameObject.FindWithTag("NavScroll");
        canvas = GameObject.FindWithTag("Canvas");
        detailCard = canvas.transform.Find("DetailCard").gameObject;
        detailCardSymbol = detailCard.transform.Find("DetailCardSymbol").gameObject;
        detailCardData = detailCard.transform.Find("DetailCardData").gameObject;
    }



    public void whenBtnDataChooserClicked()
    {
        Debug.Log("Button clicked");
    }

    public void toggleBarGraph(AR_DataVisualization.BarGraphDataSet dataSet)
    {
        Debug.Log("toggleBarGraph");
        // no bargraph instantiated
        if (null == generalBarGraphInstance)
        {
            Debug.Log("Instantiate BarGraphPrefab");
            Vector3 pos = spawnedMap.transform.position;
            pos = new Vector3(pos.x + barchart_x_offset, pos.y + barchart_y_offset, pos.z + barchart_z_offset);
            generalBarGraphInstance = Instantiate(generalBarGraphPrefab, pos, this.transform.rotation);
            generalBarGraphInstance.gameObject.SetActive(true);
            GeneralBarGraph gbg = generalBarGraphInstance.GetComponent<GeneralBarGraph>();
            gbg.SetDataSet(dataSet);
        }
        // bargraph instantiated 
        else
        {
            // bargraph is already showing current dataset -> destroy bargraph
            if (null != currentDataset && currentDataset.UniqueGroupName.Equals(dataSet.UniqueGroupName))
            {
                Destroy(generalBarGraphInstance);
                generalBarGraphInstance = null;
            } // bargraph is showing different dataset -> destroy and create new bargraph
            else
            {
                Destroy(generalBarGraphInstance);
                Debug.Log("Instantiate BarGraphPrefab");
                Vector3 pos = spawnedMap.transform.position;
                pos = new Vector3(pos.x + barchart_x_offset, pos.y + barchart_y_offset, pos.z + barchart_z_offset);
                generalBarGraphInstance = Instantiate(generalBarGraphPrefab, pos, this.transform.rotation);
                generalBarGraphInstance.gameObject.SetActive(true);
                GeneralBarGraph gbg = generalBarGraphInstance.GetComponent<GeneralBarGraph>();
                gbg.SetDataSet(dataSet);
            }
        }
        currentDataset = dataSet;
    }

    public void showDetailCard(Sprite sprite, string data)
    {
        Debug.Log("SetDetailCardActive");
        detailCard.SetActive(true);
        Debug.Log("DetailCardSymbol - setSprite");
        detailCardSymbol.GetComponent<Image>().sprite = sprite;
        detailCardSymbol.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(80, 80);
        Debug.Log("DetailCardData - setText: " + data);
        detailCardData.GetComponent<TMPro.TMP_Text>().text = data;
    }

    public void hideDetailCard()
    {
        detailCard.SetActive(false);
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Input.GetMouseButtonDown - states: " + germanStates.Count);
            if (Physics.Raycast(ray, out Hit))
            {
                bool state_hit = false;
                foreach (KeyValuePair<AR_DataVisualization.GermanState, GameObject> state in germanStates)
                {
                    if (Hit.collider.gameObject == state.Value)
                    {
                        Debug.Log("clicked + " + state.Key);
                        state_hit = true;
                        if (null != currentDataset)
                        {
                            AR_DataVisualization.DataPoint dp = currentDataset.listOfDataPoints.Find(i => i.germanState.ToString().Equals(state.Key.ToString()));
                            String data = dp.value.ToString() + " " + currentDataset.UniqueGroupName;
                            Debug.Log("Data: " + data);
                            showDetailCard(currentDataset.image, data);
                        }
                    }
                }
                if (!state_hit)
                {
                    hideDetailCard();
                }
            }
            else
            {
                hideDetailCard();
            }
        }
    }

}
