import java.util.Comparator;
//Comparing between two tickets by voters age
public class AgeVotersComparator implements Comparator <VoteTicket> {
    public int compare(VoteTicket t1, VoteTicket t2) {
        return (t1.getAge()-t2.getAge());
    }
}
