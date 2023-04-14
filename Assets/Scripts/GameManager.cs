using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Librería para acceder a los componentes de la UI
using TMPro; //Libreria para poder acceder a los TextMeshPro

public class GameManager : MonoBehaviour
{
    //Con esto podemos acceder al Texto de TextMeshPro de la UI
    [SerializeField] TextMeshProUGUI textComponent;
    //Reeferencia de tipo State (osea de la clase State), que usamos para poder acceder a las variables y metodos del script State
    State currentState;//Este estado ira acambiando conforme avanza el juego


    //Sera el estado inicial en el que empieza el juego
    [SerializeField] State startingState;

    //Sprites
    [SerializeField] Image boxImage;

    // Start is called before the first frame update
    void Start()
    {
        //El estado actual será el estado inicial del juego
        currentState = startingState;

        //Accedemos al componente text dentro del textComponent(StoryText) y metemos lo que haya dentro del campo storyTet del estado actual
        textComponent.text = currentState.GetStateStory();

        //Sprite
        boxImage.sprite = currentState.NextSprite();
    }

    // Update is called once per frame
    void Update()
    {
        //Llamamos al metodo que gestiona los cambios de estado
        ManageState();
    }
    
    private void ManageState()
    {
        //Variable indefinida en su tipo que se puede agrandar para acoger los datos
        //var nextStates = currentState.GetNextState();
        //Generamos un array de estados, donde guardamos los estados a los que podemos ir desde el estado actual en el que estamos
        State[] statesArray = currentState.GetNextState();

        //Con esto podemos prescindir de los if-else independientemente 
        for(int index = 0; index < statesArray.Length; index++)
        {
            //Alpha + index, cambiara de numero al pulsa cada vez
            if (Input.GetKeyDown(KeyCode.Alpha1 +  index))//With index it sums up the keys, so with alpha01 + index, it will take all numbers
            {
                currentState = statesArray[index];
            }
        }

        //Sprite
        boxImage.sprite = currentState.NextSprite();

        //Accedemos al componente text dentro del textComponent(StoryText) y metemos lo que haya dentro del campo storyText del estado actual
        textComponent.text = currentState.GetStateStory();

        //Si pulsamos la tecla 1 del teclado
        /* if (Input.GetKeyDown(KeyCode.Alpha1))
         {
             //Del estaldo en el que este pasa al siguiente estado que este en la posicion 0 del array
             currentState = statesArray[0];
         }

         if (Input.GetKeyDown(KeyCode.Alpha2))
         {
             //Del estaldo en el que este pasa al siguiente estado que este en la posicion 0 del array
             currentState = statesArray[1];
         }

         if (Input.GetKeyDown(KeyCode.Alpha3))
         {
             //Del estaldo en el que este pasa al siguiente estado que este en la posicion 0 del array
             currentState = statesArray[2];
         }    */
        
    }

}
