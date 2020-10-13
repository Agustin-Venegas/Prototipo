using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadSpawner : HabilidadEspecial
{
    public GameObject prefab;

    bool uses_cooldown = false;
    float timer = 0f;
    float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        HabilidadConCooldown h = prefab.GetComponent<HabilidadConCooldown>() as HabilidadConCooldown;

        if (h != null)
        {
            uses_cooldown = true;
            cooldown = h.GetCooldown();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (uses_cooldown) hud_text.text = "loading " + (1f - timer / cooldown) * 100f;
        }
        else
        {
            if (uses_cooldown) hud_text.text = "ready";
        }
    }

    public override void Activate()
    {
        base.Activate();

        if (uses_cooldown)
        {
            if (timer <= 0)
            {
                Instantiate(prefab, transform.position + transform.up, transform.rotation);
                timer = cooldown;
            }
        }
        else
        {
            Instantiate(prefab, transform.position + transform.up, transform.rotation);
        }
    }
}
