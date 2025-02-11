using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerAttackScript : MonoBehaviour
{
    public Canvas UI;

    public GameObject pivot;
    public GameObject projectile;
    public GameObject projectileSpawnTransform0, projectileSpawnTransform1, projectileSpawnTransform2;

    [Header("Auto Attacks")]
    public float nextShot;
    public float fireRate = 1f;

    //Ability 1
    [Header("Ability 1")]
    public Image imgAbility1;
    public Text txtCoolDown1;
    public bool buff = false;
    public float ab1CoolDown = 7f;
    public float ab1Timer = 0f;
    public float buffDuration = 3f;
    public float buffTimer = 0f;

    //Ability 2
    [Header("Ability 2")]
    public Image imgAbility2;
    public Text txtCoolDown2;
    public float ab2CoolDown = 5f;
    public float ab2Timer = 0f;

    //Ability 3
    [Header("Ability 3")]
    public Image imgAbility3;
    public Text txtCoolDown3;
    public float ab3CoolDown = 5f;
    public float ab3Timer = 0f;

    //Ability 2
    [Header("Ability 4")]
    public Image imgAbility4;
    public Text txtCoolDown4;
    public float ab4CoolDown = 60f;
    public float ab4Timer = 0f;

    [Header("Key Bindings")]
    public KeyCode ability1 = KeyCode.Alpha1;
    public KeyCode ability2 = KeyCode.Alpha2;
    public KeyCode ability3 = KeyCode.Alpha3;
    public KeyCode ability4 = KeyCode.Alpha4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //AblilityButtonInputs();
        AutoAttack();
        AbilityInput();
    }

    void AutoAttack()
    {
        if (buff)
        {
            if (Input.GetMouseButton(0) && Time.time > nextShot)
            {
                nextShot = Time.time + fireRate * 0.5f;
                Instantiate(projectile, projectileSpawnTransform0.transform.position, pivot.transform.rotation);
                Instantiate(projectile, projectileSpawnTransform1.transform.position, pivot.transform.rotation);
                Instantiate(projectile, projectileSpawnTransform2.transform.position, pivot.transform.rotation);

            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time > nextShot)
            {
                nextShot = Time.time + fireRate;
                Instantiate(projectile, projectileSpawnTransform1.transform.position, pivot.transform.rotation);
            }

        }
    }

    void AbilityInput()
    {
        #region Ability 1
        ab1Timer -= Time.deltaTime;
        buffTimer -= Time.deltaTime;
        txtCoolDown1.text = ab1Timer.ToString("0");
        if (buffTimer <= 0)
        {
            buff = false;
        }

        if (ab1Timer <= 0)
        {
            imgAbility1.color = Color.green;
            txtCoolDown1.enabled = false;
            if (Input.GetKeyDown(ability1))
            {
                Ability1();

            }
        }

        else
        {
            imgAbility1.color = Color.grey;
            txtCoolDown1.enabled = true;
        }
        #endregion

        #region Ability 2

        ab2Timer -= Time.deltaTime;
        txtCoolDown2.text = ab2Timer.ToString("0");
        if (ab2Timer <= 0)
        {
            imgAbility2.color = Color.green;
            txtCoolDown2.enabled = false;
            if (Input.GetKeyDown(ability2))
            {
                Ability2();
            }
        }

        else
        {
            imgAbility2.color = Color.grey;
            txtCoolDown2.enabled = true;
        }
        #endregion

        #region Ability 3

        ab3Timer -= Time.deltaTime;
        txtCoolDown3.text = ab3Timer.ToString("0");
        if (ab3Timer <= 0)
        {
            imgAbility3.color = Color.green;
            txtCoolDown3.enabled = false;
            if (Input.GetKeyDown(ability3))
            {
                Ability3();
            }
        }

        else
        {
            imgAbility3.color = Color.grey;
            txtCoolDown3.enabled = true;
        }
        #endregion

        #region Ability 4

        ab4Timer -= Time.deltaTime;
        txtCoolDown4.text = ab4Timer.ToString("0");
        if (ab4Timer <= 0)
        {
            imgAbility4.color = Color.green;
            txtCoolDown4.enabled = false;
            if (Input.GetKeyDown(ability4))
            {
                Ability4();
            }
        }

        else
        {
            imgAbility4.color = Color.grey;
            txtCoolDown4.enabled = true;
        }
        #endregion
    }

    void Ability1()
    {

        buff = true;

        ab1Timer = ab1CoolDown;
        buffTimer = buffDuration;


    }

    void Ability2()
    {
        Debug.Log("Ability 2");
        ab2Timer = ab2CoolDown;
    }

    void Ability3()
    {
        Debug.Log("Ability 3");
        ab3Timer = ab3CoolDown;
    }

    void Ability4()
    {
        Debug.Log("Ability 4");
        ab4Timer = ab4CoolDown;
    }

    //void AblilityButtonInputs()
    //{
    //    if (Input.GetKeyDown(ability1))
    //    {
    //        btn1.onClick.Invoke();
    //        Debug.Log("ability1");
    //        btn1.image.color = btn1.colors.pressedColor;
    //    }

    //    if (Input.GetKeyUp(ability1))
    //    {
    //        btn1.image.color = btn1.colors.normalColor;
    //    }


    //    if (Input.GetKeyDown(ability2))
    //    {
    //        btn2.onClick.Invoke();
    //        Debug.Log("ability2");
    //        btn2.image.color = btn2.colors.pressedColor;
    //    }

    //    if (Input.GetKeyUp(ability2))
    //    {
    //        btn2.image.color = btn2.colors.normalColor;
    //    }

    //    if (Input.GetKeyDown(ability3))
    //    {
    //        btn3.onClick.Invoke();
    //        Debug.Log("ability3");
    //        btn3.image.color = btn3.colors.pressedColor;
    //    }

    //    if (Input.GetKeyUp(ability3))
    //    {
    //        btn3.image.color = btn3.colors.normalColor;
    //    }

    //    if (Input.GetKeyDown(ability4))
    //    {
    //        btn4.onClick.Invoke();
    //        Debug.Log("ability4");
    //        btn4.image.color = btn4.colors.pressedColor;
    //    }

    //    if (Input.GetKeyUp(ability4))
    //    {
    //        btn4.image.color = btn4.colors.normalColor;
    //    }
    //}
}