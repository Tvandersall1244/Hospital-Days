using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour, IInteractable
{
	// everything that is grabbable should be able to put in your inventory
	private Rigidbody rb;
	private Transform objectGrabPoint;
	
	[SerializeField] private InventoryItem inventoryItem;
	public InventoryItem GetInventoryItem => inventoryItem;
	
	private float speed = 10f;
	private bool holding = false;
	private void Awake()
	{
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
		rb.isKinematic = true;
	}

	public void Drop()
	{
		this.objectGrabPoint = null;
		rb.useGravity = true;
		rb.isKinematic = false;
	}

	public void Remove()
	{
		this.objectGrabPoint = null;
		gameObject.SetActive(false);
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
