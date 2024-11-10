using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //[SerializeField] private Color _baseColour, _offsetColour;
    [SerializeField] private Material _baseMAT, _offsetMAT;
    [SerializeField] private MeshRenderer _renderer;
    //[SerializeField] private GameObject _highlight;

    

    public bool isSelecting = false;
    public bool hasSelected = false;

    private void Start()
    {
        _renderer = gameObject.GetComponent<MeshRenderer>();

        //GameObject interactObject = GameObject.Find("Token");
        //interact = interactObject.GetComponent<TokenInteract>();
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSelecting = true;

        }
        if (Input.GetMouseButtonDown(0) && isSelecting)
        {
            hasSelected = true;
            isSelecting = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !hasSelected)
        {
            isSelecting = false;
            //_highlight.SetActive(false);
        }
        if (Input.GetMouseButtonDown(1) && hasSelected)
        {
            hasSelected = false;
            isSelecting = false;
            //_highlight.SetActive(false);
        }
        //if(interact.inDamageMenu)
        //{
        //    _highlight.SetActive(false);
        //}


    }
    public void Init(bool isOffset)
    {
        //_renderer.color = isOffset ? _offsetColour : _baseColour;
        _renderer = gameObject.GetComponent<MeshRenderer>();
        _renderer.material = isOffset ? _offsetMAT : _baseMAT;
    }

    public void SearchObjectAbove()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 10))
        {
            Debug.Log(hit.transform.gameObject.name);
            //return hit.transform.gameObject;         
        }
        //return null;
    }


}