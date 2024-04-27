package com.kiku.javalangprogproject.classes;

import java.awt.*;
import java.awt.print.PageFormat;
import java.awt.print.Printable;
import java.awt.print.PrinterException;
import java.util.ArrayList;
import java.util.List;

public class PrintableTable implements Printable {

    private String tableData;
    private static final int PAGE_WIDTH = 595; // A4 paper size width in points
    private static final int PAGE_HEIGHT = 842; // A4 paper size height in points
    private static final int ROW_HEIGHT = 20; // Height of each row in points
    private int numRowsPerPage;

    public PrintableTable(String tableData) {
        this.tableData = tableData;
        this.numRowsPerPage = PAGE_HEIGHT / ROW_HEIGHT;
    }

    @Override
    public int print(Graphics graphics, PageFormat pageFormat, int pageIndex) throws PrinterException {
        Graphics2D g2d = (Graphics2D) graphics;
        g2d.translate(pageFormat.getImageableX(), pageFormat.getImageableY());

        int totalNumPages = (int) Math.ceil((double) tableData.split("\n").length / numRowsPerPage);

        if (pageIndex >= totalNumPages) {
            return NO_SUCH_PAGE;
        }

        int startRow = pageIndex * numRowsPerPage;
        int endRow = Math.min(startRow + numRowsPerPage, tableData.split("\n").length);

        String[] rows = tableData.split("\n");
        int rowHeight = 20; // Adjust row height as needed
        int pageWidth = (int) pageFormat.getImageableWidth() - (int) (1 * 28.35); // Half centimeter margin on the right
        int pageHeight = (int) pageFormat.getImageableHeight() - (int) (1 * 28.35); // Half centimeter margin at the bottom

        int currentY = ROW_HEIGHT; // Start at the top of the page
        Font reportFont = new Font(g2d.getFont().getName(), Font.PLAIN, 16);
        FontMetrics reportFontMetrics = g2d.getFontMetrics(reportFont);
        int textWidth = reportFontMetrics.stringWidth("Отчет");
        int centerX = (pageWidth - textWidth) / 2;
        int centerY = currentY + 16; // Adjust Y position as needed
        g2d.setFont(reportFont);
        g2d.drawString("Отчет", centerX, centerY);
        currentY += 30;

        for (int i = startRow; i < endRow; i++) {

            String[] columns = rows[i].split("\t");

            // Calculate maximum width needed for each column
            int[] columnWidths = new int[columns.length];
            for (int j = 0; j < columns.length; j++) {
                textWidth = g2d.getFontMetrics(new Font(g2d.getFont().getName(), Font.PLAIN, 8)).stringWidth(columns[j]);
                columnWidths[j] = Math.min(Math.max(textWidth + 10, 100), pageWidth / columns.length); // Adjust max width based on page width
            }

            int x = (int) (1.5 * 5); // 1.5 cm to points conversion assuming 1 cm = 28.35 points
            int currentX = x;
            for (int j = 0; j < columns.length; j++) {
                g2d.drawRect(currentX, currentY, columnWidths[j], rowHeight); // Draw table cell borders
                g2d.setFont(new Font(g2d.getFont().getName(), Font.PLAIN, 8)); // Set font size to 8

                // Wrap text if it doesn't fit in the cell
                String[] wrappedText = wrapText(columns[j], g2d, columnWidths[j], columns[j]);

                int textY = currentY + 15; // Initial text position with 15 units spacing
                for (String line : wrappedText) {
                    int textX = currentX + (columnWidths[j] - g2d.getFontMetrics().stringWidth(line)) / 2;
                    g2d.drawString(line, textX, textY); // Display wrapped text within the cell
                    textY += 12; // Adjust for the next line with 1.15 line spacing
                }

                currentX += columnWidths[j]; // Move to the next column
            }

            currentY += ROW_HEIGHT; // Move to the next row


            if (currentY > pageHeight) {
                return PAGE_EXISTS;
            }

        }

        return PAGE_EXISTS;
    }

    // Method to wrap text to fit within a given width
    private String[] wrapText(String column, Graphics2D g2d, int columnWidth, String text) {
        FontMetrics fm = g2d.getFontMetrics();
        List<String> lines = new ArrayList<>();
        String[] words = text.split(" ");
        StringBuilder currentLine = new StringBuilder();
        int fontSize = 8; // Уменьшаем размер шрифта до 8

        for (String word : words) {
            if (fm.stringWidth(currentLine + " " + word) > columnWidth) {
                lines.add(currentLine.toString().trim());
                currentLine = new StringBuilder();
            }
            currentLine.append(word).append(" ");
        }

        lines.add(currentLine.toString().trim());

        return lines.stream()
                .map(line -> shrinkFont(g2d, line, columnWidth, fontSize))
                .toArray(String[]::new);
    }

    private String shrinkFont(Graphics2D g2d, String text, int columnWidth, int targetFontSize) {
        FontMetrics fm = g2d.getFontMetrics(new Font(g2d.getFont().getName(), Font.PLAIN, targetFontSize));
        if (fm.stringWidth(text) <= columnWidth) {
            return text;
        }

        String[] words = text.split(" ");
        StringBuilder shrunkText = new StringBuilder();
        int currentFontSize = targetFontSize;

        for (String word : words) {
            Font currentFont = g2d.getFont();
            while (fm.stringWidth(shrunkText + " " + word) > columnWidth) {
                currentFontSize--; // Уменьшаем размер шрифта
                g2d.setFont(new Font(g2d.getFont().getName(), Font.PLAIN, currentFontSize));
                fm = g2d.getFontMetrics();
            }
            shrunkText.append(word).append(" ");
        }

        g2d.setFont(new Font(g2d.getFont().getName(), Font.PLAIN, targetFontSize)); // Восстанавливаем исходный размер шрифта

        return shrunkText.toString().trim();
    }

    public int getWidthOfString(String text, FontMetrics fontMetrics) {
        return fontMetrics.stringWidth(text);
    }
}