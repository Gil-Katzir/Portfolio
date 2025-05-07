import java.util.Vector;

public class Queue<T> {
    private Vector<T> q; //queue of elements
    private boolean isOpen;

    public Queue() {
        this.q = new Vector<T>();
    }

    //insert new item to the vector
    public synchronized void insert(T item) {
        q.add(item);
        this.notifyAll();
    }

    //Extract new item from vector
    public synchronized T extract() throws InterruptedException {
        while (q.isEmpty() && isOpen)
            this.wait();

        if (q == null || q.isEmpty())
            return null;

        return q.remove(0);
    }

    //get the queue
    public Vector<T> getQ() {
        return this.q;
    }

    public void open() {
        isOpen = true;
    }

    public void close() {
        isOpen = false;
    }

    public boolean isOpen() {
        return isOpen;
    }

    public synchronized void WakingUp() {
        this.notifyAll();
        this.isOpen = false;
    }

}




