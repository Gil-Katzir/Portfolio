import java.util.Vector;
public class VotesCounter implements Runnable {

    private Day electionDay; //election day
    private Vector<Thread> threads; //all the threads
    private VotesList vl; //the list of the votes
    private Queue<Voter> firstQ; //Secuiry guards queue
    private Queue<Voter> secondQ; //Voting system queue

    public VotesCounter(Day electionDay, Vector<Thread> threads, VotesList vl, Queue<Voter> firstQ, Queue<Voter> secondQ) {
        this.electionDay = electionDay;
        this.threads = threads;
        this.vl = vl;
        this.firstQ=firstQ;
        this.secondQ=secondQ;
    }

    public void run() {
        try {
            Thread.sleep(electionDay.getDay_lenght()); //sleep until the day is over
        } catch (InterruptedException e) {
            e.getMessage();
        }

        electionDay.setDayOver(true);//update day is over
        wakingUp();
        checkThreadFinish(); //finish when  all the threads are dead

        if(vl !=null   &&  vl.getVl()!=null && !vl.getVl().isEmpty())
            countingVotes(); //Start to counting the votes!
        else
            System.out.println("No vote to counting.... ");

        System.out.println("The session is over, see you next time!");

    }

    //Counting the votes to mayor and list
    public void countingVotes() {
            System.out.println("Voting is over, let’s start counting");

            Vector<String> Mayors = new Vector<>();
            Vector<String> Lists = new Vector<>();
            String m = vl.getVl().get(0).getMayor_selection(); //first mayor vote
            String l = vl.getVl().get(0).getList_Selection(); //first vote list
            Mayors.add(m); //add this mayor to the mayors vector
            Lists.add(l);//add this list to the lists vector

            //Check if the mayor or list already in the vector
            for (int i = 1; i < vl.getVl().size(); i++) {
                if (!foundMayor(Mayors, i))
                    Mayors.add(vl.getVl().get(i).getMayor_selection());
                if (!foundList(Lists, i))
                    Lists.add(vl.getVl().get(i).getList_Selection());
            }

            //Counting array for the votes
            int[] MayorVotes = new int[Mayors.size()];
            int[] ListVotes = new int[Lists.size()];

            //Counting the votes
            for (int i = 0; i < Mayors.size(); i++) {
                countMayorVote(Mayors, MayorVotes, i);
            }
            for (int i = 0; i < Lists.size(); i++) {
                countListVote(Lists, ListVotes, i);
            }
            //Display the winners
            String mayorWinnter = Mayors.get(getMax(MayorVotes));
            String listWinnter = Lists.get(getMax(ListVotes));
            System.out.println("The next mayor is: " + mayorWinnter);
            System.out.println("The list with most votes is: " + listWinnter);
        }



    //Get the maximum integer number from array
    public int getMax(int[] arr) {
        int Max = arr[0];
        int maxIndex=0;
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] > Max) {
                Max = arr[i];
                maxIndex=i;
            }
        }
        return maxIndex;
    }

    //Check if the mayor already in the vector
    public boolean foundMayor(Vector<String> Mayors, int index) {
        for (int j = 0; j < Mayors.size(); j++) {
            String m = vl.getVl().get(index).getMayor_selection();
            if (m.equals(Mayors.get(j))) {
                return true;
            }
        }
        return false;
    }

    //Check if the list already in the vector
    public boolean foundList(Vector<String> Lists, int index) {
        for (int j = 0; j < Lists.size(); j++) {
            String l = vl.getVl().get(index).getList_Selection();
            if (l.equals(Lists.get(j))) {
                return true;
            }
        }
        return false;
    }

    //Counting the votes to mayors
    public void countMayorVote (Vector <String> Mayors, int []MayorVotes, int index) {
        for (int j = 0; j < vl.getVl().size(); j++) {
            if (vl.getVl().get(j).getMayor_selection().equals(Mayors.get(index)))
                MayorVotes[index]++;
        }
    }

    //Counting the votes to lists
    public void countListVote(Vector<String> Lists, int [] ListsVotes, int index){
        for (int k = 0; k < vl.getVl().size(); k++) {
            if (vl.getVl().get(k).getList_Selection().equals(Lists.get(index)))
                ListsVotes[index]++;
        }
    }

    //Check if all the threads are died
    public void checkThreadFinish() {
        for (int i = 0; i < this.threads.size(); i++) {
            try {
                this.threads.get(i).join();
            } catch (InterruptedException e) {
            }
        }
    }

    //votes counter waking up
    public void wakingUp(){
        firstQ.WakingUp();
        secondQ.WakingUp();
    }

}
