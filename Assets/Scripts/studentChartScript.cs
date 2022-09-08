using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class studentChartScript : MonoBehaviour
{
    public GameObject coffeeBarchart, beerBarchart, studentBarchart;
    public Image defaultDetailImage;
    public Sprite detailImageStudent;
    public GameObject detailCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenStudentBtnClicked() {
        detailCard.SetActive(false);
        if(studentBarchart.activeInHierarchy == true) {
            studentBarchart.SetActive(false);
        } else {
            studentBarchart.SetActive(true);
            defaultDetailImage.sprite = detailImageStudent;
            defaultDetailImage.rectTransform.sizeDelta = new Vector2(100, 100);
            beerBarchart.SetActive(false);
            coffeeBarchart.SetActive(false);
        }
    }
}
