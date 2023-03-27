
using DG.Tweening;
using UnityEngine;

public class ElectricDoor : MonoBehaviour
{
    public GameObject _light;
    public Material _lightmaterial;
    public Vector3 _end;
    public Vector3 _start;
    private bool _ispower;
    private bool _full;
    private float _power=0;
    private float _time = 0;
    
    public void FixedUpdate()
    {
        if (_full)
        {
            return;
        }
        if (_ispower)
        {
            _power += 0.01f;
            _lightmaterial.SetFloat("_Length",_power);
            if (_power >= 1)
            {
                _full = true;
                _light.SetActive(true);
                transform.DOMove(_end, 1);
            }
            else
            {
                _light.SetActive(false);
            }
        }
        else
        {
            _power -= 0.01f;
            if (_power < 0)
            {
                _light.SetActive(false);
                _power = 0;
            }
            _lightmaterial.SetFloat("_Length",_power);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Robot")
        {
            _ispower = true;
        }
    }
        
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Robot")
        {
      
        }
    }
}
