using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Esto debe tener la logica para los objetos de menu que se arrastran y tienen
una mecanica/habilidad asociada a ellas

No estoy 100% seguro que ventajas puede tener usar un scriptable object aqui
*/

public class InventoryItem : ScriptableObject
{
    public string name;
    public string flavor; //descripcion
    public string tipo; //debe coincidir con el slot

    public virtual void Usar()  //debe definir su propia cosa
    {
        //pueden ser el ataque que hace un arma
        //puede ser lo que hace un consumible
        //o lo que hace un hechizo
    }
}
