using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using Com.LuisPedroFonseca.ProCamera2D;

public class Bird : MonoBehaviour {
    public SpriteAtlas atlas;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private string birdName;
    private float scaleSpeedX = 1f;
    private float scaleSpeedY = 1f;
    private float speed = 0f;
    private float kaySpeed = .5f;
    private bool kayDurum = false;

    public GameObject platform;
    private GameObject firstPlatform;
    private GameObject lastPlatform;

    private float xpos = 0;
    private float firstYPos = 0;
    private bool firstJump = true;

    private GameObject rampa;
    private GameObject bulut;

    private List<GameObject> platforms;
    private int score = 0;

    private bool runWings = false;
    private int wingCount = 1;

    private GameObject featherParticles;
    private bool gameOver = false;

    private bool platformMove = false;
    private float platformMoveAci = 0f;

    void Start () {
        featherParticles = GameObject.FindGameObjectWithTag("featherParticles");
        platforms = new List<GameObject> ();
        rb = GetComponent<Rigidbody2D> ();
        rb.gravityScale = Settings.kuslar[Settings.selectedBirdIndex].gravity;
        spriteRenderer = GetComponent<SpriteRenderer> ();
        birdName = Settings.kuslar[Settings.selectedBirdIndex].name + "kus_0";
        //Debug.Log(birdName);
        spriteRenderer.sprite = atlas.GetSprite (birdName);
        createPlatform ();

        rampa = GameObject.Find ("Rampa");
        bulut = GameObject.Find ("Bulut");
    }

    private bool IsPointerOverUIObject () {
        PointerEventData eventDataCurrentPosition = new PointerEventData (EventSystem.current);
        eventDataCurrentPosition.position = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult> ();
        EventSystem.current.RaycastAll (eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0) && !IsPointerOverUIObject () && !gameOver) {
            FindObjectOfType<AudioManager> ().Play ("BirdPressSound");
        }
        if (Input.GetMouseButton (0) && !gameOver) {
            if (!IsPointerOverUIObject ()) {
                if (transform.localScale.y > 0.2) {
                    scaleSpeedY -= 0.01f;
                    scaleSpeedX += 0.008f;
                    speed += 0.5f;
                    transform.localScale = new Vector3 (scaleSpeedX, scaleSpeedY, 1);
                }
            }

        }
        if (Input.GetMouseButtonUp (0) && !IsPointerOverUIObject () && !gameOver) {
            Vector2 velocity = rb.velocity;
            velocity.y = speed;
            rb.velocity = velocity;
            speed = 0f;
            scaleSpeedY = 1f;
            scaleSpeedX = 1f;
            transform.localScale = new Vector3 (1, 1, 1);
            kayDurum = false;

            runWings = true;

            FindObjectOfType<AudioManager> ().Play ("JumpSound");
            FindObjectOfType<AudioManager> ().Stop ("BirdPressSound");

            featherParticles.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
            featherParticles.GetComponent<FeatherParticles>().showParticle();

            if (firstJump) {
                try {
                    GameObject.FindGameObjectWithTag ("title").SetActive (false);
                } catch (Exception e) {
                    Debug.Log(e);
                }
            }

            if (!firstJump) {
                transform.parent = null;
                lastPlatform = platforms[0];
                lastPlatform.transform.DOMoveY (-GameResolution.instance.height / 2 - 1, 0.5f).OnComplete (removePlatform);

            }
            
            /*Time.timeScale = 0.05f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;*/
        }
        if(platformMove)
            {
                platformMoveAci += 0.02f;
                firstPlatform.transform.position =new Vector2(Mathf.Sin(platformMoveAci) * GameResolution.instance.width/2,firstPlatform.transform.position.y);
            }
        if (kayDurum) {
            transform.parent.transform.Translate (new Vector2 (xpos, -kaySpeed * Time.deltaTime));
        }
        if (runWings) {
            if (wingCount >= 8) wingCount = 0;
            birdName = Settings.kuslar[Settings.selectedBirdIndex].name + "kus_" + wingCount;
            spriteRenderer.sprite = atlas.GetSprite (birdName);
            wingCount++;
        }
        if (rb.velocity.y <= 0 && runWings) {
            runWings = false;
            birdName = Settings.kuslar[Settings.selectedBirdIndex].name + "kus_" + 7;
            spriteRenderer.sprite = atlas.GetSprite (birdName);
        }
    }
    private void removePlatform () {
        Destroy (lastPlatform.gameObject);
        lastPlatform = null;
        platforms.RemoveAt (0);
    }
    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Platform") {
            firstYPos = UnityEngine.Random.Range (-GameResolution.instance.height / 2 + GameResolution.instance.SpikeHeight ("bottomSpike") + other.gameObject.GetComponent<SpriteRenderer> ().bounds.size.y / 2 + 0.8f, -1.2f);
            if (rb.velocity.y <= 0) {
                other.gameObject.transform.DOMove (new Vector2 (xpos, firstYPos), 1).OnComplete (kay);
                transform.DOScaleY(0.7f,0.2f).SetLoops(2,LoopType.Yoyo).SetEase(Ease.Flash);
                transform.SetParent (other.gameObject.transform);

                FindObjectOfType<AudioManager> ().Play ("ScoreSound");

                firstYPos = UnityEngine.Random.Range (0f, GameResolution.instance.height / 2 - GameResolution.instance.SpikeHeight ("topSpike") / 2 - other.gameObject.GetComponent<SpriteRenderer> ().bounds.size.y / 2 - 1.4f);
                score++;
                writeScore ();
                createPlatform ();

                if (firstJump)
                    rampaDestroy ();

                runWings = false;

                birdName = Settings.kuslar[Settings.selectedBirdIndex].name + "kus_" + 0;
                spriteRenderer.sprite = atlas.GetSprite (birdName);
            }
        }
        if (other.gameObject.tag == "rampa") {
            runWings = false;

            birdName = Settings.kuslar[Settings.selectedBirdIndex].name + "kus_" + 0;
            spriteRenderer.sprite = atlas.GetSprite (birdName);
        }
        
    }
    void writeScore () {
        GameObject.Find ("GameManager").GetComponent<Score> ().setScore (score);
    }
    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "topSpike" || other.tag == "bottomSpike") {
            FindObjectOfType<AudioManager> ().Play (Settings.kuslar[Settings.selectedBirdIndex].deathSound);
            stopGame ();
        }
    }
    void stopGame () {
        ProCamera2DShake.Instance.Shake("PlayerHit");
        //ProCamera2DPanAndZoom.Instantiate(gameObject);
        Vector2 velocity = rb.velocity;
        velocity.y = speed;
        rb.velocity = velocity;
        rb.gravityScale = 0f;
        speed = 0f;
        birdName = Settings.kuslar[Settings.selectedBirdIndex].name + "dead";
        spriteRenderer.sprite = atlas.GetSprite (birdName);
        runWings = false;
        kayDurum = false;
        gameOver = true;

        Invoke("StartGameAgain",3);
    }
    void StartGameAgain() {
        GameManager.loadGame();
    }
    void platformSil () {
        Destroy (lastPlatform.gameObject);

    }
    void kay () {
        kayDurum = true;
    }
    void rampaDestroy () {
        firstJump = false;
        bulut.transform.DOMoveY (-3f, 1).OnComplete (() => bulut.GetComponent<Clouds> ().yoket ());
        rampa.transform.DOMoveY (-(GameResolution.instance.height / 2 + rampa.GetComponent<SpriteRenderer> ().bounds.size.y / 2), 1).OnComplete (() => Destroy (rampa));

        // rampaDurum = true;
    }
    void createPlatform () {
        firstPlatform = Instantiate (platform, new Vector2 (xpos, firstYPos), Quaternion.identity) as GameObject;
        firstPlatform.transform.DOMoveY (GameResolution.instance.height, 1).From ();
        platformMove = firstJump ? false :  UnityEngine.Random.Range(0f,1f) > 0.5f;
        platforms.Add (firstPlatform);
    }
}