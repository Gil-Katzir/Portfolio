public class Day {
    private long day_lenght; //the length of the day
    private boolean dayOver; //the day is over or not yet

    public Day(double day_lenght) {
        this.day_lenght = (long)(day_lenght*1000);
    }

    //get the day length
    public long getDay_lenght() {
        return day_lenght;
    }

    //get if the day is over or not
    public boolean isDayOver() {
        return dayOver;
    }

    //set Day it's over
    public void setDayOver(boolean flag) {
        dayOver = flag;
    }

}
