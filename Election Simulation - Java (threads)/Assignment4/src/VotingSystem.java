public class VotingSystem implements Runnable {
    private Queue<Voter> secondQ; //The queue to voting system
    private Queue<Voter> firstQ; // The queue the voters came from
    private static int numberOfVotes; //number of votes
    private VotesList vl; //All the vote tickets
    private Day electionDay; //election day

    public VotingSystem(Queue<Voter> secondQ, Day electionDay, VotesList vl) {
        this.secondQ = secondQ;
        this.electionDay = electionDay;
        this.numberOfVotes = 0;
        this.vl = vl;
    }

    public void run() {
       if(!secondQ.isOpen())
        secondQ.open();

       while (!electionDay.isDayOver() || !secondQ.getQ().isEmpty() ) {
            try {
               Voter v = this.secondQ.extract(); //extract voter from the queue
                if (v != null) {
                    VoteTicket voteticket = createVoteTicket(v);//create ticket
                    if (voteticket != null) {
                        numberOfVotes++; //plus one number of votes
                        vl.addVote(voteticket);//add the ticket to the list of tickets
                    }
                }

                if (electionDay.isDayOver() && this.secondQ.isOpen()) {
                    this.secondQ.close();
                }
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    //Create new vote tickets
    public VoteTicket createVoteTicket(Voter v) {
        try {
            Thread.sleep(2000); //takes 2 seconds
        } catch (InterruptedException e) {
            e.getMessage();
        }
        VoteTicket voteticket = null; //before checking the ticket
        try {
            if (Math.random() <= 0.2)
                throw new Exception("The card creation process did not complete correctly.");
            else {
                voteticket = new VoteTicket(numberOfVotes+1, v.getId(), v.getAge(), v.getMayor_selection(), v.getList_Selection()); //create legal ticket
            }
        } catch (Exception e) {
            System.err.println(e.getMessage());
        }
        return voteticket;

    }

}
