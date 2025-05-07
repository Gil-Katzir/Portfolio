import java.util.Vector;

public class Voter implements Runnable {
    private Queue<Voter> firstQ; //the queue to guards
    private String first_name; //first name
    private String last_name; //last name
    private int age; //age of the voter
    private int id; //id voter
    private String mayor_selection; //the mayor chosen by the voter
    private String List_Selection; //the mayor chosen by the voter
    private long arrival_time; //which time the voter will come to the kalpi

    public Voter(Queue<Voter> firstQ, String first_name, String last_name, int id, int age, String mayor_selection, String List_Selection, long arrival_time) {
        this.firstQ = firstQ;
        this.first_name = first_name;
        this.last_name = last_name;
        this.age = age;
        this.id = id;
        this.mayor_selection = mayor_selection;
        this.List_Selection = List_Selection;
        this.arrival_time = arrival_time;
    }

    //get the id of the voter
    public int getId() {
        return id;
    }

    //get the age of the voter
    public int getAge() {
        return age;
    }

    //get the mayor selection
    public String getMayor_selection() {
        return mayor_selection;
    }

    //get the list selction
    public String getList_Selection() {
        return List_Selection;
    }

    public void run() {
        try {
            Thread.sleep(this.arrival_time * 1000); //sleep until arrival time
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        //check if the vote came before the kalpi is close
        if (this.firstQ.isOpen()) {
            this.firstQ.insert(this);
        }
    }

}

