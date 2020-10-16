using System;
using System.Net.NetworkInformation;

namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ширина поля:");
            int columns = int.Parse(Console.ReadLine());

            Console.Write("высота поля:");
            int cells = int.Parse(Console.ReadLine());

            Console.Write("отступ сверху:");
            int top_indent = int.Parse(Console.ReadLine());

            Console.Write("Отступ слева:");
            int left_indent = int.Parse(Console.ReadLine());

            Console.Write("высота ячейки:");
            int cell_height = int.Parse(Console.ReadLine());

            Console.Write("Ширина ячейки:");
            int cell_width = int.Parse(Console.ReadLine());

            Console.Clear();
            TopIndent(top_indent);
            Height(cell_height, cells, left_indent, columns, cell_width);

            Console.Write("коорината по x:");
            int selectedCellX = int.Parse(Console.ReadLine());

            Console.Write("коорината по y:");
            int selectedCellY = int.Parse(Console.ReadLine());

            PaintOver(selectedCellX, selectedCellY, top_indent, cell_height, left_indent, cell_width);
        }

        static void TopIndent(int indent)
        {
            for (int i = 0; i < indent; i++)
                Console.WriteLine("");
        }
        static void Excel(int indent, int columns, int cell_width, string start, string body,
                          string center, string end)
        {
            for (int i = 0; i < indent; i++)
                Console.Write(" ");
            Console.Write(start);
            for (int i = 0; i < columns*cell_width; i++)
            {
                if (i % cell_width == 0 && i != 0)
                    Console.Write(center);
                Console.Write(body);
            }
            Console.WriteLine(end);
        }
        
        static void Height(int cell_height, int cells,
                           int indent, int columns, int cell_width)
        {
            Excel(indent, columns, cell_width, "┌", "─", "┬", "┐");
            for (int i = 0; i < cells*cell_height; i++)
            {
                if (i % cell_height == 0 && i != 0)
                    Excel(indent, columns, cell_width, "├", "─", "┼", "┤");
                Excel(indent, columns, cell_width, "│", " ", "│", "│");
            }
            Excel(indent, columns, cell_width, "└", "─", "┴", "┘");
        }

        static void PaintOver(int x, int y, int top_indent, int cell_height, 
                              int left_indent, int cell_width)
        {
            Console.BackgroundColor = ConsoleColor.White;

                for (int j = 1; j < cell_height; j++)
                {
                    Console.SetCursorPosition(left_indent + cell_width * (x - 1),
                                              top_indent + cell_height * (y - 1) - j);
                    for (int i = 0; i < cell_width; i++)
                        Console.Write(" ");
                }
            Console.SetCursorPosition(left_indent + cell_width * x, top_indent + cell_height * y);
        }
    }
}
