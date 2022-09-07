using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coffeeChartScript : MonoBehaviour
{

    public GameObject coffeeBarchart, beerBarchart, studentBarchart;
    public Image defaultDetailImage;
    public Sprite detailImageCoffee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenCoffeeBtnClicked() {
        if(coffeeBarchart.activeInHierarchy == true) {
            coffeeBarchart.SetActive(false);
        } else {
            coffeeBarchart.SetActive(true);
            defaultDetailImage.sprite = detailImageCoffee;
            defaultDetailImage.rectTransform.sizeDelta = new Vector2(120, 70);
            beerBarchart.SetActive(false);
            studentBarchart.SetActive(false);
        }
    }
}
