using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beerChartScript : MonoBehaviour
{
    public GameObject coffeeBarchart, beerBarchart, studentBarchart;
    public Image defaultDetailImage;
    public Sprite detailImageBeer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenBeerBtnClicked() {
        if(beerBarchart.activeInHierarchy == true) {
            beerBarchart.SetActive(false);
        } else {
            beerBarchart.SetActive(true);
            defaultDetailImage.sprite = detailImageBeer;
            defaultDetailImage.rectTransform.sizeDelta = new Vector2(80, 80);
            coffeeBarchart.SetActive(false);
            studentBarchart.SetActive(false);
        }
    }
}
