public class Dog extends Mammals{

	public Dog(int owner, Mammals[][]Board) {
		super(owner, Board);
	}
	
	//return the pin on board
	public String toString() {
		return ("D"+this.owner);
	}
	
	//check if computer can eat again 
	public boolean canCompEatAgain(int FromRow, int FromCol, int ToRow, int ToCol, int [][] eatenUserPins) {
		return false;
	}
	
	//check if user can eat again 
	public  boolean CanUserEatAgain(int FromRow, int FromCol, int [][] eatenPins) {
		return false;
	}
}