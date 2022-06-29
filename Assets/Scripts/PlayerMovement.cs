using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float limitMovement = 2.65f;
    public float movementSpeed = 1f;
    public float limit = 0f;
    public ParticleSystem dustEffect;
    public ParticleSystem bloodEffect;
    public ParticleSystem snowEffect;
    private bool disable = true;
    // Start is called before the first frame update
    void Start()
    {
        CreateSnowEffect();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if(x != 0){
            limit = Mathf.Clamp(transform.position.x, -limitMovement, limitMovement);
            transform.position = new Vector2(limit + ((x * movementSpeed) * Time.deltaTime), transform.position.y);
            CreateDustEffect();
        }
    }

    void CreateDustEffect()
    {
        dustEffect.Play();    
    }

    void CreateBloodEffect()
    {
        bloodEffect.Play();
    }

    void CreateSnowEffect()
    {
        snowEffect.Play();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Spikes"){
            CreateBloodEffect();
            Destroy(collision.gameObject);

            if(disable) 
            {
                 transform.position = new Vector2(0,-3);
            }
          

            GameManager.instance.GameOver();
        }
    }

}
