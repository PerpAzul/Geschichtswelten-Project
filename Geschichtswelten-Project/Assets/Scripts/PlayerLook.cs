using System.Collections;
using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float _rotation;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    private bool _canUsePowers = true;
    private bool _useGravityFloat;
    private Rigidbody _turnoff;
    


    //GravityPush Power with Collision Detection
    public void GravityPush()
    {
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                GameObject hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Hit");
                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 1500f,
                        ForceMode.Force);

                    //Cooldown
                    StartCoroutine(StartCountdown(5));
                }
            }
            else
            {
                StartCoroutine(StartCountdown(1));
            }
        }
        else
        {
            return;
        }

        Debug.Log("No Hit");
    }

    //GravityFloat 
    public void GravityFloat()
    {
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Float hit!");
                    _turnoff = hitGameObject.GetComponent<Rigidbody>();
                    _turnoff.useGravity = false;
                    _turnoff.AddForce(Vector3.up.normalized * 15f, ForceMode.Force);
                    _turnoff.GetComponent<SphereCollider>().radius = 3.02f;
                    _turnoff.GetComponent<SphereCollider>().enabled = true;
                    _useGravityFloat = true;
                    

                    StartCoroutine(StartCountdown(3));
                }
            }
            else
            {
                StartCoroutine(StartCountdown(1));
            }
        }
        else
        {
            return;
        }

        Debug.Log("No Float Hit");
    }


    //GravityPull with Detection 
    public void GravityPull()
    {
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Hit");
                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    rigidbody.AddForce((transform.position - rigidbody.transform.position).normalized * 1500f,
                        ForceMode.Force);
                    StartCoroutine(StartCountdown(5));
                }
            }
            else
            {
                StartCoroutine(StartCountdown(1));
            }
        }
        else
        {
            return;
        }

        Debug.Log("No Hit");
    }

    private IEnumerator StartCountdown(int time)
    {
        
        _canUsePowers = false;
        yield return new WaitForSeconds(time);
        _canUsePowers = true;
        if (_useGravityFloat)
        {
            _turnoff.useGravity = true;
            _turnoff.AddForce(Vector3.up.normalized * 0f, ForceMode.Force);
            _useGravityFloat = false;
            _turnoff.GetComponent<SphereCollider>().radius = 0.1f;
            
        }
        Debug.Log("End of StartCountdown");
    }

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate camera rotation for looking up and down
        _rotation -= (mouseY * Time.deltaTime) * ySensitivity;
        _rotation = Mathf.Clamp(_rotation, -80f, 80f);

        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(_rotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}