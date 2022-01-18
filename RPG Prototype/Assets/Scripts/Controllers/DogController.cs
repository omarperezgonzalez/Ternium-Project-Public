using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DogController : MonoBehaviour
{
    public static float velx; // Velocidad en el eje x (rotacion)
    public static float velz; // Velocidad en el eje z ()
    public float velzAux; // Velocidad freno
    public float velzLim; // Velocidad Limite
    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 100;
    public int currentMana = 100;

    public healthScript healthBar;
    public manaScript manaBar;

    public float Health = 100f ;
    public float Mana = 100f;
    Animator anim;
    public Flowchart fc;
    public Flowchart fc2;
    public Flowchart fc3;
    Rigidbody selfRB;

    bool isUsingAttack=false;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        selfRB=GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
                //      Scripts de Movimento     //
        var x= Input.GetAxis("Horizontal")*Time.deltaTime*velx;
        var z= Input.GetAxis("Vertical")*Time.deltaTime*velz;

        transform.Rotate(0,x,0);
        transform.Translate(0,0,z);

        anim.SetFloat("Speed",z);

        if(x!=0 || z!=0){
            anim.SetBool("isWalking",true);
            if(Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("isRunning",true);
                velz=velzLim;
            
            
            } else{
                anim.SetBool("isRunning",false);
                velz= velzAux;
            }
        } else{
            anim.SetBool("isWalking",false);
        }

        if(Input.GetButton("Fire1") && isUsingAttack==false && !fc.GetBooleanVariable("noAttack")){
            anim.SetBool("isAtacking",true);
            isUsingAttack=true;
        } else if (Input.GetButton("Fire1") && isUsingAttack==true){
            anim.SetBool("isAtacking",false);
            isUsingAttack=false;
        } else if (Input.GetButton("Fire1") && fc.GetBooleanVariable("noAttack")){
            anim.SetBool("isAtacking",false);
            isUsingAttack=false;
        }

        if(Input.GetButton("Fire1") && isUsingAttack==false && !fc2.GetBooleanVariable("noAttack")){
            anim.SetBool("isAtacking",true);
            isUsingAttack=true;
        } else if (Input.GetButton("Fire1") && isUsingAttack==true){
            anim.SetBool("isAtacking",false);
            isUsingAttack=false;
        } else if (Input.GetButton("Fire1") && fc2.GetBooleanVariable("noAttack")){
            anim.SetBool("isAtacking",false);
            isUsingAttack=false;
        }

        if(Input.GetButton("Fire1") && isUsingAttack==false && !fc2.GetBooleanVariable("noAttack")){
            anim.SetBool("isAtacking",true);
            isUsingAttack=true;
        } else if (Input.GetButton("Fire1") && isUsingAttack==true){
            anim.SetBool("isAtacking",false);
            isUsingAttack=false;
        } else if (Input.GetButton("Fire1") && fc2.GetBooleanVariable("noAttack")){
            anim.SetBool("isAtacking",false);
            isUsingAttack=false;
        }
        if (Input.GetButton("Fire1") && isUsingAttack == false && !fc3.GetBooleanVariable("noAttack"))
        {
            anim.SetBool("isAtacking", true);
            isUsingAttack = true;
        }
        else if (Input.GetButton("Fire1") && isUsingAttack == true)
        {
            anim.SetBool("isAtacking", false);
            isUsingAttack = false;
        }
        else if (Input.GetButton("Fire1") && fc3.GetBooleanVariable("noAttack"))
        {
            anim.SetBool("isAtacking", false);
            isUsingAttack = false;
        }


        //          Scrips de Barra de Vida     //
        if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(5);
                useMana(10);
            }
        
        void TakeDamage(int damage)
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
            }
        
        void useMana(int manaDrain)
            {
                currentMana -= manaDrain;
                manaBar.SetMana(currentMana);
            }
    }
}
