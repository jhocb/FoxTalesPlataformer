using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaSystem : MonoBehaviour
{
    // Stamina variables
    public float stamina = 100f; // Maximum stamina
    public float dodgeStamina = 10f; // Stamina cost of dodging
    public float fightStamina = 20f; // Stamina cost of fighting
    public float runStamina = 5f; // Stamina cost of running
    public float regenerateTime = 5f; // Time before stamina begins to regenerate
    public float regenerateSpeed = 2f; // Speed at which stamina regenerates
    public float elapsedTime; // Time elapsed since last stamina change

    Animator animator; // this is the animator component of the enemy 

    private float time;

    public Image staminaBar; // Stamina bar image

    void Start()
    {
        animator = GetComponent<Animator>(); // get the Animator component of the enemy 
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        elapsedTime += Time.deltaTime; // Increase elapsed time

        // Decrease stamina when the fight key is pressed
        if (Input.GetKeyDown(KeyCode.X) && stamina >= fightStamina)
        {
            stamina -= fightStamina; // Decrease stamina
            elapsedTime = 0f; // Reset elapsed time
        }

        // Decrease stamina gradually while running
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 0)
        {
            stamina -= runStamina * Time.deltaTime;
            elapsedTime = 0f;
        }

        // Decrease stamina when the dodge key is pressed
        if (Input.GetKey(KeyCode.LeftControl) && stamina >= dodgeStamina)
        {
            stamina -= dodgeStamina;
            elapsedTime = 0f;
            //animator.SetBool("roll", true);
            time = 0;
        }

        // Regenerate stamina if enough time has passed and stamina is not at maximum
        if (elapsedTime > regenerateTime && stamina < 100f)
        {
            stamina += regenerateSpeed * Time.deltaTime; // Increase stamina
        }

        if (time > 0.5f)
        {
            //animator.SetBool("roll", false);
        }

        // Ensure stamina does not exceed maximum value
        stamina = Mathf.Clamp(stamina, 0f, 100f);

        staminaBar.fillAmount = stamina / 100f; // Set the fill amount of the stamina bar to the current stamina
    }
}
