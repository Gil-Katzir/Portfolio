public class Mouse extends Elephant{

	public Mouse(int owner, Mammals[][]Board) {
		super(owner, Board);
	}

	//return the pin on board
	public String toString() {
		if(Queen==false)
			return ("M"+this.owner);
		return ("M"+this.owner+"Q");
	}


	//The eating move
	public void EatAndRemoveEnemy(int FromRow, int FromCol, int ToRow, int ToCol) {  
		MoveTheComputerPins(FromRow,FromCol,ToRow,ToCol);
	}

	//Change the places on board
	public void MoveTheComputerPins(int FromRow, int FromCol, int ToRow, int ToCol) {
		Board[ToRow][ToCol]=Board[FromRow][FromCol];
		Board[FromRow][FromCol]=null;
	}

	//Move the user pins 
	public void MoveUserPins(int FromRow, int FromCol, int ToRow, int ToCol) {
		UpdateUserPlaces(FromRow,FromCol,ToRow,ToCol);
	}

	//change the place of user pins
	public void MoveUserPinsAgain(int FromRow, int FromCol, int ToRow, int ToCol) {
		UpdateUserPlaces(FromRow, FromCol, ToRow, ToCol);
	}

	//Change the user places when he move
	public void UpdateUserPlaces(int FromRow, int FromCol, int ToRow, int ToCol) {
		Board[ToRow][ToCol]=Board[FromRow][FromCol];
		Board[FromRow][FromCol]=null;
	}

	public  boolean isOneStep(int FromRow, int FromCol, int ToRow, int ToCol) {
		if((MouseCanEatRightForward(FromRow,FromCol,FromRow-2,FromCol+2) || MouseCanEatLeftForward(FromRow,FromCol,FromRow-2,FromCol-2) )&& !isEat(FromRow, FromCol, ToRow, ToCol)  ) {
			System.out.println("Mouse Must Eat");
			return false;
		}

		if(isStepForward(FromRow,FromCol,ToRow,ToCol))
			return true;

		if(isQ(FromRow,FromCol)) {
			if(isStepBack(FromRow,FromCol,ToRow,ToCol)) //Queen can move back
				return true;
		}
		return false;
	}

	//Check if to mouse has a option to eat right forward
	public  boolean MouseCanEatRightForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(!super.ToOutOfBoundries(FromRow,FromCol,ToRow,ToCol) && PlaceIsFree(FromRow,FromCol,ToRow,ToCol) && super.isCompInMiddle(FromRow,FromCol,ToRow,ToCol))
			return true;
		return false;
	}

	//Check if to mouse has a option to eat left forward
	public  boolean MouseCanEatLeftForward(int FromRow, int FromCol, int ToRow, int ToCol) {
		if(!super.ToOutOfBoundries(FromRow,FromCol,ToRow,ToCol) && PlaceIsFree(FromRow,FromCol,ToRow,ToCol) && super.isCompInMiddle(FromRow,FromCol,ToRow,ToCol))
			return true;
		return false;
	}
}