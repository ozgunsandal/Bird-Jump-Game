using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Platform : MonoBehaviour
{
    private SpriteRenderer sp;
    public SpriteAtlas atlas;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = atlas.GetSprite(Settings.kuslar[Settings.selectedBirdIndex].platformName);
    }
}
