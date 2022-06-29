using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public float slowestSpeed = 1, fastestSpeed = 3;
    private GameObject spikeParticle;
    public float randomSpeed;
   
    private void Start() {
        spikeParticle = GameObject.Find("SpikeParticle");
        randomSpeed = Random.Range(slowestSpeed, fastestSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - randomSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            GameObject particle = Instantiate(spikeParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            Destroy(particle, 1f);
            GameManager.instance.IncrementScore();
        }
    }

 
}
