
using UnityEngine;

public class Test02Raycast : MonoBehaviour
{
    [SerializeField] private Transform _objectToPlace;
    [SerializeField] private Camera _gameCamera;

    private void Update()
    {
        Ray ray = _gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            
            _objectToPlace.position = hitInfo.point + new Vector3(0,0.5f, 0);
            _objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        }
    }
}