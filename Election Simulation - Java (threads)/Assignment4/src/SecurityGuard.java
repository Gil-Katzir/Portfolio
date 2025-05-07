import java.util.Vector;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;
import java.nio.file.Path;
import java.nio.file.Paths;

public class SecurityGuard implements Runnable {
    private Vector<Integer> voters_id; //the lists of all ID
    private Queue<Voter> firstQ; //the queue to guards
    private Queue<Voter> secondQ; // the queue to voting system which guard insert to
    private Day electionDay; //election day

    public SecurityGuard(String id_lists, Queue<Voter> firstQ, Queue<Voter> secoundQ, Day electionDay) throws FileNotFoundException {
        this.firstQ = firstQ;
        this.secondQ = secoundQ;
        this.voters_id = ReadId_listFile(id_lists);
        this.firstQ = firstQ;
        this.electionDay = electionDay;
    }

    public void run() {
        if (!firstQ.isOpen())
            firstQ.open();

        while (!electionDay.isDayOver() || !firstQ.getQ().isEmpty()) { //מה קורה פה?
            try {
                Voter v = this.firstQ.extract(); //extract new voter from queue
                if (v != null) {
                    if (this.AllowEntry(v)) //check if the voter allow to enter
                        this.secondQ.insert(v); //take the voter to the next queue
                }

                if (electionDay.isDayOver() && this.firstQ.isOpen())
                    this.firstQ.close();

            } catch (InterruptedException e) {
            }
        }
    }

    //function to read from a file and insert it into vector
    private Vector<Integer> ReadId_listFile(String id_list) throws FileNotFoundException { //Read the id_list file
        this.voters_id = new Vector<Integer>();
        Path pathToFile = Paths.get(id_list);
        BufferedReader br = null;
        String line;

        try {
            br = new BufferedReader(new FileReader(id_list));
            line = br.readLine(); //read the first line in the file
            line = br.readLine(); //Next line
            while (line != null) //file is not finished yet
            {
                String[] Data = line.split("\t"); //divide line to array of fields
                int ID = Integer.parseInt(line);// Create new municipality
                this.voters_id.add(ID);
                line = br.readLine(); //continue to next line
            }

        } catch (IOException e) {
            throw new RuntimeException(e);
        } finally {
            try {
                br.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        return this.voters_id; // finish to read the file
    }

    private boolean dayOver() { ///JUST FOR NOW
        return false;
    }

    private boolean AllowEntry(Voter v) {
        try {
            Thread.sleep((long) (2000 + Math.random() * 3000)); //takes between 2-5 seconds
        } catch (InterruptedException e) {
            e.getMessage();
        }

        for (int i = 0; i < voters_id.size(); i++) {
            if (voters_id.get(i) == (v.getId())) {
                if (v.getAge() < 17) {
                    sendVoterHome();
                    return false;
                } else {
                    return true;
                }
            }
        }
        sendVoterHome();
        return false;
    }

    public void sendVoterHome (){
    }

}
