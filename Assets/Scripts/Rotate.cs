using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotaionSpeed = new Vector3(0f,0f,0f);
    private void Update()
    {
        transform.Rotate(rotaionSpeed * Time.deltaTime);
    }
}
