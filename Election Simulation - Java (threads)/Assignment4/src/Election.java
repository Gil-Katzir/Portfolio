import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Vector;

public class Election {

    private int numOfSecurityGuard; //number of guards
    private double day_length; //the election day length

    public Election(int numOfSecurityGuard, double day_length ) throws FileNotFoundException {
        this.numOfSecurityGuard=numOfSecurityGuard;
        this.day_length=day_length;
    }

    //During election day
    public void StartElection(String voters_data, String id_lists) throws FileNotFoundException {
        //Create 2 queues: queue to guards and queue to voting systems
        Queue<Voter> firstQ = new Queue<Voter>();
        Queue<Voter> secondQ = new Queue<Voter>();
        Vector<Thread> threads = new Vector<Thread>();

        //Create new Election day
        Day electionDay = new Day(day_length);

        //Create all the security guards and add to threads vector
        for (int i = 0; i < numOfSecurityGuard; i++) {
            SecurityGuard sg = new SecurityGuard(id_lists, firstQ, secondQ, electionDay);
            Thread t = new Thread(sg);
            threads.add(t);
        }

        //create new votes list
        VotesList vl = new VotesList();

        //Create the voting systems and add to threads vector
        for (int i = 0; i < 2; i++) {
            VotingSystem vs = new VotingSystem(secondQ, electionDay, vl);
            Thread t = new Thread(vs);
            threads.add(t);
        }

        //Read the text VOTERS and add them to threads vector
        Readvoters_dataFile(threads, firstQ, secondQ, voters_data, electionDay);

        //Votes Counter going to sleep
        VotesCounter vc = new VotesCounter(electionDay, threads, vl, firstQ, secondQ);
        Thread tc = new Thread(vc);

        //Start threads
        if( day_length > 0 ){
            tc.start();
            StartThreads(threads);
        }
        else{
            System.out.println("Election day never start because day length is 0");
        }
    }

    //function to read from a file and insert it into vector
    public static void Readvoters_dataFile(Vector<Thread> threads, Queue<Voter> firstQ, Queue<Voter> secoundQ, String voters_data, Day d) {
        Path pathToFile = Paths.get(voters_data);
        BufferedReader br = null;
        String line;

        try {
            br = new BufferedReader(new FileReader(voters_data));
            line = br.readLine(); //read the first line in the file
            line = br.readLine(); //Next line
            while (line != null) //file is not finished yet
            {
                String[] Data = line.split("\t"); //divide line to array of fields
                Voter v = new Voter(firstQ, Data[0], Data[1], Integer.parseInt(Data[2]), Integer.parseInt(Data[3]), Data[4], Data[5], Long.parseLong(Data[6])); // Create new voter
                Thread t = new Thread(v);
                threads.add(t);
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
    }


    //Start all the threads
    public static void StartThreads(Vector<Thread> threads) {
        for (int i = 0; i < threads.size(); i++) {
            threads.get(i).start();
        }
    }

}




