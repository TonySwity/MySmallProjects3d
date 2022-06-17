using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] private Transform _sphereTransform;

    private void Start()
    {
        _sphereTransform.parent = transform;
        _sphereTransform.localScale = Vector3.one * 2f;
    }

    private void Update()
    {
        // transform.eulerAngles += new Vector3(0, 180f * Time.deltaTime, 0);
        transform.Rotate(Vector3.up * (Time.deltaTime * 180), Space.World);
        transform.Translate(Vector3.forward * (Time.deltaTime * 7f), Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // _sphereTransform.position = Vector3.zero;
            _sphereTransform.localPosition = Vector3.zero;
        }
    }
}
