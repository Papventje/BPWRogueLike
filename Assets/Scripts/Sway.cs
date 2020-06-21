using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sway : MonoBehaviour
{
    public float swayAmount;
    public float maxSway;
    public float smooth;

    public float recoilValue;
    public float recoilRotationValue;

    Vector3 pos;
    float value = 0;
    bool shot = false;

    private void Start()
    {
        pos = transform.localPosition;
    }

    private void Update()
    {
        if(shot)
            value = Mathf.Lerp(value, -0.2f, 2f);

        float factorX = -Input.GetAxis("Mouse X") * swayAmount;
        float factorY = -Input.GetAxis("Mouse Y") * swayAmount;

        factorX = Mathf.Clamp(factorX, -maxSway, maxSway);
        factorY = Mathf.Clamp(factorY, -maxSway, maxSway);

        Vector3 finalPosition = new Vector3(factorX, factorY, value);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + pos, Time.deltaTime * smooth);
    }

    private IEnumerator RecoilPosition(float recoilValue)
    {
        value = -recoilValue; 

        yield return new WaitForSeconds(.2f);

        value = 0;
    }

    public void StartRecoil(float recoilValue)
    {
        StartCoroutine(RecoilPosition(recoilValue));
    }
}
