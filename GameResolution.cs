using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResolution : MonoBehaviour
{
    public GameObject rampa;
    public GameObject spike1;
    public GameObject spike2;
    public float height = 0;
    public float width = 0;

    //public GameObject testObject;

    public static GameResolution instance;
    void Awake()
    {
        if(instance == null)
        instance = this;
        float sr = (float)Screen.width / (float)Screen.height;
        float tr = rampa.GetComponent<SpriteRenderer>().bounds.size.x / rampa.GetComponent<SpriteRenderer>().bounds.size.y;

        if (sr >= tr)
        {
            Camera.main.orthographicSize = rampa.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        }
        else
        {
            float ds = tr / sr;
            Camera.main.orthographicSize = rampa.GetComponent<SpriteRenderer>().bounds.size.y / 2 * ds;
        }

        height = 2f * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        rampa.transform.position = new Vector2(width / 2 - rampa.GetComponent<SpriteRenderer>().bounds.size.x / 2, -height / 2 + 0.5f);
        spike1.transform.position = new Vector2(width / 2 - spike1.GetComponent<SpriteRenderer>().bounds.size.x / 2, height / 2);
        spike2.transform.position = new Vector2(width / 2 - spike2.GetComponent<SpriteRenderer>().bounds.size.x / 2, -height / 2 + spike2.GetComponent<SpriteRenderer>().bounds.size.y / 2);
    
        //testObject.transform.position = new Vector2(0,height/2 - spike2.GetComponent<SpriteRenderer>().bounds.size.y/2-testObject.GetComponent<SpriteRenderer>().bounds.size.y/2-1.4f);
    }

    public float SpikeHeight(string name) {
        if(name == "topSpike")
        {
            return spike1.GetComponent<SpriteRenderer>().bounds.size.y;
        }
        else if(name == "bottomSpike")
        {
            return spike2.GetComponent<SpriteRenderer>().bounds.size.y;
        }
        return 0;
    }
}
