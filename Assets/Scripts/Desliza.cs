using UnityEngine;
using UnityEngine.UIElements;

public class Desliza : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        Vector3 pos = new Vector3 (speed * Time.deltaTime, 0, 0);
        transform.position += pos;
    }
    public void SetVelX (float valor) {  speed = valor; }
}
