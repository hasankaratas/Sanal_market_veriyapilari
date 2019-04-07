using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket
{
    public class Heap
    {
        private HeapDugumu[] heapArray;
        private int maxSize;
        public int currentSize;
        public Heap(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            currentSize = 0;
            heapArray = new HeapDugumu[maxSize];
        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
        public bool Insert(Urun u)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(u);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
            while (index > 0 && heapArray[parent].urun.SatisFiyati > bottom.urun.SatisFiyati)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public HeapDugumu RemoveMax() // Remove maximum value HeapDugumu
        {
            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            MoveToDown(0);
            return root;
        }
        public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                //Find larger child
                if (rightChild < currentSize && heapArray[leftChild].urun.SatisFiyati > heapArray[rightChild].urun.SatisFiyati)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.urun.SatisFiyati <= heapArray[largerChild].urun.SatisFiyati)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
        
            
        
    }
}
