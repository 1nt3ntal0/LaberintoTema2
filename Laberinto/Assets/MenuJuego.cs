using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public int siguienteEscenaIndex = 1; 

    private bool isJugarSelected = true; 

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isJugarSelected = !isJugarSelected;
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (isJugarSelected)
            {
                Jugar();
            }

            else
            {
                Salir();
            }
        }
    }

    public void Jugar()
    {

        SceneManager.LoadScene(siguienteEscenaIndex);
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
