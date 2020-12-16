import java.util.ArrayList;

public class main {
    public static void main(String[] args) {
        IntegerSet integerSet1 = new IntegerSet();
        integerSet1.addItem(15);
        integerSet1.addItem(135);
        integerSet1.addItem(20);
        ArrayList<Integer> integerList = new ArrayList() {{
            add(10);
            add(25);
            add(135);
        }};
        IntegerSet integerSet2 = new IntegerSet(integerList);
        System.out.println("First set: " + integerSet1);
        System.out.println("Second set: " + integerSet2);
        System.out.println("integerSet1 == integerSet2: " +
                (integerSet1.equals(integerSet2)));
        integerSet2.addItem(123);
        integerSet1.deleteItemById(2);
        System.out.println("Second item of integerSet2 = " +
                integerSet2.getItemById(2));
        System.out.println("integerSet2 contains 25: " + integerSet2.contains(25));
        System.out.println("intersections: " + integerSet2.intersections(integerSet1));
    }
}

