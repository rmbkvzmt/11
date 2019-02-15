using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FM
{
    enum Mode //перечисление
    {
        DIR,
        FILE
    }
    class layer
    {
        public string filecontent = "";
        private int selecteditem = 0;
        private List<FileSystemInfo> items;
        public List<FileSystemInfo> Items
        {
            get
            {
                return items;
            }
        }

        public layer(DirectoryInfo dirinfo)
        {
            FileSystemInfo[] ItemS = dirinfo.GetFileSystemInfos();
            List<FileSystemInfo> Items = new List<FileSystemInfo>();
            Items.AddRange(ItemS);//преобразование массива в список
            this.items = Items; // ссылка get экземпляра
        }
        public void delete(FileSystemInfo sys)//метод для удаления 
        {
            if (sys.GetType() == typeof(DirectoryInfo))
            {
                Directory.Delete(sys.FullName, true);//удаление директория
            }
            else
            {
                File.Delete(sys.FullName);//удаление файла
            }
            items.RemoveAt(selecteditem); //удаление по индексу    
        }
        public void rename(FileSystemInfo fInfo)//метод для переимнования
        {
            if (fInfo.GetType() == typeof(DirectoryInfo))
            {
                DirectoryInfo y = fInfo as DirectoryInfo;
                for (int i = 1; i <= 2; i++) // создание пространства для записи имени в консоли
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("New name:");

                string s = Console.ReadLine(); // ввод название для файла
                string path = y.Parent.FullName;
                string newname = Path.Combine(path, s);
                y.MoveTo(newname); // перемещение нового файла по пути старого
            }
            else
            {
                FileInfo y = fInfo as FileInfo;
                for (int i = 1; i <= 2; i++)
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("New name:");

                string s = Console.ReadLine();
                string newname = Path.Combine(y.Directory.FullName, s);
                y.MoveTo(newname);
            }
        }

        public string openingFile(FileInfo f) // метод для открытия/чтения файла
        {
            FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd(); //чтение файла и сохранение его в строку
            fs.Close();
            sr.Close();
            return s; //сохранение в исходник       
        }

        public int SelectedItem
        {
            get
            {
                return selecteditem;
            }
            set
            {
                if (value < 0) selecteditem = items.Count - 1;
                else
                {
                    if (value >= items.Count) selecteditem = 0;
                    else selecteditem = value;
                }

            }
        }
        public void Draw(Mode caase) // метод для оформления
        {
            if (caase == Mode.FILE)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(filecontent);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == selecteditem)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else Console.BackgroundColor = ConsoleColor.Black;
                    if (items[i].GetType() == typeof(DirectoryInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(items[i].Name);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(@"D:\");
            Stack<layer> history = new Stack<layer>(); //создание стека для сохранения слоев
            Mode Case = Mode.DIR;
            history.Push(new layer(dirinfo));
            bool quit = false;
            while (!quit)
            {
                history.Peek().Draw(Case);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--; //верх
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++; //вниз
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo y = history.Peek().Items[x] as FileSystemInfo;
                        if (y.GetType() == typeof(DirectoryInfo))//если это каталог, то создается новый слой каталога и помещается его в стек
                        {
                            DirectoryInfo d = history.Peek().Items[x] as DirectoryInfo;
                            history.Push(new layer(d));
                        }
                        else//если это файл, то оно будет отображать содержимое файла
                        {
                            FileInfo f = history.Peek().Items[x] as FileInfo;
                            history.Peek().filecontent = history.Peek().openingFile(f);
                            Case = Mode.FILE;
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (Case == Mode.DIR) // если это каталог, то оно вернет предыдущий слой стека
                        {
                            if (history.Count() > 1)
                            {
                                history.Pop();
                            }
                        } // если это файл, то оно вернет последний слой стека
                        else
                        {
                            history.Peek().filecontent = "";
                            Case = Mode.DIR; // переключение режима каталога 
                        }
                        break;
                    case ConsoleKey.Delete: // удаление
                        int n = history.Peek().SelectedItem;
                        FileSystemInfo fi = history.Peek().Items[n];
                        history.Peek().delete(fi);
                        break;
                    case ConsoleKey.F2: // переименование
                        history.Peek().rename(history.Peek().Items[history.Peek().SelectedItem]);
                        break;
                    case ConsoleKey.Escape: // назад
                        quit = true;
                        break;
                }
            }
        }
    }
}
