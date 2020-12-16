public class main {

        public static void main(String[] args) {
            Paragraph paragraph1 = new Paragraph();
            paragraph1.addString("Первая строка в первом абзаце.");
            paragraph1.addString("Вторая строка в первом абзаце.");
            paragraph1.addString("Третья строка в первом абзаце.");
            Paragraph paragraph2 = new Paragraph();
            paragraph2.addString("Первая строка во втором абзаце.");
            paragraph2.addString("Вторая строка во втором абзаце.");
            paragraph2.addString("Третья строка во втором абзаце.");
            Paragraph paragraph3 = new Paragraph();
            paragraph3.addString("Первая строка в третьем абзаце.");
            paragraph3.addString("Вторая строка в третьем абзаце.");
            paragraph3.addString("Третья строка в третьем абзаце.");
            paragraph3.deleteString(2);
            text text = new text();
            text.addParagraph(paragraph1);
            text.addParagraph(paragraph2);
            text.addParagraph(paragraph3);
            text.printText();
            text.deleteParagraph(1);
            System.out.println("После удаления второго абзаца:");
            text.printText();
        }

}
