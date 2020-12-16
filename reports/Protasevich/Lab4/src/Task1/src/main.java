public class main {
    public static void main(String[] args) {
        CD cd = new CD();

        cd.addCatalog("first").setCatalog("first_1").setCatalog("first_2");
        cd.addCatalog("second").setCatalog("second_1").setCatalog("second_2").setCatalog("second_3").setCatalog("second_4");

        cd.addCatalog("third").setCatalog("third_1").setCatalog("third_2").setCatalog("third_3");
        cd.print();
    }
}
