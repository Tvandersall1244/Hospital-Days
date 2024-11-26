using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour, IInteractable
{
	// everything that is grabbable should be able to put in your inventory
	private Rigidbody rb;
    private Collider col;
	private Transform objectGrabPoint;
	
	[SerializeField] private InventoryItem inventoryItem;
	public InventoryItem GetInventoryItem => inventoryItem;
	
	private float speed = 10f;
	private bool holding = false;
	private void Awake()
	{
		col = GetComponent<Collider>();
		rb = GetComponent<Rigidbody>();
	}
	
	public Transform GetTransform()
	{
		return objectGrabPoint;
	}
	public void Interact(Transform objectGrabPoint)
	{
		if (holding)
		{
			Grab(this.objectGrabPoint);
		}
		else if (!holding)
		{
			Drop();
		}
	}
	public void Grab(Transform objectGrabPoint)
	{
		this.objectGrabPoint = objectGrabPoint;
		rb.useGravity = false;
		col.enabled = false;
	}

	public void Drop()
	{
		this.objectGrabPoint = null;
		rb.useGravity = true;
		col.enabled = true;
	}

	public void Remove()
	{
		this.objectGrabPoint = null;
		Destroy(gameObject);
		// gameObject.SetActive(false); disable instead of destroying and reinstantiating, don't think this is useful
	}

	private void FixedUpdate()
	{
		if (objectGrabPoint != null)
		{
			Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPoint.position, Time.deltaTime * speed);
			rb.MovePosition(newPosition);
		}
	}
}
