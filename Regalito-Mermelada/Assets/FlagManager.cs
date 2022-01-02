using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FlagDictionary : SerializableDictionary<string, bool> { }

public class FlagManager : MonoBehaviour
{
    //get público, set privado
    static public FlagManager instance { get; private set; }

    public FlagDictionary flags;

    // Start is called before the first frame update
    void Start()
    { 
        // si es la primera vez que accedemos a la instancia del GameManager,
        // no existira, y la crearemos
        if (instance == null)
        {
            Application.runInBackground = true;
            // guardamos en la instancia el objeto creado
            // debemos guardar el componente ya que _instancia es del tipo GameManager
            instance = this;

            // hacemos que el objeto no se elimine al cambiar de escena
            DontDestroyOnLoad(this.gameObject);

            //instance.flags = new UDictionary<string, bool>();
        }
    }

    // Update is called once per frame
    public static bool GetKey(string key)
    {
        return (instance.flags.ContainsKey(key) && instance.flags[key]);
    }

    // Update is called once per frame
    public static void SetKey(string key, bool value)
    {
        instance.flags[key] = value;
    }
}
