using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private SpriteAtlas atlas;
    [SerializeField]
    private GameObject rateButton;

    [SerializeField]
    private GameObject storeButton;
    void Start()
    {
        rateButton.GetComponent<Image>().sprite = atlas.GetSprite("buton_"+Settings.kuslar[Settings.selectedBirdIndex].buttonName+"_rate");
        storeButton.GetComponent<Image>().sprite = atlas.GetSprite("buton_"+Settings.kuslar[Settings.selectedBirdIndex].buttonName+"_store");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
