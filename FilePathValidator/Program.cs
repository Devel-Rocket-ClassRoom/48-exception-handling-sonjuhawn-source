using System;

// README.md를 읽고 아래에 코드를 작성하세요.
Console.WriteLine("=== 경로 검증 테스트 ===");
string[] files = new string[] { "C:/Users/data/report.txt", null, "a>b", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" };

foreach (string file in files)
{
    try
    {
        Console.WriteLine($"경로가 유효합니다: {path}");
    }
    catch
    {
        Console.WriteLine($"[{(ex)} 오류]경로는 null이거나 비어있을 수 없습니다.");
    }

}

class FilePathValidator
{

    public void ValidatePath(string path)
    {
        string[] strs = { "<", ">", "|", "\"", "*", "?" };

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException();
        }
        else if (path.Length > 260)
        {
            throw new ArgumentOutOfRangeException($"경로 길이가 260자를 초과합니다.");
        }
        else if (path.Contains("<") || path.Contains(">") || path.Contains("?") || path.Contains("|") || path.Contains("\"") || path.Contains("*"))
        {
            string ex = null;
            if (path.Contains("<"))
                ex = "<";
            if (path.Contains(">"))
                ex = ">";
            if (path.Contains("|"))
                ex = "|";
            if (path.Contains("\""))
                ex = "\"";
            if (path.Contains("*"))
                ex = "*";
            if (path.Contains("?"))
                ex = "?";
            if (ex != null)
            {
                throw new ArgumentException($" {ex}가 포함되어 있습니다.");
            }
        }
        Console.WriteLine($"경로가 유효합니다: {path}");
    }

    public void ValidateExtension(string path, string[] allowedExtensions)
    {
        foreach (string extension in allowedExtensions)
        {
            if (!path.Contains(extension))
            {
                throw new ArgumentException($"허용되지 않은 확장자입니다: {extension}");
            }
            Console.WriteLine($"확장자가 유효합니다: {extension}");
            break;
        }
        
    }
}