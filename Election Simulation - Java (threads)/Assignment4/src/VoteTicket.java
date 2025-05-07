public class VoteTicket implements Comparable <VoteTicket>  {
    private int index;
    private int id;
    private int age;
    private String mayor_selection;
    private String List_Selection;

    public VoteTicket(int index, int id, int age,String mayor_selection,String List_Selection ){
                this.index = index;
                this.id = id;
                this.age = age;
                this.mayor_selection = mayor_selection;
                this.List_Selection = List_Selection;
    }

    //get id of the voter
    public int getId() {
        return id;
    }

    //get the mayor selection
    public String getMayor_selection() {
        return mayor_selection;
    }

    //get the list selection
    public String getList_Selection() {
        return List_Selection;
    }

    //get the age of the voter
    public int getAge() {
        return age;
    }

    public int getIndex() {
        return index;
    }

    //compare between vote ticket by index
    public int compareTo (VoteTicket other) {
        if (this.index>other.index)
            return 1;
        if(this.index<other.index)
            return -1;
        return 0;
    }
}

