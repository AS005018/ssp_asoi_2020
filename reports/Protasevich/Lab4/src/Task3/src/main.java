public class main {
    public static void main(String[] args) {
        OnlineStore onlineStore = new OnlineStore();
        Administrator administrator = new Administrator(onlineStore);
        administrator.addProduct("Book");
        administrator.addProduct("Laptop");
        administrator.addProduct("Lamp");
        administrator.addProduct("Phone");
        administrator.addProduct("Pencil");
        administrator.addProduct("Table");
        Client client1 = new Client(1, onlineStore);
        System.out.println("All products:");
        client1.printProducts();
        client1.addOrder(6).pay();
        client1.addOrder(4);
        client1.addOrder(3).pay();
        System.out.println("\nFirst User orders:");
        client1.printOrders();
        Client client2 = new Client(2, onlineStore);
        client2.addOrder(5).pay();
        client2.addOrder(1).pay();
        System.out.println("\nSecond User orders:");
        client2.printOrders();
        administrator.addToBlackList();
        System.out.println("\nAdministrator add users to BlackList \n if they don't pay");
        System.out.println("\nUser is trying to add order:");
        System.out.println("\nFirst User:");
        client1.addOrder(5);
        System.out.println("\nSecond User:");
        client2.addOrder(6).pay();
    }
}
