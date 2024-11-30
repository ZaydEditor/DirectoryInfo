

using System.IO;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            var disk = new StringBuilder(@"D:\");
            var data = new DirectoryInfo(disk.ToString());
            ShowFiles(data);
            while (true)
            {
                Console.Write("Enter the folder name to continue: ");
                var name = Console.ReadLine();
                if (name == "../")
                {
                    Console.Clear();
                    break;
                }
                var folder = data.GetDirectories().Where(x => x.Name == name).FirstOrDefault();
                while (folder == null)
                {
                    Console.Write("Enter the folder name to continue: ");
                    name = Console.ReadLine();
                    folder = data.GetDirectories().Where(x => x.Name == name).FirstOrDefault();
                }
                disk.Append(name + @"\");
                data = new DirectoryInfo(disk.ToString());
                ShowFiles(data);

            }

        }



    }

    

    static void ShowFiles(DirectoryInfo directoryInfo)
    {
        
            Console.Clear();
        Console.WriteLine($"{directoryInfo.FullName} \n\n  {"File/Folder",-70} Size\n");
        try
        {
            foreach (var dir in directoryInfo.GetDirectories())
            {
                Console.WriteLine(".." + dir.Name);
            }
            foreach (var file in directoryInfo.GetFiles())
            {
                var space = 71 - file.Name.Length;
                if (file.Name.Length > 50)
                {
                    Console.Write($"..{file.Name.Substring(0, 50)}...");
                    
                }
                else
                {
                    Console.Write(".." + file.Name);
                }
                for (int i = 0; i < space; i++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine($"{file.Length} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

