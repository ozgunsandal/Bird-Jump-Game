using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FeatherParticles : MonoBehaviour {
    public SpriteAtlas atlas;
    void Start () {
        ParticleSystemRenderer pr = gameObject.GetComponent<ParticleSystemRenderer> ();
        pr.renderMode = ParticleSystemRenderMode.VerticalBillboard;
        pr.material.color = Settings.kuslar[Settings.selectedBirdIndex].color;
    }

    // Update is called once per frame
    public void showParticle () {
        gameObject.GetComponent<ParticleSystem> ().Play ();
    }
}