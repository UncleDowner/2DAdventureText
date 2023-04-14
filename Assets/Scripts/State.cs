using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Es un atributo de la clase que nos permite crear ScriptableObjects de tipo State desde la ventana de project
[CreateAssetMenu(menuName = "State")]
//Esta clase deriva ahora de los ScriptableObjets
public class State : ScriptableObject
{
    //Genero un campo de texto de tipo string, con un tama�o espec�fico
    //[TextArea(,)] Atributo de la variable que permite crear un cuadro de texto con la cantidad de l�neas escalable
    //[SerializeField] es un atributo de la variable que permite que esta o una referencia siga siendo privada pero accesible desde el editor de Unity
    [TextArea(14, 10)] [SerializeField] string storyText;
    //Array de estados a los que podemos ir desde el estado actual
    [SerializeField] State[] nextStates;

    //Sprite
    [SerializeField] Sprite art;

    //Delete incase of fucking it up
    [SerializeField] AudioSource audio;

    //M�todo que nos devuelve el contenido de la caja de texto del ScriptableObject
    public string GetStateStory()
    {
        return storyText;
    }

    //M�todo que nos devuelve los estados a los que podemos ir desde el estado actual
    public State[] GetNextState()
    {
        return nextStates;
    }   

    public Sprite NextSprite()
    {
        return art;
    }
    
}
