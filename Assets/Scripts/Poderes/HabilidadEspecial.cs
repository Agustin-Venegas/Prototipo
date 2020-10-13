using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Las habilidades especiales heredan de esto
 */

public class HabilidadEspecial : MonoBehaviour
{
    public bool activated;
    public Text hud_text;
    public Image hud_sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate()
    {

    }
}
