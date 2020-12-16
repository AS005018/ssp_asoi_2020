import java.util.ArrayList;
import java.util.List;

public class text {
        private List<Paragraph> listParagraph;
        public text() {
            listParagraph = new ArrayList<>();
        }
        public List<Paragraph> getListParagraph() {
            return listParagraph;
        }
        public void addParagraph(Paragraph paragraph) {
            listParagraph.add(paragraph);
        }
        public void deleteParagraph(int paragraphId) {
            listParagraph.remove(paragraphId);
        }
        public void printText() {
            listParagraph.forEach(paragraph -> {paragraph.printParagraph();
                System.out.println("\n");});
        }
    }

