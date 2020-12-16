import java.util.Date;
import java.util.List;
public class Airline {
    private List<Flight> flights;
    public Airline(List<Flight> flights) {
        this.flights = flights;
    }
    public List<Flight> getFlights() {
        return flights;
    }

    public void addFlights(Flight flight) {
        flights.add(flight);
    }

    public void printListOfFlights() {
        flights.forEach(System.out::println);
    }
    public void printListOfFlightsForSelectedDestination(String destination) {
        flights.stream().filter(flight ->
                flight.getDestination().equals(destination)).forEach(System.out::println);
    }
    public void printListOfFlightsForSelectedDay(String dayOfWeek) {
        flights.stream().filter(flight ->
                flight.getDaysOfTheWeek().contains(dayOfWeek)).forEach(System.out::println);
    }
    public void printListOfFlightsForSelectedDayAndTime(String dayOfWeek, Date date)
    {
        flights.stream().filter(flight ->
                flight.getDaysOfTheWeek().contains(dayOfWeek))
                .filter(flight ->
                        flight.getDepartureTime().before(date)).forEach(System.out::println);
    }
    public void printListOfFlightsForSelectedType(String typeOfAircraft) {
        flights.stream().filter(flight ->
                flight.getTypeOfAircraft().equals(typeOfAircraft)).forEach(System.out::println);
    }
}
