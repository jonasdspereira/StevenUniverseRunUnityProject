using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	public Animator		Anime;
	public Rigidbody2D	playerRigidBody;
	public int			forceJump;

	public bool			slide;

	//VERIFICA O CHÃO 
	public Transform GroundCheck;
	public bool grounded;
	public LayerMask whatIsGround;

	//Slide
	public float slideTemp;
	public float timeTemp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

	//SE O BOTAO DE PULO FOR APERTADO E TIVER PISANDO NO CHÃO, ENTÃO FAÇA ISSO

	if(Input.GetButtonDown("Jump") && grounded == true) {
		playerRigidBody.AddForce(new Vector2(0, forceJump));
		slide = false;
	}

	if(Input.GetButtonDown("Slide") && grounded == true){
		slide = true;
		timeTemp = 0;
	}

	grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.5f, whatIsGround);

	if(slide == true) {
		timeTemp += Time.deltaTime;
		if (timeTemp >= slideTemp){
				slide = false;
			}
	}

	Anime.SetBool("jump", !grounded);
	Anime.SetBool("slide",slide);
    }
}
