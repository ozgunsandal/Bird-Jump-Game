using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {
    [SerializeField]
    private Button btn;

    [SerializeField]

    private List<Button> btns;
    void Start () {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
            Camera.main.pixelWidth,Camera.main.WorldToScreenPoint(new Vector3(GameResolution.instance.height,0,0)).y);
        btns = new List<Button>();

        var i = 0;
        var len = Settings.kuslar.Count;
        while (i < len) {
            Button b = Instantiate (btn);
            //b.GetComponent<RectTransform>().sizeDelta = new Vector2(300,150);
            /*b.transform.position =new Vector2 ((i % 2) * (btn.GetComponent<RectTransform> ().rect.width + 2),
            -(i / 2) * (btn.GetComponent<RectTransform> ().rect.height + 2));*/
             //Button b = Instantiate (btn);
            btns.Add(b);
            b.transform.SetParent (transform);
            i++;
        }

        float w = transform.GetComponent<RectTransform>().rect.width;
        float h = transform.GetComponent<RectTransform>().rect.height;
        Vector2 cellSize = new Vector2(w/3,h/10);
        transform.GetComponent<GridLayoutGroup>().cellSize = cellSize;
        transform.GetComponent<GridLayoutGroup>().spacing = new Vector2(2,3);

        Debug.Log("dsfsdfdsf " +Camera.main.pixelWidth);

        /*var pos = Vector3.zero;
        foreach (var item in btns)
        {
            pos += item.transform.position;
            //item.transform.SetParent(null);
        }

        pos /= btns.Count;
        transform.position = pos;
        foreach (var item2 in btns)
        {
            item2.transform.SetParent(transform);
        }*/


       // transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        //gameObject.GetComponent<RectTransform> ().sizeDelta =new Vector2(GameResolution.instance.width,0);
        //print(transform.GetComponent<RectTransform>().rect.height);
    }

    /*public static void CenterOnChildred (this Transform aParent) {
        var childs = aParent.Cast<Transform> ().ToList ();
        var pos = Vector3.zero;
        foreach (var C in childs) {
            pos += C.position;
            C.parent = null;
        }
        pos /= childs.Count;
        aParent.position = pos;
        foreach (var C in childs)
            C.parent = aParent;
    }*/

    // Update is called once per frame
    void Update () {

    }
}