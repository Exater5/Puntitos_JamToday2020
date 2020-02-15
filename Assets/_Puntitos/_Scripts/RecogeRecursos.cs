using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogeRecursos : MonoBehaviour
{
    GameController gc;
    public GameObject prefabRecurso;
    public List<GameObject> recursos;
    float offset = 50;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        for(int i = 0; i <= gc.bolitasRestantes; i++)
        {
            GameObject nuevoRecurso = Instantiate(prefabRecurso, transform.position + new Vector3(offset * i,0,0), Quaternion.identity);
            nuevoRecurso.transform.SetParent(transform);
            recursos.Add(nuevoRecurso);
        }
    }
    public void RecogeRecurso()
    {
        Destroy(recursos[recursos.Count-1]);
        recursos.RemoveAt(recursos.Count - 1);
    }
    public void Recalcula()
    {
        for(int i = 0; i <= recursos.Count-1; i++)
        {
            Destroy(recursos[i]);
        }
        recursos.Clear();
        for (int i = 0; i <= gc.bolitasRestantes; i++)
        {
            GameObject nuevoRecurso = Instantiate(prefabRecurso, transform.position + new Vector3(offset * i, 0, 0), Quaternion.identity);
            nuevoRecurso.transform.SetParent(transform);
            recursos.Add(nuevoRecurso);
        }
    }
}
