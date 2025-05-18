using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject target;

    public void Deactivate()
    {
        if (target != null)
        {
            target.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
