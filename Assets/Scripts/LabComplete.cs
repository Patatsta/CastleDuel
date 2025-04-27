using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LabComplete : MonoBehaviour
{
    [SerializeField] Material labMaterial;
   
    private const string lab01Name = "Lab 01 -- Rigidbodies Basics";
    private const string lab02Name = "Lab 02 -- Primitive Colliders";
    private const string lab03Name = "Lab 03 -- Terrain Colliders";
    private const string lab04Name = "Lab 04 -- Mesh Colliders";
    private const string lab05Name = "Lab 05 -- Wheel Colliders";
    private const string lab06Name = "Lab 06 -- Triggers";
    private const string lab07Name = "Lab 07 -- Physics Materials";
    private const string lab08Name = "Lab 08 -- Applying Forces";
    private const string lab09Name = "Lab 09 -- Collision Detection";
    private const string lab10Name = "Lab 10 -- Raycasting and Trajectories";
    private const string lab11Name = "Lab 11 -- Manipulating Gravity";
    private const string lab12Name = "Lab 12 -- Joints and Articulation";
    private const string lab13Name = "Lab 13 -- Ragdoll Physics";



    private Transform labParent;
    private string parentName;

    public List<GameObject> labItems = new List<GameObject>();

    public bool isCriteriaMet = false;

    void Start()
    {
        labMaterial.SetColor("_EmissionColor", Color.red);
        labParent = gameObject.transform.parent.root;
        parentName = labParent.name;
        CheckCriteria();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LabItem" && isCriteriaMet)
        {
            if (isCriteriaMet)
            {
                labMaterial.SetColor("_EmissionColor", Color.green);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LabItem" && isCriteriaMet)
        {
            if (isCriteriaMet)
            {
                labMaterial.SetColor("_EmissionColor", Color.green);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LabItem" && isCriteriaMet)
        {
            if (isCriteriaMet)
            {
                labItems.Remove(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }

    public void CheckCriteria()
    {
        //Criteria Check for Lab 01
        if (labParent.name == lab01Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria Check for Lab 02
        if (labParent.name == lab02Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 03
        if (labParent.name == lab03Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        if (gameObject.GetComponent<TerrainCollider>() != null)
                        {
                            isCriteriaMet = true;
                        }
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 04
        if (labParent.name == lab04Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<MeshCollider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 05
        if (labParent.name == lab05Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponentInChildren<WheelCollider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 06
        if (labParent.name == lab06Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 07
        if (labParent.name == lab07Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>().material != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 08
        if (labParent.name == lab08Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 09
        if (labParent.name == lab09Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }

        //Criteria for Lab 10
        if (labParent.name == lab10Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }
        
        //Criteria for Lab 11
        if (labParent.name == lab11Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null && item.GetComponent<ConstantForce>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }
        
        //Criteria for Lab 12
        if (labParent.name == lab12Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponent<Rigidbody>() != null && item.GetComponent<Collider>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }
        
        //Criteria for Lab 13
        if (labParent.name == lab13Name)
        {
            foreach (Transform labItem in labParent)
            {
                if (labItem.tag == "LabItem")
                {
                    labItems.Add(labItem.gameObject);
                }

                foreach (GameObject item in labItems)
                {
                    if (item.GetComponentInChildren<Rigidbody>() != null && item.GetComponentInChildren<Collider>() != null && item.GetComponentInChildren<CharacterJoint>() != null)
                    {
                        isCriteriaMet = true;
                    }
                    else
                    {
                        isCriteriaMet = false;
                        return;
                    }
                }
            }
        }
    }
}
