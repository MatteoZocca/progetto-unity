using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillCheck : MonoBehaviour
{
    public event Action OnSkillCheckFail, OnSkillCkeckGood, OnSkillCheckGreat;

    [Range(1, 50)]
    [SerializeField] private int arrowRotationSpeed = 30;
    [SerializeField] private GameObject arrowRotator, circle, space, pointsUi;

    private float arrowRotation = 0.0f;
    private bool isSkillCheckOn = false;

    public void StartSkillCheck()
    {
        if (!isSkillCheckOn)
        {
            Invoke("SkillCheckStarter", 0.6f);
        }
    }
    void SkillCheckStarter()
    {
        Vector3 currentCircleRotation = circle.transform.rotation.eulerAngles;
        circle.transform.rotation = Quaternion.Euler(currentCircleRotation.x, currentCircleRotation.y, UnityEngine.Random.Range(160, 360));
        SetActiveGameUI(true);
        isSkillCheckOn = true;
    }
    void DoSkillCheck()
    {
        // Rotate the arrow and store current rotation angle
        arrowRotation += Time.deltaTime * arrowRotationSpeed * -10;
        arrowRotator.transform.Rotate(0, 0, Time.deltaTime * arrowRotationSpeed * -10, Space.World);

        if (Input.GetKeyDown("space"))
        {
            // Arrow in good skill check zone
            if (arrowRotator.transform.rotation.eulerAngles.z >= circle.transform.rotation.eulerAngles.z - 158
                && arrowRotator.transform.rotation.eulerAngles.z < circle.transform.rotation.eulerAngles.z - 120)
            {
                ActivatePointsUI("GoodSC");
            }
            // Arrow in great skill check zone
            else if (arrowRotator.transform.rotation.eulerAngles.z >= circle.transform.rotation.eulerAngles.z - 120
                && arrowRotator.transform.rotation.eulerAngles.z <= circle.transform.rotation.eulerAngles.z - 110)
            {
                ActivatePointsUI("GreatSC");
            }
            // Arrow not in skill check zone
            else
            {
                FinishSkillCheck(false);
            }
        }
        // Arrow went full circle
        if (-arrowRotation >= 360)
        {
            FinishSkillCheck(false);
        }

    }
    public void FinishSCIfActive()
    {
        if (isSkillCheckOn)
        {
            FinishSkillCheck(false);
        }
    }
    void FinishSkillCheck(bool result)
    {
        isSkillCheckOn = false;
        arrowRotation = 0.0f;
        arrowRotator.transform.rotation = Quaternion.Euler(Vector3.zero);
        SetActiveGameUI(false);
     
     
        if (!result)
        {
            OnSkillCheckFail();
        }
        else
        {
            OnSkillCkeckGood();
        }
    }
    void ActivatePointsUI(string type)
    {
        foreach (Transform child in pointsUi.transform)
        {
            child.gameObject.SetActive(child.name == type);
        }
        pointsUi.SetActive(true);
        Invoke("DeactivatePointsUI", 3);
    }
    void DeactivatePointsUI()
    {
        pointsUi.SetActive(false);
    }
    void SetActiveGameUI(bool isActive)
    {
        arrowRotator.SetActive(isActive);
        circle.SetActive(isActive);
        space.SetActive(isActive);
    }
 
    void Update()
    {
        if (isSkillCheckOn)
        {
            DoSkillCheck();
        }
    }
}
