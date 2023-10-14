using System;
using System.Collections.Generic;

namespace DailyPlanner
{
    class Program
    {
        static DateTime currentDate;
        static List<Note> notes;
        static int selectedNoteIndex;

        static void Main(string[] args)
        {
            currentDate = DateTime.Now;
            notes = new List<Note>
            {
                new Note("2023-10-14", "Сходить на пары", "Приехать на учёбу с первой по пятую пару.", "2023-10-14"),
                new Note("2023-10-15", "Сходить в магазин", "Купить яйца, молоко, хлеб, масло.", "2023-10-16"),
                new Note("2023-10-15", "Сделать практические", "Сделать практические по C#, Python, психологии общения.", "2023-10-21"),
                new Note("2023-10-17", "Сходить в спортзал", "День ног, сделать небольшую разминку.", "2023-10-17"),
                new Note("2023-10-18", "Сходить погулять", "Прогуляться с друзьями по району, встреча у магазина приблизительно в 17:00.", "2023-10-18")
            };

            selectedNoteIndex = 0;

            Console.WriteLine("Ежедневник!");
            Console.WriteLine("Дата: " + currentDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Нажмите Enter для подробной информации.");

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                ShowNotesForCurrentDate();
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        currentDate = currentDate.AddDays(-1);
                        break;
                    case ConsoleKey.RightArrow:
                        currentDate = currentDate.AddDays(1);
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedNoteIndex > 0)
                        {
                            selectedNoteIndex--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedNoteIndex < notes.Count - 1)
                        {
                            selectedNoteIndex++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        ShowNoteDetails();
                        Console.WriteLine("Нажмите любую клавишу что бы вернуться в ежедневник.");
                        Console.ReadKey(true);
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }

        static void ShowNotesForCurrentDate()
        {
            Console.WriteLine("Дата: " + currentDate.ToString("yyyy-MM-dd"));

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].Date == currentDate.ToString("yyyy-MM-dd"))
                {
                    if (i == selectedNoteIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"{i + 1}. {notes[i].Title}");

                    if (i == selectedNoteIndex)
                    {
                        Console.ResetColor();
                    }
                }
            }
        }

        static void ShowNoteDetails()
        {
            var selectedNote = notes[selectedNoteIndex];
            Console.WriteLine($"Дата: {selectedNote.Date}");
            Console.WriteLine($"Название заметки: {selectedNote.Title}");
            Console.WriteLine($"Описание: {selectedNote.Description}");
            Console.WriteLine($"Дата выполнения: {selectedNote.Complete}");
        }
    }

    class Note
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Complete { get; set; }

        public Note(string date, string title, string description, string complete)
        {
            Date = date;
            Title = title;
            Description = description;
            Complete = complete;
        }
    }
}