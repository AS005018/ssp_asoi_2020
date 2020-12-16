import java.io.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

public class main {
    private static Airline airline;
    private static final SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy HH:mm:ss");

    public static void main(String[] args) throws ParseException {
        airline = new Airline(new ArrayList<>());
        getAirline();
        System.out.println("All flights:");
        airline.printListOfFlights();
        System.out.println("\nFlights for selected destination:");
        airline.printListOfFlightsForSelectedDestination("New York");
        System.out.println("\nFlights for selected day:");
        airline.printListOfFlightsForSelectedDay("TUESDAY");
        System.out.println("\nFlights for selected day and time:");
        airline.printListOfFlightsForSelectedDayAndTime("FRIDAY",
                dateFormat.parse("13.10.2020 15:35:10"));
        System.out.println("\nFlights for selected type:");
        airline.printListOfFlightsForSelectedType("SMALL");
    }

    private static void getAirline() {
        try {
            File file = new File("fl.txt");
            FileReader fr = new FileReader(file);
            BufferedReader reader = new BufferedReader(fr);
            String line = reader.readLine();
            while (line != null) {
                String[] words = line.split("\t");

                airline.addFlights(new Flight(words[0], words[1], words[2], dateFormat.parse(words[3]), words[4]));
                line = reader.readLine();
            }

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ParseException e) {
            e.printStackTrace();
        }
    }
}

