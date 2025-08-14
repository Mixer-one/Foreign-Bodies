using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    public List<AttackSO> Combo;

    private float lastClickedTime;
    private float lastComboEnd;
    private int comboCounter;
    private Animator anim;
    [SerializeField] private WeaponScript weaponScript;

// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            Debug.Log("fwoooooss");
        }
    }

    void Attack()
    {
        if(Time.time - lastComboEnd > 0.2f && comboCounter <= Combo.Count)
        {
            CancelInvoke("EndCombo");
            if (Time.time - lastClickedTime >= 0.2f)
            {
                anim.runtimeAnimatorController = Combo[comboCounter].AnimatOV;
                anim.Play("Attack",0,0);
                weaponScript.damage = Combo[comboCounter].damage;
                comboCounter++;
                lastClickedTime = Time.time;
                if (comboCounter >= Combo.Count)
                {
                    comboCounter = 0;
                }
            }
        }
    }

    void ExitAttack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
         Invoke("EndCombo",1);   
        }
    }

    void EndCombo()
    {
        comboCounter = 0;
        lastComboEnd = Time.time;
    }
}
