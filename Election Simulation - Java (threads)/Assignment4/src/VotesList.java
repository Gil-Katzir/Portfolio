import java.util.Vector;

public class VotesList {

    Vector<VoteTicket> vl;

    public VotesList(){
        this.vl = new Vector<VoteTicket>();
    }

    public Vector<VoteTicket> getVl() {
        return vl;
    }

    public void addVote (VoteTicket vt) {
        this.vl.add(vt);

    }
}
