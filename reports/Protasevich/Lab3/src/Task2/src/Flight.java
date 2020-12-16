import java.util.Date;
public class Flight {
    private String destination;
    private String flightNumber;
    private String typeOfAircraft;
    private Date departureTime;
    private String daysOfTheWeek;
    public Flight(String destination, String flightNumber, String typeOfAircraft,
                  Date departureTime,
                  String daysOfTheWeek) {
        this.destination = destination;
        this.flightNumber = flightNumber;
        this.typeOfAircraft = typeOfAircraft;
        this.departureTime = departureTime;
        this.daysOfTheWeek = daysOfTheWeek;
    }

    public String getDestination() {
        return destination;
    }

    public String getTypeOfAircraft() {
        return typeOfAircraft;
    }

    public Date getDepartureTime() {
        return departureTime;
    }

    public void setDepartureTime(Date departureTime) {
        this.departureTime = departureTime;
    }

    public String getDaysOfTheWeek() {
        return daysOfTheWeek;
    }

    public void setDaysOfTheWeek(String daysOfTheWeek) {
        this.daysOfTheWeek = daysOfTheWeek;
    }

    @Override
    public String toString() {
        return "Flight{" +
                "destination='" + destination + '\'' +
                ", flightNumber='" + flightNumber + '\'' +
                ", typeOfAircraft='" + typeOfAircraft + '\'' +
                ", departureTime=" + departureTime +
                ", daysOfTheWeek='" + daysOfTheWeek + '\'' +
                '}';
    }
}
