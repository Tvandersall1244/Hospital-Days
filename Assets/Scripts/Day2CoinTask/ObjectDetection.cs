using System.Collections;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Detects if enough books are near player, then fires event to signal change
    private int bookCount;
    
    // Keeps book added while in range
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Book book))
        {
            StartCoroutine(AddBook(book));
        }
    }
    
    // Updates when book is out of range
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Book book))
        {
            StartCoroutine(RemoveBook(book));
        }
    }

    IEnumerator AddBook(Book book)
    {
        if (!book.GetisSelected())
        {
            bookCount++;
            book.SetisSelected(true);
            Debug.Log("Books: " + bookCount);
        }
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator RemoveBook(Book book)
    {
        if (book.GetisSelected())
        {
            bookCount--;
            book.SetisSelected(false);
            Debug.Log("Books: " + bookCount);
        }
        yield return new WaitForSeconds(0.5f);
    }
}