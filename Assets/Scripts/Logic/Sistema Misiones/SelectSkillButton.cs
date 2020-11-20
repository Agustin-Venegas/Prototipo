using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkillButton : MonoBehaviour
{

    public int SelectedSkill;
    public SelectSkill Manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        Manager.Spawn(SelectedSkill);
    }
}
