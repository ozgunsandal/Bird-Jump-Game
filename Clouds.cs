using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    private float height;
    private float width;
    public GameObject cloud1;
    public GameObject cloud2;
    private List<GameObject> topC;
    public GameObject topCloud;
    private float cloud1Speed = 0.5f;
    void Start()
    {
        topC = new List<GameObject>();

        height = 2f * Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        cloud1.transform.position = new Vector2(cloud1.GetComponent<SpriteRenderer>().bounds.size.x/2 - width/2, -height / 2 + cloud1.GetComponent<SpriteRenderer>().bounds.size.y/2);
        cloud2.transform.position = new Vector2(cloud2.GetComponent<SpriteRenderer>().bounds.size.x / 2 + - width / 2 + cloud1.GetComponent<SpriteRenderer>().bounds.size.x, -height / 2+cloud2.GetComponent<SpriteRenderer>().bounds.size.y/2);


        for (int i = 0; i < Settings.totalTopCloud; i++)
        {
           topC.Add(Instantiate(topCloud, new Vector2(Random.Range(-width, width), Random.Range(1f, height / 2 - 1)), Quaternion.identity) as GameObject);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Settings.totalTopCloud; i++)
        {
            topC[i].transform.Translate(new Vector2(-Settings.cloudSpeeds[i] * Time.deltaTime, 0));
            if (topC[i].transform.position.x <= -width / 2 - topC[i].GetComponent<SpriteRenderer>().bounds.size.x / 2)
            {
                topC[i].transform.position = new Vector2(width/2 + topC[i].GetComponent<SpriteRenderer>().bounds.size.x/2 , topC[i].transform.position.y);
                //Time.timeScale = 0;
            }
        }

        if(cloud2 == null)  {
            return;
        }


        cloud1.transform.Translate(new Vector2(-cloud1Speed * Time.deltaTime,0));
        cloud2.transform.Translate(new Vector2(-cloud1Speed * Time.deltaTime, 0));


        if(cloud1.transform.position.x <= -width/2 - cloud1.GetComponent<SpriteRenderer>().bounds.size.x / 2)
        {
            cloud1.transform.position = new Vector2(cloud2.transform.position.x+cloud2.GetComponent<SpriteRenderer>().bounds.size.x,cloud1.transform.position.y);
        }

        if (cloud2.transform.position.x <= -width / 2 - cloud2.GetComponent<SpriteRenderer>().bounds.size.x / 2)
        {
            cloud2.transform.position = new Vector2(cloud1.transform.position.x + cloud1.GetComponent<SpriteRenderer>().bounds.size.x, cloud2.transform.position.y);
        }
    }
    public void yoket() {
        Destroy(cloud2);
        Destroy(cloud1);
    }
}
